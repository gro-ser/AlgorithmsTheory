using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using static System.Linq.Expressions.Expression;

namespace AlgorithmTheory.CreatingDelegates
{
    internal static class ExpressionsHelper
    {
        internal static List<ParameterInfo> SafeParameterList(MethodInfo info)
        {
            // get parameters from method info
            List<ParameterInfo> result = new List<ParameterInfo>(info.GetParameters());
            if (result.Count > 0
                // if the first parameter is Closure
                && result[0].ParameterType == typeof(Closure)
                // and its name doesn't exist
                && result[0].Name == null)
                // then that method was compiled using Expressions
                // and it is necessary to remove this parameter
                result.RemoveAt(0);

            return result;
        }

        internal static Expression CreateCall(Delegate @delegate, IEnumerable<Expression> arguments)
        {
            object target = @delegate.Target;
            // if delegate was created using Expressions
            if (target is Closure)
                // |> delegate.Invoke(arguments)
                return Invoke(Constant(@delegate), arguments);

            Expression instance = null;
            // static |> class.method(arguments)
            if (target != null) instance = Constant(target);
            // instance |> target.method(arguments)
            return Call(instance, @delegate.Method, arguments);
        }

        internal static Expression CreateCall(Delegate @delegate, params Expression[] arguments)
            => CreateCall(@delegate, (IEnumerable<Expression>)arguments);
    }
}