using System;

namespace AlgorithmTheory
{
    /// <summary>
    /// Encapsulates a function type that takes 1 number.
    /// </summary>
    public delegate Num Fun1(Num arg1);
    /// <summary>
    /// Encapsulates a function type that takes 2 numbers.
    /// </summary>
    public delegate Num Fun2(Num arg1, Num arg2);
    /// <summary>
    /// Encapsulates a function type that takes 3 numbers.
    /// </summary>
    public delegate Num Fun3(Num arg1, Num arg2, Num arg3);
    /// <summary>
    /// Encapsulates a function type that takes 4 numbers.
    /// </summary>
    public delegate Num Fun4(Num arg1, Num arg2, Num arg3, Num arg4);
    /// <summary>
    /// Encapsulates a function type that takes 5 numbers.
    /// </summary>
    public delegate Num Fun5(Num arg1, Num arg2, Num arg3, Num arg4, Num arg5);
    /// <summary>
    /// Encapsulates a function type that takes 6 numbers.
    /// </summary>
    public delegate Num Fun6(Num arg1, Num arg2, Num arg3, Num arg4, Num arg5, Num arg6);
    /// <summary>
    /// Encapsulates a function type that takes 7 numbers.
    /// </summary>
    public delegate Num Fun7(Num arg1, Num arg2, Num arg3, Num arg4, Num arg5, Num arg6, Num arg7);
    /// <summary>
    /// Encapsulates a function type that takes 8 numbers.
    /// </summary>
    public delegate Num Fun8(Num arg1, Num arg2, Num arg3, Num arg4, Num arg5, Num arg6, Num arg7, Num arg8);

    /// <summary>
    /// Encapsulates a predicate type that takes 1 number.
    /// </summary>
    public delegate bool Pred1(Num arg1);
    /// <summary>
    /// Encapsulates a predicate type that takes 2 numbers.
    /// </summary>
    public delegate bool Pred2(Num arg1, Num arg2);
    /// <summary>
    /// Encapsulates a predicate type that takes 3 numbers.
    /// </summary>
    public delegate bool Pred3(Num arg1, Num arg2, Num arg3);
    /// <summary>
    /// Encapsulates a predicate type that takes 4 numbers.
    /// </summary>
    public delegate bool Pred4(Num arg1, Num arg2, Num arg3, Num arg4);
    /// <summary>
    /// Encapsulates a predicate type that takes 5 numbers.
    /// </summary>
    public delegate bool Pred5(Num arg1, Num arg2, Num arg3, Num arg4, Num arg5);
    /// <summary>
    /// Encapsulates a predicate type that takes 6 numbers.
    /// </summary>
    public delegate bool Pred6(Num arg1, Num arg2, Num arg3, Num arg4, Num arg5, Num arg6);
    /// <summary>
    /// Encapsulates a predicate type that takes 7 numbers.
    /// </summary>
    public delegate bool Pred7(Num arg1, Num arg2, Num arg3, Num arg4, Num arg5, Num arg6, Num arg7);
    /// <summary>
    /// Encapsulates a predicate type that takes 8 numbers.
    /// </summary>
    public delegate bool Pred8(Num arg1, Num arg2, Num arg3, Num arg4, Num arg5, Num arg6, Num arg7, Num arg8);

    /// <summary>
    /// That class have methods that returns type of function or predicate by parameters count.
    /// </summary>
    public static class DelegateHelper // TODO now useless
    {
        /// <summary>
        /// Returns type of function by parameters count.
        /// </summary>
        /// <param name="parameters">Count of parameters in function type.</param>
        /// <returns>The function type that takes specified number of parameters.</returns>
        public static Type GetFunctionType(int parameters)
        {
            switch (parameters)
            {
                case 1: return typeof(Fun1);
                case 2: return typeof(Fun2);
                case 3: return typeof(Fun3);
                case 4: return typeof(Fun4);
                case 5: return typeof(Fun5);
                case 6: return typeof(Fun6);
                case 7: return typeof(Fun7);
                case 8: return typeof(Fun8);
            }
            return null;
        }
        /// <summary>
        /// Returns type of predicate by parameters count.
        /// </summary>
        /// <param name="parameters">Count of parameters in predicate type.</param>
        /// <returns>The predicate type that takes specified number of parameters.</returns>
        public static Type GetPredicateType(int parameters)
        {
            switch (parameters)
            {
                case 1: return typeof(Pred1);
                case 2: return typeof(Pred2);
                case 3: return typeof(Pred3);
                case 4: return typeof(Pred4);
                case 5: return typeof(Pred5);
                case 6: return typeof(Pred6);
                case 7: return typeof(Pred7);
                case 8: return typeof(Pred8);
            }
            return null;
        }
    }
}