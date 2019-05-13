using System.Linq.Expressions;
using ParamDict = System.Collections.Generic.Dictionary<
    System.Linq.Expressions.ParameterExpression,
    System.Linq.Expressions.ParameterExpression>;

namespace AlgorithmTheory.CreatingDelegates
{
    internal class ChangeParametersVisitor : ExpressionVisitor
    {
        private ParamDict replaceParameters;

        public ChangeParametersVisitor(ParamDict dictionary)
            => replaceParameters = dictionary;

        public ChangeParametersVisitor(params (ParameterExpression, ParameterExpression)[] parameters)
        {
            int length = parameters.Length;
            replaceParameters = new ParamDict(length);
            for (int i = 0; i < length; ++i)
                replaceParameters.Add(parameters[i].Item1, parameters[i].Item2);
        }

        protected override Expression VisitParameter(ParameterExpression node)
            => replaceParameters.TryGetValue(node, out var result) ? result : node;
        //  => replaceParameters.ContainsKey(node) ? replaceParameters[node] : node;

        public static Expression ChangeParameters(
            Expression body,
            params (ParameterExpression, ParameterExpression)[] parameters)
            => new ChangeParametersVisitor(parameters).Visit(node: body);

        protected override Expression VisitLambda<T>(Expression<T> node)
            // TODO make some logit here
        {
            return base.VisitLambda(node);
            /*
            Expression result;
            var temp = replaceParameters;
            replaceParameters = new ParamDict();
            result = base.VisitLambda(node); // TODO
            replaceParameters = temp;
            return result;
            */
        }
    }
}