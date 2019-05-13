using AlgorithmTheory.CreatingDelegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using num = System.Numerics.BigInteger;

namespace AlgorithmTheory
{
#pragma warning disable IDE1006 // Стили именования
    public static class Primitives
    {
        /// <summary>
        /// Нульфункция
        /// </summary>
        /// <param name="x">parameter</param>
        /// <returns>zero</returns>
        public static Num Zero(Num x) => Num.Zero;
        /// <summary>
        /// Функция следования
        /// </summary>
        /// <param name="x">parameter</param>
        /// <returns>x+1</returns>
        public static Num Succ(Num x) => x + Num.One;

        /// <summary>
        /// Zero-function
        /// </summary>
        public static Fun1 Z { get; } = Zero;
        /// <summary>
        /// Succession-function
        /// </summary>
        public static Fun1 S { get; } = Succ;

        #region Projectors
        public static Fun1 P_1_1 { get; } = Projectors.Get1Out1;
        public static Fun2 P_2_1 { get; } = Projectors.Get2Out1;
        public static Fun2 P_2_2 { get; } = Projectors.Get2Out2;
        public static Fun3 P_3_1 { get; } = Projectors.Get3Out1;
        public static Fun3 P_3_2 { get; } = Projectors.Get3Out2;
        public static Fun3 P_3_3 { get; } = Projectors.Get3Out3;
        public static Fun4 P_4_1 { get; } = Projectors.Get4Out1;
        public static Fun4 P_4_2 { get; } = Projectors.Get4Out2;
        public static Fun4 P_4_3 { get; } = Projectors.Get4Out3;
        public static Fun4 P_4_4 { get; } = Projectors.Get4Out4;
        public static Fun5 P_5_1 { get; } = Projectors.Get5Out1;
        public static Fun5 P_5_2 { get; } = Projectors.Get5Out2;
        public static Fun5 P_5_3 { get; } = Projectors.Get5Out3;
        public static Fun5 P_5_4 { get; } = Projectors.Get5Out4;
        public static Fun5 P_5_5 { get; } = Projectors.Get5Out5;
        public static Fun6 P_6_1 { get; } = Projectors.Get6Out1;
        public static Fun6 P_6_2 { get; } = Projectors.Get6Out2;
        public static Fun6 P_6_3 { get; } = Projectors.Get6Out3;
        public static Fun6 P_6_4 { get; } = Projectors.Get6Out4;
        public static Fun6 P_6_5 { get; } = Projectors.Get6Out5;
        public static Fun6 P_6_6 { get; } = Projectors.Get6Out6;
        public static Fun7 P_7_1 { get; } = Projectors.Get7Out1;
        public static Fun7 P_7_2 { get; } = Projectors.Get7Out2;
        public static Fun7 P_7_3 { get; } = Projectors.Get7Out3;
        public static Fun7 P_7_4 { get; } = Projectors.Get7Out4;
        public static Fun7 P_7_5 { get; } = Projectors.Get7Out5;
        public static Fun7 P_7_6 { get; } = Projectors.Get7Out6;
        public static Fun7 P_7_7 { get; } = Projectors.Get7Out7;
        public static Fun8 P_8_1 { get; } = Projectors.Get8Out1;
        public static Fun8 P_8_2 { get; } = Projectors.Get8Out2;
        public static Fun8 P_8_3 { get; } = Projectors.Get8Out3;
        public static Fun8 P_8_4 { get; } = Projectors.Get8Out4;
        public static Fun8 P_8_5 { get; } = Projectors.Get8Out5;
        public static Fun8 P_8_6 { get; } = Projectors.Get8Out6;
        public static Fun8 P_8_7 { get; } = Projectors.Get8Out7;
        public static Fun8 P_8_8 { get; } = Projectors.Get8Out8;
        #endregion

        public static Fun1 P { get; } = PrimeNumbers.GetPrimeNumber;

        public static Num enc(params Num[] numbers) => Coder.Encode(numbers);

        public static Num[] dec(Num num) => Coder.Decode(num);

        #region comp

        #region comp(Fun1,...)
        public static Fun1 comp(Fun1 ext, Fun1 in1)
        => CompositionCreator.Compose<Fun1>(ext, in1);
        public static Fun2 comp(Fun1 ext, Fun2 in1)
        => CompositionCreator.Compose<Fun2>(ext, in1);
        public static Fun3 comp(Fun1 ext, Fun3 in1)
        => CompositionCreator.Compose<Fun3>(ext, in1);
        public static Fun4 comp(Fun1 ext, Fun4 in1)
        => CompositionCreator.Compose<Fun4>(ext, in1);
        public static Fun5 comp(Fun1 ext, Fun5 in1)
        => CompositionCreator.Compose<Fun5>(ext, in1);
        public static Fun6 comp(Fun1 ext, Fun6 in1)
        => CompositionCreator.Compose<Fun6>(ext, in1);
        public static Fun7 comp(Fun1 ext, Fun7 in1)
        => CompositionCreator.Compose<Fun7>(ext, in1);
        public static Fun8 comp(Fun1 ext, Fun8 in1)
        => CompositionCreator.Compose<Fun8>(ext, in1);
        #endregion

        #region comp(Fun2,...)
        public static Fun1 comp(Fun2 ext, Fun1 in1, Fun1 in2)
        => CompositionCreator.Compose<Fun1>(ext, in1, in2);
        public static Fun2 comp(Fun2 ext, Fun2 in1, Fun2 in2)
        => CompositionCreator.Compose<Fun2>(ext, in1, in2);
        public static Fun3 comp(Fun2 ext, Fun3 in1, Fun3 in2)
        => CompositionCreator.Compose<Fun3>(ext, in1, in2);
        public static Fun4 comp(Fun2 ext, Fun4 in1, Fun4 in2)
        => CompositionCreator.Compose<Fun4>(ext, in1, in2);
        public static Fun5 comp(Fun2 ext, Fun5 in1, Fun5 in2)
        => CompositionCreator.Compose<Fun5>(ext, in1, in2);
        public static Fun6 comp(Fun2 ext, Fun6 in1, Fun6 in2)
        => CompositionCreator.Compose<Fun6>(ext, in1, in2);
        public static Fun7 comp(Fun2 ext, Fun7 in1, Fun7 in2)
        => CompositionCreator.Compose<Fun7>(ext, in1, in2);
        public static Fun8 comp(Fun2 ext, Fun8 in1, Fun8 in2)
        => CompositionCreator.Compose<Fun8>(ext, in1, in2);
        #endregion

        #region comp(Fun3,...)
        public static Fun1 comp(Fun3 ext, Fun1 in1, Fun1 in2, Fun1 in3)
        => CompositionCreator.Compose<Fun1>(ext, in1, in2, in3);
        public static Fun2 comp(Fun3 ext, Fun2 in1, Fun2 in2, Fun2 in3)
        => CompositionCreator.Compose<Fun2>(ext, in1, in2, in3);
        public static Fun3 comp(Fun3 ext, Fun3 in1, Fun3 in2, Fun3 in3)
        => CompositionCreator.Compose<Fun3>(ext, in1, in2, in3);
        public static Fun4 comp(Fun3 ext, Fun4 in1, Fun4 in2, Fun4 in3)
        => CompositionCreator.Compose<Fun4>(ext, in1, in2, in3);
        public static Fun5 comp(Fun3 ext, Fun5 in1, Fun5 in2, Fun5 in3)
        => CompositionCreator.Compose<Fun5>(ext, in1, in2, in3);
        public static Fun6 comp(Fun3 ext, Fun6 in1, Fun6 in2, Fun6 in3)
        => CompositionCreator.Compose<Fun6>(ext, in1, in2, in3);
        public static Fun7 comp(Fun3 ext, Fun7 in1, Fun7 in2, Fun7 in3)
        => CompositionCreator.Compose<Fun7>(ext, in1, in2, in3);
        public static Fun8 comp(Fun3 ext, Fun8 in1, Fun8 in2, Fun8 in3)
        => CompositionCreator.Compose<Fun8>(ext, in1, in2, in3);
        #endregion

        #region comp(Fun4,...)
        public static Fun1 comp(Fun4 ext, Fun1 in1, Fun1 in2, Fun1 in3, Fun1 in4)
        => CompositionCreator.Compose<Fun1>(ext, in1, in2, in3, in4);
        public static Fun2 comp(Fun4 ext, Fun2 in1, Fun2 in2, Fun2 in3, Fun2 in4)
        => CompositionCreator.Compose<Fun2>(ext, in1, in2, in3, in4);
        public static Fun3 comp(Fun4 ext, Fun3 in1, Fun3 in2, Fun3 in3, Fun3 in4)
        => CompositionCreator.Compose<Fun3>(ext, in1, in2, in3, in4);
        public static Fun4 comp(Fun4 ext, Fun4 in1, Fun4 in2, Fun4 in3, Fun4 in4)
        => CompositionCreator.Compose<Fun4>(ext, in1, in2, in3, in4);
        public static Fun5 comp(Fun4 ext, Fun5 in1, Fun5 in2, Fun5 in3, Fun5 in4)
        => CompositionCreator.Compose<Fun5>(ext, in1, in2, in3, in4);
        public static Fun6 comp(Fun4 ext, Fun6 in1, Fun6 in2, Fun6 in3, Fun6 in4)
        => CompositionCreator.Compose<Fun6>(ext, in1, in2, in3, in4);
        public static Fun7 comp(Fun4 ext, Fun7 in1, Fun7 in2, Fun7 in3, Fun7 in4)
        => CompositionCreator.Compose<Fun7>(ext, in1, in2, in3, in4);
        public static Fun8 comp(Fun4 ext, Fun8 in1, Fun8 in2, Fun8 in3, Fun8 in4)
        => CompositionCreator.Compose<Fun8>(ext, in1, in2, in3, in4);
        #endregion

        #region comp(Fun5,...)
        public static Fun1 comp(Fun5 ext, Fun1 in1, Fun1 in2, Fun1 in3, Fun1 in4, Fun1 in5)
        => CompositionCreator.Compose<Fun1>(ext, in1, in2, in3, in4, in5);
        public static Fun2 comp(Fun5 ext, Fun2 in1, Fun2 in2, Fun2 in3, Fun2 in4, Fun2 in5)
        => CompositionCreator.Compose<Fun2>(ext, in1, in2, in3, in4, in5);
        public static Fun3 comp(Fun5 ext, Fun3 in1, Fun3 in2, Fun3 in3, Fun3 in4, Fun3 in5)
        => CompositionCreator.Compose<Fun3>(ext, in1, in2, in3, in4, in5);
        public static Fun4 comp(Fun5 ext, Fun4 in1, Fun4 in2, Fun4 in3, Fun4 in4, Fun4 in5)
        => CompositionCreator.Compose<Fun4>(ext, in1, in2, in3, in4, in5);
        public static Fun5 comp(Fun5 ext, Fun5 in1, Fun5 in2, Fun5 in3, Fun5 in4, Fun5 in5)
        => CompositionCreator.Compose<Fun5>(ext, in1, in2, in3, in4, in5);
        public static Fun6 comp(Fun5 ext, Fun6 in1, Fun6 in2, Fun6 in3, Fun6 in4, Fun6 in5)
        => CompositionCreator.Compose<Fun6>(ext, in1, in2, in3, in4, in5);
        public static Fun7 comp(Fun5 ext, Fun7 in1, Fun7 in2, Fun7 in3, Fun7 in4, Fun7 in5)
        => CompositionCreator.Compose<Fun7>(ext, in1, in2, in3, in4, in5);
        public static Fun8 comp(Fun5 ext, Fun8 in1, Fun8 in2, Fun8 in3, Fun8 in4, Fun8 in5)
        => CompositionCreator.Compose<Fun8>(ext, in1, in2, in3, in4, in5);
        #endregion

        #region comp(Fun6,...)
        public static Fun1 comp(Fun6 ext, Fun1 in1, Fun1 in2, Fun1 in3, Fun1 in4, Fun1 in5, Fun1 in6)
        => CompositionCreator.Compose<Fun1>(ext, in1, in2, in3, in4, in5, in6);
        public static Fun2 comp(Fun6 ext, Fun2 in1, Fun2 in2, Fun2 in3, Fun2 in4, Fun2 in5, Fun2 in6)
        => CompositionCreator.Compose<Fun2>(ext, in1, in2, in3, in4, in5, in6);
        public static Fun3 comp(Fun6 ext, Fun3 in1, Fun3 in2, Fun3 in3, Fun3 in4, Fun3 in5, Fun3 in6)
        => CompositionCreator.Compose<Fun3>(ext, in1, in2, in3, in4, in5, in6);
        public static Fun4 comp(Fun6 ext, Fun4 in1, Fun4 in2, Fun4 in3, Fun4 in4, Fun4 in5, Fun4 in6)
        => CompositionCreator.Compose<Fun4>(ext, in1, in2, in3, in4, in5, in6);
        public static Fun5 comp(Fun6 ext, Fun5 in1, Fun5 in2, Fun5 in3, Fun5 in4, Fun5 in5, Fun5 in6)
        => CompositionCreator.Compose<Fun5>(ext, in1, in2, in3, in4, in5, in6);
        public static Fun6 comp(Fun6 ext, Fun6 in1, Fun6 in2, Fun6 in3, Fun6 in4, Fun6 in5, Fun6 in6)
        => CompositionCreator.Compose<Fun6>(ext, in1, in2, in3, in4, in5, in6);
        public static Fun7 comp(Fun6 ext, Fun7 in1, Fun7 in2, Fun7 in3, Fun7 in4, Fun7 in5, Fun7 in6)
        => CompositionCreator.Compose<Fun7>(ext, in1, in2, in3, in4, in5, in6);
        public static Fun8 comp(Fun6 ext, Fun8 in1, Fun8 in2, Fun8 in3, Fun8 in4, Fun8 in5, Fun8 in6)
        => CompositionCreator.Compose<Fun8>(ext, in1, in2, in3, in4, in5, in6);
        #endregion

        #region comp(Fun7,...)
        public static Fun1 comp(Fun7 ext, Fun1 in1, Fun1 in2, Fun1 in3, Fun1 in4, Fun1 in5, Fun1 in6, Fun1 in7)
        => CompositionCreator.Compose<Fun1>(ext, in1, in2, in3, in4, in5, in6, in7);
        public static Fun2 comp(Fun7 ext, Fun2 in1, Fun2 in2, Fun2 in3, Fun2 in4, Fun2 in5, Fun2 in6, Fun2 in7)
        => CompositionCreator.Compose<Fun2>(ext, in1, in2, in3, in4, in5, in6, in7);
        public static Fun3 comp(Fun7 ext, Fun3 in1, Fun3 in2, Fun3 in3, Fun3 in4, Fun3 in5, Fun3 in6, Fun3 in7)
        => CompositionCreator.Compose<Fun3>(ext, in1, in2, in3, in4, in5, in6, in7);
        public static Fun4 comp(Fun7 ext, Fun4 in1, Fun4 in2, Fun4 in3, Fun4 in4, Fun4 in5, Fun4 in6, Fun4 in7)
        => CompositionCreator.Compose<Fun4>(ext, in1, in2, in3, in4, in5, in6, in7);
        public static Fun5 comp(Fun7 ext, Fun5 in1, Fun5 in2, Fun5 in3, Fun5 in4, Fun5 in5, Fun5 in6, Fun5 in7)
        => CompositionCreator.Compose<Fun5>(ext, in1, in2, in3, in4, in5, in6, in7);
        public static Fun6 comp(Fun7 ext, Fun6 in1, Fun6 in2, Fun6 in3, Fun6 in4, Fun6 in5, Fun6 in6, Fun6 in7)
        => CompositionCreator.Compose<Fun6>(ext, in1, in2, in3, in4, in5, in6, in7);
        public static Fun7 comp(Fun7 ext, Fun7 in1, Fun7 in2, Fun7 in3, Fun7 in4, Fun7 in5, Fun7 in6, Fun7 in7)
        => CompositionCreator.Compose<Fun7>(ext, in1, in2, in3, in4, in5, in6, in7);
        public static Fun8 comp(Fun7 ext, Fun8 in1, Fun8 in2, Fun8 in3, Fun8 in4, Fun8 in5, Fun8 in6, Fun8 in7)
        => CompositionCreator.Compose<Fun8>(ext, in1, in2, in3, in4, in5, in6, in7);
        #endregion

        #region comp(Fun8,...)
        public static Fun1 comp(Fun8 ext, Fun1 in1, Fun1 in2, Fun1 in3, Fun1 in4, Fun1 in5, Fun1 in6, Fun1 in7, Fun1 in8)
        => CompositionCreator.Compose<Fun1>(ext, in1, in2, in3, in4, in5, in6, in7, in8);
        public static Fun2 comp(Fun8 ext, Fun2 in1, Fun2 in2, Fun2 in3, Fun2 in4, Fun2 in5, Fun2 in6, Fun2 in7, Fun2 in8)
        => CompositionCreator.Compose<Fun2>(ext, in1, in2, in3, in4, in5, in6, in7, in8);
        public static Fun3 comp(Fun8 ext, Fun3 in1, Fun3 in2, Fun3 in3, Fun3 in4, Fun3 in5, Fun3 in6, Fun3 in7, Fun3 in8)
        => CompositionCreator.Compose<Fun3>(ext, in1, in2, in3, in4, in5, in6, in7, in8);
        public static Fun4 comp(Fun8 ext, Fun4 in1, Fun4 in2, Fun4 in3, Fun4 in4, Fun4 in5, Fun4 in6, Fun4 in7, Fun4 in8)
        => CompositionCreator.Compose<Fun4>(ext, in1, in2, in3, in4, in5, in6, in7, in8);
        public static Fun5 comp(Fun8 ext, Fun5 in1, Fun5 in2, Fun5 in3, Fun5 in4, Fun5 in5, Fun5 in6, Fun5 in7, Fun5 in8)
        => CompositionCreator.Compose<Fun5>(ext, in1, in2, in3, in4, in5, in6, in7, in8);
        public static Fun6 comp(Fun8 ext, Fun6 in1, Fun6 in2, Fun6 in3, Fun6 in4, Fun6 in5, Fun6 in6, Fun6 in7, Fun6 in8)
        => CompositionCreator.Compose<Fun6>(ext, in1, in2, in3, in4, in5, in6, in7, in8);
        public static Fun7 comp(Fun8 ext, Fun7 in1, Fun7 in2, Fun7 in3, Fun7 in4, Fun7 in5, Fun7 in6, Fun7 in7, Fun7 in8)
        => CompositionCreator.Compose<Fun7>(ext, in1, in2, in3, in4, in5, in6, in7, in8);
        public static Fun8 comp(Fun8 ext, Fun8 in1, Fun8 in2, Fun8 in3, Fun8 in4, Fun8 in5, Fun8 in6, Fun8 in7, Fun8 in8)
        => CompositionCreator.Compose<Fun8>(ext, in1, in2, in3, in4, in5, in6, in7, in8);
        #endregion

        #endregion

        #region prim

        private static readonly RecursionCreator<Num> recursion = new RecursionCreator<Num>(Num.Zero, Num.One);

        public static Fun2 prim(Fun1 fun1, Fun3 fun3)
            => recursion.PrimitiveRecursion<Fun2>(fun1, fun3);

        public static Fun3 prim(Fun2 fun2, Fun4 fun4)
            => recursion.PrimitiveRecursion<Fun3>(fun2, fun4);

        public static Fun4 prim(Fun3 fun3, Fun5 fun5)
            => recursion.PrimitiveRecursion<Fun4>(fun3, fun5);

        public static Fun5 prim(Fun4 fun4, Fun6 fun6)
            => recursion.PrimitiveRecursion<Fun5>(fun4, fun6);

        public static Fun6 prim(Fun5 fun5, Fun7 fun7)
            => recursion.PrimitiveRecursion<Fun6>(fun5, fun7);

        public static Fun7 prim(Fun6 fun6, Fun8 fun8)
            => recursion.PrimitiveRecursion<Fun7>(fun6, fun8);

        #endregion

    }
#pragma warning restore IDE1006 // Стили именования
}