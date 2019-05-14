using System;
using System.Collections.Generic;

namespace AlgorithmTheory
{
    /// <summary>
    /// The main class for encoding and decoding natural numbers using Gödel numbering.
    /// </summary>
    static public class Coder
    {
        private static uint Exp(ref Num number, Num basis)
        {
            const int len = 7;
            Num[] powers = new Num[len];
            int ipow = 0;
            powers[0] = basis;
            for (int i = 1; i < len; ++i)
            {
                var temp = powers[i - 1];
                temp *= temp * temp * temp;
                if (temp > number) break;
                ++ipow; powers[i] = temp;
            }
            uint exp = 0;
            Num divider;
            do
            {
                divider = powers[ipow];
                if ((number % divider).IsZero)
                {
                    exp += 1u << (ipow << 1);
                    number /= divider;
                }
                else --ipow;
            }
            while (ipow >= 0);
            return (exp);
        }

        /// <summary>
        /// Encode the sequence of numbers.
        /// </summary>
        /// <param name="numbers">Sequence of numbers to encode.</param>
        /// <returns>Encoded number.</returns>
        /// <remarks>
        /// To decode use <see cref="Coder.Decode(Num)"/>.
        /// </remarks>
        public static Num Encode(params Num[] numbers)
        {
            Num result = Num.One;
            int length = numbers.Length;
            for (int i = 0; i < length; i++)
                result *= Num.Pow(PrimeNumbers.GetPrimeNumber(i), numbers[i] + Num.One);
            return result;
        }

        /// <summary>
        /// Returns the exponent of <paramref name="basis"/> in the decomposition
        /// of <paramref name="number"/> into multipliers.
        /// </summary>
        /// <param name="number">Number to decomposition.</param>
        /// <param name="basis">Basis in decomposition.</param>
        /// <returns>Exponent of <paramref name="basis"/> in <paramref name="number"/> decomposition.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="number"/> is zero.</exception>
        public static Num Exponent(Num number, Num basis)
        {
            if (number.IsZero)
                throw new ArgumentException("Number is zero.", nameof(number));
            return Exp(ref number, basis);
        }

        /// <summary>
        /// Decode the <paramref name="number"/> into a sequence of numbers.
        /// </summary>
        /// <param name="number">Number to decode.</param>
        /// <returns>Decoded sequence of numbers.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="number"/> is zero
        /// or is not an encoded value.</exception>
        /// <remarks>
        /// This is the inverse function for <see cref="Coder.Encode(Num[])"/>.
        /// </remarks>
        public static Num[] Decode(Num number)
        {
            if (number.IsZero)
                throw new ArgumentException("Number is zero.", nameof(number));
            var list = new List<Num>();
            int index = 0;
            while (!number.IsOne)
            {
                var exp = Exp(ref number, PrimeNumbers.GetPrimeNumber(index++));
                if (exp == 0)
                    throw new ArgumentException("Number is not an encoded value.", nameof(number));
                list.Add(exp - Num.One);
            }
            return list.ToArray();
        }
    }
}