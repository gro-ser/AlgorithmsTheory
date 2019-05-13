using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using static AlgorithmTheory.CreatingDelegates.ExpressionsHelper;
using static System.Linq.Expressions.Expression;

namespace AlgorithmTheory.CreatingDelegates
{
    /// <summary>
    /// Represents a class that creates a recursion delegates.
    /// </summary>
    /// <typeparam name="TCounter">
    /// The counter type.
    /// </typeparam>
    /// <remarks>
    /// Primitive recursive function.
    /// </remarks>
    public class RecursionCreator<TCounter>
    {
        private static readonly Type CounterType = typeof(TCounter);

        private readonly ParameterExpression counter;
        private readonly Expression cond;
        private readonly Expression pred;
        private readonly Expression succ;
        private readonly Expression zero;

        private RecursionCreator()
        {
            counter = Parameter(CounterType, "counter");
        }

        /// <summary>
        /// Create new RecursionCreator by lambda expressions for
        /// condition, successor and predecessor functions.
        /// </summary>
        /// <param name="Cond">Condition function.</param>
        /// <param name="Pred">Successor function.</param>
        /// <param name="Succ">Predecessor function.</param>
        /// <remarks>
        /// <para><paramref name="Pred"/> must be not null 
        /// for PrimitiveRecursion creating.</para>
        /// <para><paramref name="Succ"/> must be not null 
        /// for OptimizedRecursion creating.</para>
        /// </remarks>
        /// 
        public RecursionCreator(
            Expression<Func<TCounter, bool>> Cond,
            Expression<Func<TCounter, TCounter>> Pred,
            Expression<Func<TCounter, TCounter>> Succ)
            : this()
        {
            zero = Default(CounterType);
            if (Cond == null) throw new ArgumentNullException(nameof(Cond));
            else
                cond = ChangeParametersVisitor.ChangeParameters(
                    Cond.Body, (Cond.Parameters[0], counter));

            if (Pred != null)
                pred = ChangeParametersVisitor.ChangeParameters(
                    Pred.Body, (Pred.Parameters[0], counter));

            if (Succ != null)
                succ = ChangeParametersVisitor.ChangeParameters(
                    Succ.Body, (Succ.Parameters[0], counter));
        }

        /// <summary>
        /// Create new RecursionCreator by zero value and lambda
        /// expressions for successor and predecessor functions.
        /// </summary>
        /// <param name="Zero">Zero value.</param>
        /// <param name="Pred">Successor function.</param>
        /// <param name="Succ">Predecessor function.</param>
        /// <remarks>
        /// <para><paramref name="Pred"/> must be not null 
        /// for PrimitiveRecursion creating.</para>
        /// <para><paramref name="Succ"/> must be not null 
        /// for OptimizedRecursion creating.</para>
        /// </remarks>
        public RecursionCreator(
            TCounter Zero,
            Expression<Func<TCounter, TCounter>> Pred,
            Expression<Func<TCounter, TCounter>> Succ)
            : this()
        {
            cond = Equal(counter, zero = Constant(Zero, CounterType));
            if (Pred != null)
                pred = ChangeParametersVisitor.ChangeParameters(Pred.Body, (Pred.Parameters[0], counter));
            if (Succ != null)
                succ = ChangeParametersVisitor.ChangeParameters(Succ.Body, (Succ.Parameters[0], counter));
        }

        /// <summary>
        /// Create new RecursionCreator by values for zero and one
        /// </summary>
        /// <param name="Zero">Zero value.</param>
        /// <param name="One">One value.</param>
        public RecursionCreator(
            TCounter Zero,
            TCounter One)
            : this()
        {
            ConstantExpression
             one = Constant(One, CounterType);
            zero = Constant(Zero, CounterType);

            cond = Equal(counter, zero);
            pred = Subtract(counter, one);
            succ = Add(counter, one);
        }

        public LambdaExpression PrimitiveRecursionExpression(
            Delegate ifTrue,
            Delegate ifFalse,
            Type delegateType)
        {
            if (pred is null) throw new InvalidOperationException("Pred() function is null.");
            if (ifTrue is null) throw new ArgumentNullException(nameof(ifTrue));
            if (ifFalse is null) throw new ArgumentNullException(nameof(ifFalse));

            List<ParameterInfo>
                tlist = SafeParameterList(ifTrue.Method),
                flist = SafeParameterList(ifFalse.Method);

            int argc = flist.Count - 1;
            if (tlist.Count + 1 != argc) throw new ArgumentException("Invalid arguments count.");

            ParameterExpression[] args = new ParameterExpression[argc];
            args[0] = counter;
            for (int i = 1; i < argc; ++i)
            {
                if (tlist[i - 1].ParameterType != flist[i].ParameterType)
                    throw new ArgumentException("Invalid signature.");
                args[i] = Parameter(flist[i].ParameterType);
            }

            if (ifTrue.Method.ReturnType != ifFalse.Method.ReturnType
                || flist[argc].ParameterType != ifTrue.Method.ReturnType
                || flist[0].ParameterType != CounterType)
                throw new ArgumentException("Invalid signature.");

            if (delegateType is null)
            {
                Type[] types = new Type[argc + 1];
                for (int i = 0; i <= argc; ++i)
                    types[i] = flist[i].ParameterType;
                delegateType = GetFuncType(types);
            }

            ParameterExpression func = Variable(delegateType, "func");

            var tArgs = args.Skip(1);
            var fArgs = args.Cast<Expression>().Append(Invoke(func, args));

            var funcBody = Lambda(
                delegateType,
                Condition(
                    cond,
                    CreateCall(ifTrue, tArgs),
                    Block(
                        Assign(counter, pred),
                        CreateCall(ifFalse, fArgs))),
                args);

            var body = Block(
                new[] { func },
                Assign(func, funcBody),
                Invoke(func, args));

            var lambda = Lambda(delegateType, body, args);

            return lambda;
        }

        public Expression<TDelegate> PrimitiveRecursionExpression<TDelegate>(Delegate ifTrue, Delegate ifFalse)
#if DEBUG
            where TDelegate : Delegate
#endif
        {
            return (Expression<TDelegate>)PrimitiveRecursionExpression(ifTrue, ifFalse, typeof(TDelegate));
        }

        public Delegate PrimitiveRecursion(Delegate ifTrue, Delegate ifFalse, Type delegateType)
        {
            var lambda = PrimitiveRecursionExpression(ifTrue, ifFalse, delegateType);
            return lambda.Compile();
        }

        public TDelegate PrimitiveRecursion<TDelegate>(Delegate ifTrue, Delegate ifFalse)
#if DEBUG
            where TDelegate : Delegate
#endif
        {
            var lambda = PrimitiveRecursionExpression<TDelegate>(ifTrue, ifFalse);
            return lambda.Compile();
        }

        public LambdaExpression OptimizedRecursionExpression(
            Delegate ifTrue,
            Delegate ifFalse,
            Type delegateType)
        {
            if (succ is null) throw new InvalidOperationException("Succ() function is null.");
            if (ifTrue is null) throw new ArgumentNullException(nameof(ifTrue));
            if (ifFalse is null) throw new ArgumentNullException(nameof(ifFalse));

            List<ParameterInfo>
                tlist = SafeParameterList(ifTrue.Method),
                flist = SafeParameterList(ifFalse.Method);

            int argc = flist.Count - 1;
            if (tlist.Count + 1 != argc) throw new ArgumentException("Invalid arguments count.");

            ParameterExpression[] args = new ParameterExpression[argc];
            args[0] = counter;
            for (int i = 1; i < argc; ++i)
            {
                if (tlist[i - 1].ParameterType != flist[i].ParameterType)
                    throw new ArgumentException("Invalid signature.");
                args[i] = Parameter(flist[i].ParameterType);
            }

            if (ifTrue.Method.ReturnType != ifFalse.Method.ReturnType
                || flist[argc].ParameterType != ifTrue.Method.ReturnType
                || flist[0].ParameterType != CounterType)
                throw new ArgumentException("Invalid signature.");

            var temp = Variable(CounterType, "temp");
            var acc = Variable(CounterType, "acc");
            var start = Label("start");
            var end = Label("end");

            var tArgs = args.Skip(1);
            var fArgs = args.Append(acc);

            var body = Block(
                new[] { temp, acc },
                Assign(temp, counter),
                Assign(acc, CreateCall(ifTrue, tArgs)),
                Assign(counter, zero),
                Label(start),
                IfThen(
                    Equal(temp, counter),
                    Return(end)),
                Assign(acc, CreateCall(ifFalse, fArgs)),
                Assign(counter, succ),
                Goto(start),
                Label(end),
                acc
                );

            LambdaExpression lambda;

            if (null == delegateType)
                lambda = Lambda(body, args);
            else
                lambda = Lambda(delegateType, body, args);

            return lambda;
        }
    }
}