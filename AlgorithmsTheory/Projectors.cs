using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AlgorithmTheory
{
    /// <summary> Class that have projector functions.</summary>
    /// <remarks> Kind of initial functions.</remarks>
    static public class Projectors
    {
        /// <summary>
        /// Projector that takes 1 arguments and returns the 1st argument.
        /// </summary>
        /// <returns>The 1st argument.</returns>
        public static Num Get1Out1(Num arg1) => arg1;

        /// <summary>
        /// Projector that takes 2 arguments and returns the 1st argument.
        /// </summary>
        /// <returns>The 1st argument.</returns>
        public static Num Get2Out1(Num arg1, Num arg2) => arg1;
        /// <summary>
        /// Projector that takes 2 arguments and returns the 2nd argument.
        /// </summary>
        /// <returns>The 2nd argument.</returns>
        public static Num Get2Out2(Num arg1, Num arg2) => arg2;

        /// <summary>
        /// Projector that takes 3 arguments and returns the 1st argument.
        /// </summary>
        /// <returns>The 1st argument.</returns>
        public static Num Get3Out1(Num arg1, Num arg2, Num arg3) => arg1;
        /// <summary>
        /// Projector that takes 3 arguments and returns the 2nd argument.
        /// </summary>
        /// <returns>The 2nd argument.</returns>
        public static Num Get3Out2(Num arg1, Num arg2, Num arg3) => arg2;
        /// <summary>
        /// Projector that takes 3 arguments and returns the 3rd argument.
        /// </summary>
        /// <returns>The 3rd argument.</returns>
        public static Num Get3Out3(Num arg1, Num arg2, Num arg3) => arg3;

        /// <summary>
        /// Projector that takes 4 arguments and returns the 1st argument.
        /// </summary>
        /// <returns>The 1st argument.</returns>
        public static Num Get4Out1(Num arg1, Num arg2, Num arg3, Num arg4) => arg1;
        /// <summary>
        /// Projector that takes 4 arguments and returns the 2nd argument.
        /// </summary>
        /// <returns>The 2nd argument.</returns>
        public static Num Get4Out2(Num arg1, Num arg2, Num arg3, Num arg4) => arg2;
        /// <summary>
        /// Projector that takes 4 arguments and returns the 3rd argument.
        /// </summary>
        /// <returns>The 3rd argument.</returns>
        public static Num Get4Out3(Num arg1, Num arg2, Num arg3, Num arg4) => arg3;
        /// <summary>
        /// Projector that takes 4 arguments and returns the 4th argument.
        /// </summary>
        /// <returns>The 4th argument.</returns>
        public static Num Get4Out4(Num arg1, Num arg2, Num arg3, Num arg4) => arg4;

        /// <summary>
        /// Projector that takes 5 arguments and returns the 1st argument.
        /// </summary>
        /// <returns>The 1st argument.</returns>
        public static Num Get5Out1(Num arg1, Num arg2, Num arg3, Num arg4, Num arg5) => arg1;
        /// <summary>
        /// Projector that takes 5 arguments and returns the 2nd argument.
        /// </summary>
        /// <returns>The 2nd argument.</returns>
        public static Num Get5Out2(Num arg1, Num arg2, Num arg3, Num arg4, Num arg5) => arg2;
        /// <summary>
        /// Projector that takes 5 arguments and returns the 3rd argument.
        /// </summary>
        /// <returns>The 3rd argument.</returns>
        public static Num Get5Out3(Num arg1, Num arg2, Num arg3, Num arg4, Num arg5) => arg3;
        /// <summary>
        /// Projector that takes 5 arguments and returns the 4th argument.
        /// </summary>
        /// <returns>The 4th argument.</returns>
        public static Num Get5Out4(Num arg1, Num arg2, Num arg3, Num arg4, Num arg5) => arg4;
        /// <summary>
        /// Projector that takes 5 arguments and returns the 5th argument.
        /// </summary>
        /// <returns>The 5th argument.</returns>
        public static Num Get5Out5(Num arg1, Num arg2, Num arg3, Num arg4, Num arg5) => arg5;

        /// <summary>
        /// Projector that takes 6 arguments and returns the 1st argument.
        /// </summary>
        /// <returns>The 1st argument.</returns>
        public static Num Get6Out1(Num arg1, Num arg2, Num arg3, Num arg4, Num arg5, Num arg6) => arg1;
        /// <summary>
        /// Projector that takes 6 arguments and returns the 2nd argument.
        /// </summary>
        /// <returns>The 2nd argument.</returns>
        public static Num Get6Out2(Num arg1, Num arg2, Num arg3, Num arg4, Num arg5, Num arg6) => arg2;
        /// <summary>
        /// Projector that takes 6 arguments and returns the 3rd argument.
        /// </summary>
        /// <returns>The 3rd argument.</returns>
        public static Num Get6Out3(Num arg1, Num arg2, Num arg3, Num arg4, Num arg5, Num arg6) => arg3;
        /// <summary>
        /// Projector that takes 6 arguments and returns the 4th argument.
        /// </summary>
        /// <returns>The 4th argument.</returns>
        public static Num Get6Out4(Num arg1, Num arg2, Num arg3, Num arg4, Num arg5, Num arg6) => arg4;
        /// <summary>
        /// Projector that takes 6 arguments and returns the 5th argument.
        /// </summary>
        /// <returns>The 5th argument.</returns>
        public static Num Get6Out5(Num arg1, Num arg2, Num arg3, Num arg4, Num arg5, Num arg6) => arg5;
        /// <summary>
        /// Projector that takes 6 arguments and returns the 6th argument.
        /// </summary>
        /// <returns>The 6th argument.</returns>
        public static Num Get6Out6(Num arg1, Num arg2, Num arg3, Num arg4, Num arg5, Num arg6) => arg6;

        /// <summary>
        /// Projector that takes 7 arguments and returns the 1st argument.
        /// </summary>
        /// <returns>The 1st argument.</returns>
        public static Num Get7Out1(Num arg1, Num arg2, Num arg3, Num arg4, Num arg5, Num arg6, Num arg7) => arg1;
        /// <summary>
        /// Projector that takes 7 arguments and returns the 2nd argument.
        /// </summary>
        /// <returns>The 2nd argument.</returns>
        public static Num Get7Out2(Num arg1, Num arg2, Num arg3, Num arg4, Num arg5, Num arg6, Num arg7) => arg2;
        /// <summary>
        /// Projector that takes 7 arguments and returns the 3rd argument.
        /// </summary>
        /// <returns>The 3rd argument.</returns>
        public static Num Get7Out3(Num arg1, Num arg2, Num arg3, Num arg4, Num arg5, Num arg6, Num arg7) => arg3;
        /// <summary>
        /// Projector that takes 7 arguments and returns the 4th argument.
        /// </summary>
        /// <returns>The 4th argument.</returns>
        public static Num Get7Out4(Num arg1, Num arg2, Num arg3, Num arg4, Num arg5, Num arg6, Num arg7) => arg4;
        /// <summary>
        /// Projector that takes 7 arguments and returns the 5th argument.
        /// </summary>
        /// <returns>The 5th argument.</returns>
        public static Num Get7Out5(Num arg1, Num arg2, Num arg3, Num arg4, Num arg5, Num arg6, Num arg7) => arg5;
        /// <summary>
        /// Projector that takes 7 arguments and returns the 6th argument.
        /// </summary>
        /// <returns>The 6th argument.</returns>
        public static Num Get7Out6(Num arg1, Num arg2, Num arg3, Num arg4, Num arg5, Num arg6, Num arg7) => arg6;
        /// <summary>
        /// Projector that takes 7 arguments and returns the 7th argument.
        /// </summary>
        /// <returns>The 7th argument.</returns>
        public static Num Get7Out7(Num arg1, Num arg2, Num arg3, Num arg4, Num arg5, Num arg6, Num arg7) => arg7;

        /// <summary>
        /// Projector that takes 8 arguments and returns the 1st argument.
        /// </summary>
        /// <returns>The 1st argument.</returns>
        public static Num Get8Out1(Num arg1, Num arg2, Num arg3, Num arg4, Num arg5, Num arg6, Num arg7, Num arg8) => arg1;
        /// <summary>
        /// Projector that takes 8 arguments and returns the 2nd argument.
        /// </summary>
        /// <returns>The 2nd argument.</returns>
        public static Num Get8Out2(Num arg1, Num arg2, Num arg3, Num arg4, Num arg5, Num arg6, Num arg7, Num arg8) => arg2;
        /// <summary>
        /// Projector that takes 8 arguments and returns the 3rd argument.
        /// </summary>
        /// <returns>The 3rd argument.</returns>
        public static Num Get8Out3(Num arg1, Num arg2, Num arg3, Num arg4, Num arg5, Num arg6, Num arg7, Num arg8) => arg3;
        /// <summary>
        /// Projector that takes 8 arguments and returns the 4th argument.
        /// </summary>
        /// <returns>The 4th argument.</returns>
        public static Num Get8Out4(Num arg1, Num arg2, Num arg3, Num arg4, Num arg5, Num arg6, Num arg7, Num arg8) => arg4;
        /// <summary>
        /// Projector that takes 8 arguments and returns the 5th argument.
        /// </summary>
        /// <returns>The 5th argument.</returns>
        public static Num Get8Out5(Num arg1, Num arg2, Num arg3, Num arg4, Num arg5, Num arg6, Num arg7, Num arg8) => arg5;
        /// <summary>
        /// Projector that takes 8 arguments and returns the 6th argument.
        /// </summary>
        /// <returns>The 6th argument.</returns>
        public static Num Get8Out6(Num arg1, Num arg2, Num arg3, Num arg4, Num arg5, Num arg6, Num arg7, Num arg8) => arg6;
        /// <summary>
        /// Projector that takes 8 arguments and returns the 7th argument.
        /// </summary>
        /// <returns>The 7th argument.</returns>
        public static Num Get8Out7(Num arg1, Num arg2, Num arg3, Num arg4, Num arg5, Num arg6, Num arg7, Num arg8) => arg7;
        /// <summary>
        /// Projector that takes 8 arguments and returns the 8th argument.
        /// </summary>
        /// <returns>The 8th argument.</returns>
        public static Num Get8Out8(Num arg1, Num arg2, Num arg3, Num arg4, Num arg5, Num arg6, Num arg7, Num arg8) => arg8;

        private static int Hash(int a, int b) => (a << 16) | (b & 0xFFFF);

        private static readonly Dictionary<int, Delegate> projectors;

        static Projectors()
        {
            projectors = new Dictionary<int, Delegate>()
            {
                [Hash(1, 1)] = (Fun1)Get1Out1,
                [Hash(2, 1)] = (Fun2)Get2Out1,
                [Hash(2, 2)] = (Fun2)Get2Out2,
                [Hash(3, 1)] = (Fun3)Get3Out1,
                [Hash(3, 2)] = (Fun3)Get3Out2,
                [Hash(3, 3)] = (Fun3)Get3Out3,
                [Hash(4, 1)] = (Fun4)Get4Out1,
                [Hash(4, 2)] = (Fun4)Get4Out2,
                [Hash(4, 3)] = (Fun4)Get4Out3,
                [Hash(4, 4)] = (Fun4)Get4Out4,
                [Hash(5, 1)] = (Fun5)Get5Out1,
                [Hash(5, 2)] = (Fun5)Get5Out2,
                [Hash(5, 3)] = (Fun5)Get5Out3,
                [Hash(5, 4)] = (Fun5)Get5Out4,
                [Hash(5, 5)] = (Fun5)Get5Out5,
                [Hash(6, 1)] = (Fun6)Get6Out1,
                [Hash(6, 2)] = (Fun6)Get6Out2,
                [Hash(6, 3)] = (Fun6)Get6Out3,
                [Hash(6, 4)] = (Fun6)Get6Out4,
                [Hash(6, 5)] = (Fun6)Get6Out5,
                [Hash(6, 6)] = (Fun6)Get6Out6,
                [Hash(7, 1)] = (Fun7)Get7Out1,
                [Hash(7, 2)] = (Fun7)Get7Out2,
                [Hash(7, 3)] = (Fun7)Get7Out3,
                [Hash(7, 4)] = (Fun7)Get7Out4,
                [Hash(7, 5)] = (Fun7)Get7Out5,
                [Hash(7, 6)] = (Fun7)Get7Out6,
                [Hash(7, 7)] = (Fun7)Get7Out7,
                [Hash(8, 1)] = (Fun8)Get8Out1,
                [Hash(8, 2)] = (Fun8)Get8Out2,
                [Hash(8, 3)] = (Fun8)Get8Out3,
                [Hash(8, 4)] = (Fun8)Get8Out4,
                [Hash(8, 5)] = (Fun8)Get8Out5,
                [Hash(8, 6)] = (Fun8)Get8Out6,
                [Hash(8, 7)] = (Fun8)Get8Out7,
                [Hash(8, 8)] = (Fun8)Get8Out8,
            };
        }

        /// <summary>
        /// Return projector-function by specified numbers.
        /// </summary>
        /// <param name="input">Count of function arguments.</param>
        /// <param name="output">Number of return argument.</param>
        /// <returns>Projector-function that take '<paramref name="input"/>'
        /// arguments anf return '<paramref name="output"/>' argument.</returns>
        /// <remarks>Compile new projector if it dose not exist now.</remarks>
        /// <exception cref="ArgumentException">
        /// <para>If input or output number less than one.</para>
        /// <para>If index of return argument greater than argument count.</para>
        /// </exception>
        public static Delegate CreateProjector(int input, int output)
        {
            if (output > input)
                throw new ArgumentException(
                    "Output index can't be greater then argument count.", nameof(output));
            if (output < 1)
                throw new ArgumentException(
                    "Output index can't be less than one.", nameof(output));
            if (input < 1)
                throw new ArgumentException(
                    "Argmunent count must be positive.", nameof(input));

            int hash = Hash(input, output);
            if (projectors.ContainsKey(hash))
                return projectors[hash];

            ParameterExpression[] args = new ParameterExpression[input];
            for (int i = 0; i < input; ++i)
                args[i] = Expression.Parameter(typeof(Num), "arg" + (1 + i));

            LambdaExpression lambda = Expression.Lambda(
                body: args[output - 1],
                name: $"Get{input}Out{output}",
                parameters: args);

            Delegate projector = lambda.Compile();
            projectors[hash] = projector;
            return projector;
        }
    }
}