using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using static System.Linq.Expressions.Expression;
using static AlgorithmTheory.CreatingDelegates.ExpressionsHelper;

namespace AlgorithmTheory.CreatingDelegates
{
    /// <summary>
    /// Represents a class that creates a delegate composition.
    /// </summary>
    /// <remarks>
    /// Composition operator.
    /// </remarks>
    public static class CompositionCreator
    {
        /// <summary>
        /// Creates a <see cref="LambdaExpression"/> that is a composition
        /// of <paramref name="external"/> and <paramref name="delegates"/>.
        /// </summary>
        /// <param name="external">External delegate to compose.</param>
        /// <param name="delegates">Inner delegates to compose.</param>
        /// <param name="delegateType">Type of lambda expression.</param>
        /// <returns>Expression of composition of type <paramref name="delegateType"/>.</returns>
        /// <remarks>
        /// Delegates call results are adjusted to the external delegate parameters.
        /// </remarks>
        public static LambdaExpression ComposeExpression(Delegate external, Delegate[] delegates, Type delegateType)
        {
            // check arguments to null
            if (external is null) throw new ArgumentNullException(nameof(external));
            if (delegates is null) throw new ArgumentNullException(nameof(delegates));

            var externalParameters = SafeParameterList(external.Method);
            int delegateCount = externalParameters.Count;

            // check delegates count to external delegate parameters count
            if (delegateCount != delegates.Length) throw new ArgumentException(
                    "The number of external delegate parameters is not equal to the number of delegates.");

            // if are no delegates, return a external method call
            if (delegateCount == 0)
                return Lambda(delegateType ?? external.GetType(), CreateCall(external, null));

            var parameterTypes = SafeParameterList(delegates[0].Method);
            int parameterCount = parameterTypes.Count;

            // check the signatures of all the delegates
            for (int i = 0; i < delegateCount; i++)
            {
                // chek return type with [i] parameter type in external
                MethodInfo mi = delegates[i].Method;
                if (mi.ReturnType != externalParameters[i].ParameterType)
                    throw new ArgumentException("Incorrect return type in delegate.", nameof(delegates));

                // check delegate parameter count
                var tmpParams = SafeParameterList(mi);
                if (tmpParams.Count != parameterCount)
                    throw new ArgumentException("Incorrect number of arguments.", nameof(delegates));

                // check delegate parameter types
                for (int j = 0; j < parameterCount; j++)
                    if (parameterTypes[j].ParameterType != tmpParams[j].ParameterType)
                        throw new ArgumentException("Incorrect signature.", nameof(delegates));
            }

            // create parameters
            ParameterExpression[] parameters = new ParameterExpression[parameterCount];
            for (int i = 0; i < parameterCount; i++)
                parameters[i] = Parameter(parameterTypes[i].ParameterType);

            // if param0 is Closure
            if (parameterCount > 0 && parameters[0].Type == typeof(int)) { }

            // create delegate call expressions
            Expression[] innerCalls = new Expression[delegateCount];
            for (int i = 0; i < delegateCount; i++)
                innerCalls[i] = CreateCall(delegates[i], parameters);

            // create external delegate call
            Expression externalCall = CreateCall(external, innerCalls);

            LambdaExpression lambda;
            if (delegateType is null)
                // if `delegateType` is null that method create it automatically
                lambda = Lambda(externalCall, parameters);
            else
                // if it isn't null, then specify the type explicitly
                lambda = Lambda(delegateType, externalCall, parameters);

            return lambda;
        }

        /// <summary>
        /// Creates a <see cref="LambdaExpression"/> that is a composition
        /// of <paramref name="external"/> and <paramref name="delegates"/>.
        /// </summary>
        /// <param name="external">External delegate to compose.</param>
        /// <param name="delegates">Inner delegates to compose.</param>
        /// <returns>Expression of composition.</returns>
        /// <remarks>
        /// Delegates call results are adjusted to the external delegate parameters.
        /// <para>Expression type define automatically.</para>
        /// </remarks>
        public static LambdaExpression ComposeExpression(Delegate external, params Delegate[] delegates)
        {
            return ComposeExpression(external, delegates, null);
        }

        /// <summary>
        /// Creates a <see cref="Expression{TDelegate}"/> that is a composition
        /// of <paramref name="external"/> and <paramref name="delegates"/>.
        /// </summary>
        /// <param name="external">External delegate to compose.</param>
        /// <param name="delegates">Inner delegates to compose.</param>
        /// <typeparam name="TDelegate">Type of lambda expression.</typeparam>
        /// <permission cref="float">wat</permission>
        /// <returns>Expression of composition of type <typeparamref name="TDelegate"/>.</returns>
        /// <remarks>
        /// Delegates call results are adjusted to the external delegate parameters.
        /// </remarks>
        public static Expression<TDelegate> ComposeExpression<TDelegate>(Delegate external, params Delegate[] delegates)
#if DEBUG
            where TDelegate : Delegate
#endif
        {
            return (Expression<TDelegate>)ComposeExpression(external, delegates, typeof(TDelegate));
        }

        /// <summary>
        /// Creates a new <see cref="Delegate"/> that is a composition
        /// of <paramref name="external"/> and <paramref name="delegates"/>.
        /// </summary>
        /// <param name="external">External delegate to compose.</param>
        /// <param name="delegates">Inner delegates to compose.</param>
        /// <returns>Compiled expression of composition.</returns>
        /// <remarks>
        /// Delegates call results are adjusted to the external delegate parameters.
        /// <para>Return type defines automatically.</para>
        /// </remarks>
        public static Delegate Compose(Delegate external, params Delegate[] delegates)
        {
            LambdaExpression lambda = ComposeExpression(external, delegates, null);
            return lambda.Compile();
        }

        /// <summary>
        /// Creates a new <typeparamref name="TDelegate"/> that is a composition
        /// of <paramref name="external"/> and <paramref name="delegates"/>.
        /// </summary>
        /// <typeparam name="TDelegate">The type of delegate return.</typeparam>
        /// <param name="external">External delegate to compose.</param>
        /// <param name="delegates">Inner delegates to compose.</param>
        /// <returns>Compiled expression of composition of
        /// type <typeparamref name="TDelegate"/>.</returns>
        /// <remarks>
        /// Delegates call results are adjusted to the external delegate parameters.
        /// </remarks>
        public static TDelegate Compose<TDelegate>(Delegate external, params Delegate[] delegates)
#if DEBUG
            where TDelegate : Delegate
#endif
        {
            var lambda = ComposeExpression<TDelegate>(external, delegates);
            return lambda.Compile();
        }


        /// <summary>
        /// Сreate an expression of sequential composition of delegates.
        /// </summary>
        /// <param name="delegates">Delegates to compose.</param>
        /// <param name="delegateType">The type of return expression.</param>
        /// <returns>Expression of the composition of delegates.</returns>
        /// <remarks>
        /// <para>The last delegate in array will be called first in expression.</para>
        /// <para>The first delegate in array will external delegate in expression.</para>
        /// </remarks>
        public static LambdaExpression ComposeSequenceExpression(Delegate[] delegates, Type delegateType)
        {
            if (delegates is null)
                throw new ArgumentNullException(nameof(delegates));
            int length = delegates.Length - 1;
            if (length == -1)
                throw new ArgumentException("There are not delegates.", nameof(delegates));

            Delegate lastDelegate = delegates[length];
            List<ParameterInfo> parameterTypes = SafeParameterList(lastDelegate.Method);
            int argc = parameterTypes.Count;

            ParameterExpression[] arguments = new ParameterExpression[argc];
            for (int i = 0; i < argc; i++)
                arguments[i] = Parameter(parameterTypes[i].ParameterType);

            Expression call = CreateCall(lastDelegate, arguments);

            for (int i = length - 1; i >= 0; --i)
            {
                Delegate last = delegates[i + 1];
                Delegate curr = delegates[i];
                List<ParameterInfo> args = SafeParameterList(curr.Method);
                if (args.Count != 1 || args[0].ParameterType != last.Method.ReturnType)
                    throw new ArgumentException("Error delegate signature.");
                call = CreateCall(curr, call);
            }

            LambdaExpression lambda;
            if (delegateType is null)
                lambda = Lambda(call, arguments);
            else
                lambda = Lambda(delegateType, call, arguments);

            return lambda;
        }

        /// <summary>
        /// Сreate an expression of sequential composition of delegates.
        /// </summary>
        /// <param name="delegates">Delegates to compose.</param>
        /// <returns>Expression of the composition of delegates.</returns>
        /// <remarks>
        /// <para>The last delegate in array will be called first in expression.</para>
        /// <para>The first delegate in array will external delegate in expression.</para>
        /// </remarks>
        public static LambdaExpression ComposeSequenceExpression(params Delegate[] delegates)
        {
            return ComposeSequenceExpression(delegates, null);
        }

        /// <summary>
        /// Сreate an expression of sequential composition of delegates.
        /// </summary>
        /// <param name="delegates">Delegates to compose.</param>
        /// <typeparam name="TDelegate">The type of expression.</typeparam>
        /// <returns>Expression of the composition of delegates.</returns>
        /// <remarks>
        /// <para>The last delegate in array will be called first in expression.</para>
        /// <para>The first delegate in array will external delegate in expression.</para>
        /// </remarks>
        public static Expression<TDelegate> ComposeSequenceExpression<TDelegate>(params Delegate[] delegates)
#if DEBUG
            where TDelegate : Delegate
#endif
        {
            return (Expression<TDelegate>)ComposeSequenceExpression(delegates, typeof(TDelegate));
        }

        /// <summary>
        /// Сreate a sequential composition of delegates.
        /// </summary>
        /// <param name="delegates">Delegates to compose.</param>
        /// <returns>Expression of the composition of delegates.</returns>
        /// <remarks>
        /// <para>The last delegate in array will be called first in expression.</para>
        /// <para>The first delegate in array will external delegate in expression.</para>
        /// </remarks>
        public static Delegate ComposeSequence(params Delegate[] delegates)
        {
            var lambda = ComposeSequenceExpression(delegates);
            return lambda.Compile();
        }

        /// <summary>
        /// Сreate a sequential composition of delegates.
        /// </summary>
        /// <param name="delegates">Delegates to compose.</param>
        /// <typeparam name="TDelegate">The type of delegate to return.</typeparam>
        /// <returns>Expression of the composition of delegates.</returns>
        /// <remarks>
        /// <para>The last delegate in array will be called first in expression.</para>
        /// <para>The first delegate in array will external delegate in expression.</para>
        /// </remarks>
        public static TDelegate ComposeSequence<TDelegate>(params Delegate[] delegates)
#if DEBUG
            where TDelegate : Delegate
#endif
        {
            var lambda = ComposeSequenceExpression<TDelegate>(delegates);
            return lambda.Compile();
        }
    }
}