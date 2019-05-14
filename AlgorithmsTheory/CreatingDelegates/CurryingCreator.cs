using System;
using System.Linq.Expressions;
using static AlgorithmTheory.CreatingDelegates.ExpressionsHelper;
using static System.Linq.Expressions.Expression;

namespace AlgorithmTheory.CreatingDelegates
{
    public class CurryingCreator
    {
        public static LambdaExpression LockParameterExpression(
            Delegate @delegate, object argument, int index, Type delegateType)
        {
            var types = SafeParameterList(@delegate.Method);
            int length = types.Count;
            var parameters = new ParameterExpression[length - 1];
            var arguments = new Expression[length];

            for (int i = 0; i < index; i++)
                arguments[i] = parameters[i] = Parameter(types[i].ParameterType);

            arguments[index] = Constant(argument, types[index].ParameterType);

            for (int i = index + 1; i < length; i++)
                arguments[i] = parameters[i - 1] = Parameter(types[i].ParameterType);

            var body = CreateCall(@delegate, arguments);
            LambdaExpression lambda;
            if (delegateType == null)
                lambda = Lambda(body, parameters);
            else
                lambda = Lambda(delegateType, body, parameters);
            return lambda;
        }

        public static Expression<TDelegate> LockParameterExpression<TDelegate>(
            Delegate @delegate, object argument, int index)
#if DEBUG
            where TDelegate : Delegate
#endif
        {
            return (Expression<TDelegate>)LockParameterExpression(@delegate, argument, index, typeof(TDelegate));
        }

        public static Delegate LockParameter(
            Delegate @delegate, object argument, int index, Type delegateType)
        {
            return LockParameterExpression(@delegate, argument, index, delegateType).Compile();
        }

        public static TDelegate LockParameter<TDelegate>(
            Delegate @delegate, object argument, int index)
#if DEBUG
            where TDelegate : Delegate
#endif
        {
            return LockParameterExpression<TDelegate>(@delegate, argument, index).Compile();
        }
    }
}