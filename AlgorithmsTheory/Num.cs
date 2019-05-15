using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Numerics;
using System.Text;

namespace AlgorithmTheory
{
    /// <summary>
    /// Structure describing large natural numbers.
    /// </summary>
    /// <remarks>
    /// Includes zero and excludes negative numbers.
    /// </remarks>
    public struct Num : IFormattable, IComparable, IComparable<Num>, IEquatable<Num>
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private BigInteger self;

        #region readonly constants

        /// <summary>
        /// Constant value for zero.
        /// </summary>
        public static Num Zero { get; } = new Num() { self = new BigInteger(0) };

        /// <summary>
        /// Constant value for one.
        /// </summary>
        public static Num One { get; } = new Num() { self = new BigInteger(1) };

        /// <summary>
        /// Constant value for two.
        /// </summary>
        public static Num Two { get; } = new Num() { self = new BigInteger(2) };

        /// <summary>
        /// Constant value for ten.
        /// </summary>
        public static Num Ten { get; } = new Num() { self = new BigInteger(10) };

        #endregion

#if DEBUG
        /// <summary>
        /// Nothing...
        /// </summary>
        public static int BIctor = 0, INTctor = 0, UINTctor = 0;
#endif

        #region constructors

        /// <summary>
        /// Create new <see cref="Num"/> using <see cref="BigInteger"/> value.
        /// </summary>
        /// <param name="value">
        /// <see cref="BigInteger"/> value to create new <see cref="Num"/>.
        /// </param>
        public Num(BigInteger value)
        {
            self = value < 0 ? 0 : value;
#if DEBUG
            BIctor++;
            Debug.WriteLine("new num(BIG) with {0}", value);
#endif
        }

        /// <summary>
        /// Create new <see cref="Num"/> using <see cref="int"/> value.
        /// </summary>
        /// <param name="value">
        /// <see cref="int"/> value to create new <see cref="Num"/>.
        /// </param>
        public Num(int value)
        {
            self = new BigInteger(value < 0 ? 0 : value);
#if DEBUG
            INTctor++;
            Debug.WriteLine("new num(INT) with {0}", value);
#endif
        }

        /// <summary>
        /// Create new <see cref="Num"/> using <see cref="uint"/> value.
        /// </summary>
        /// <param name="value">
        /// <see cref="uint"/> value to create new <see cref="Num"/>.
        /// </param>
        public Num(uint value)
        {
            self = new BigInteger(value);
#if DEBUG
            UINTctor++;
            Debug.WriteLine("new num(UINT) with {0}", value);
#endif
        }

        /// <summary>
        /// Create new <see cref="Num"/> using <see cref="long"/> value.
        /// </summary>
        /// <param name="value">
        /// <see cref="long"/> value to create new <see cref="Num"/>.
        /// </param>
        public Num(long value)
        {
            self = new BigInteger(value < 0 ? 0 : value);
        }

        /// <summary>
        /// Create new <see cref="Num"/> using <see cref="ulong"/> value.
        /// </summary>
        /// <param name="value">
        /// <see cref="ulong"/> value to create new <see cref="Num"/>.
        /// </param>
        public Num(ulong value)
        {
            self = new BigInteger(value);
        }

        #endregion

        #region operators

        #region arithmetic

        /// <summary>
        /// The operator of addition of two Num values.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>Result of addition.</returns>
        static public Num operator +(Num left, Num right) => new Num { self = left.self + right.self };

        /// <summary>
        /// The operator of multiplication of two Num values.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>Result of multiplication.</returns>
        static public Num operator *(Num left, Num right) => new Num { self = left.self * right.self };

        /// <summary>
        /// The operator of division of two Num values.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>Result of division.</returns>
        static public Num operator /(Num left, Num right) => new Num { self = left.self / right.self };

        /// <summary>
        /// The operator of modulus of two Num values.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>Result of modulus.</returns>
        static public Num operator %(Num left, Num right) => new Num { self = left.self % right.self };

        /// <summary>
        /// The operator of subtraction of two Num values.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>Result of subtraction.</returns>
        static public Num operator -(Num left, Num right) => new Num(left.self - right.self);

        #endregion

        #region unary

        /// <summary>
        /// Increment operator.
        /// </summary>
        /// <param name="value">Value to increment.</param>
        /// <returns>Incremented value.</returns>
        static public Num operator ++(Num value) => new Num { self = value.self + BigInteger.One };

        /// <summary>
        /// Decrement operator.
        /// </summary>
        /// <param name="value">Value to decrement.</param>
        /// <returns>Decremented value.</returns>
        static public Num operator --(Num value) => new Num(value.self - BigInteger.One);
        #endregion

        #region logic

        /// <summary>
        /// The operator of equal of two Num values.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>Result of equal.</returns>
        static public bool operator ==(Num left, Num right) => (left.self == right.self);

        /// <summary>
        /// The operator of not equal of two Num values.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>Result of not equal.</returns>
        static public bool operator !=(Num left, Num right) => (left.self != right.self);

        /// <summary>
        /// The operator of less or equal of two Num values.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>Result of less or equal.</returns>
        static public bool operator <=(Num left, Num right) => (left.self <= right.self);

        /// <summary>
        /// The operator of greater or equal of two Num values.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>Result of greater or equal.</returns>
        static public bool operator >=(Num left, Num right) => (left.self >= right.self);

        /// <summary>
        /// The operator of less of two Num values.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>Result of less.</returns>
        static public bool operator <(Num left, Num right) => (left.self < right.self);

        /// <summary>
        /// The operator of greater of two Num values.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>Result of greater.</returns>
        static public bool operator >(Num left, Num right) => (left.self > right.self);

        #endregion

        #region converting

        /// <summary>
        /// Defines an explicit conversion to <see cref="int"/>.
        /// </summary>
        /// <param name="value">
        /// Value to convert to <see cref="int"/>.
        /// </param>
        static public explicit operator int(Num value) => (int)value.self;

        /// <summary>
        /// Defines an explicit conversion to <see cref="uint"/>.
        /// </summary>
        /// <param name="value">
        /// Value to convert to <see cref="uint"/>.
        /// </param>
        static public explicit operator uint(Num value) => (uint)value.self;

        /// <summary>
        /// Defines an explicit conversion to <see cref="long"/>.
        /// </summary>
        /// <param name="value">
        /// Value to convert to <see cref="long"/>.
        /// </param>
        static public explicit operator long(Num value) => (long)value.self;

        /// <summary>
        /// Defines an explicit conversion to <see cref="ulong"/>.
        /// </summary>
        /// <param name="value">
        /// Value to convert to <see cref="ulong"/>.
        /// </param>
        static public explicit operator ulong(Num value) => (ulong)value.self;

        /// <summary>
        /// Defines an implicit conversion of <see cref="int"/> to <see cref="Num"/>.
        /// </summary>
        /// <param name="value">
        /// Value to convert to <see cref="Num"/>.
        /// </param>
        static public implicit operator Num(int value) => new Num(value);

        /// <summary>
        /// Defines an implicit conversion of <see cref="uint"/> to <see cref="Num"/>.
        /// </summary>
        /// <param name="value">
        /// Value to convert to <see cref="Num"/>.
        /// </param>
        static public implicit operator Num(uint value) => new Num(value);

        /// <summary>
        /// Defines an implicit conversion of <see cref="long"/> to <see cref="Num"/>.
        /// </summary>
        /// <param name="value">
        /// Value to convert to <see cref="Num"/>.
        /// </param>
        static public implicit operator Num(long value) => new Num(value);

        /// <summary>
        /// Defines an implicit conversion of <see cref="ulong"/> to <see cref="Num"/>.
        /// </summary>
        /// <param name="value">
        /// Value to convert to <see cref="Num"/>.
        /// </param>
        static public implicit operator Num(ulong value) => new Num(value);

        #endregion

        #endregion

        #region properties

        /// <summary>
        /// Indicates whether the current value is zero.
        /// </summary>
        public bool IsZero => self.IsZero;

        /// <summary>
        /// Indicates whether the current value is one.
        /// </summary>
        public bool IsOne => self.IsOne;

        /// <summary>
        /// Indicates whether the current value is even.
        /// </summary>
        public bool IsEven => self.IsEven;

        /// <summary>
        /// Indicates whether the current value is power of two.
        /// </summary>
        public bool IsPowerOfTwo => self.IsPowerOfTwo;

        /// <summary>
        /// Returns the number of digits in a number.
        /// </summary>
        public int DigitCount => DigitCountByRadix(10);

        #endregion

        #region Math

        /// <summary>
        /// Returns the number of digits in a number by a specific radix.
        /// </summary>
        /// <param name="radix">Specific radix (base of the number system).</param>
        /// <returns>Count of digits in number by radix.</returns>
        public int DigitCountByRadix(int radix)
        {
            return self.IsZero ? 1 : (int)(float)(Log(self, radix) + 1);
        }

        #region Helpers

        private static Func<BigInteger, uint[]> CreateGetBitsFunc()
        {
            var value = Expression.Parameter(typeof(BigInteger));
            var expr = Expression.Lambda<Func<BigInteger, uint[]>>(
                Expression.Field(value, "_bits"), value);
            return expr.Compile();
        }

        private static readonly Func<BigInteger, uint[]> GetBits = CreateGetBitsFunc();

        private static Func<BigInteger, int> CreateGetSignFunc()
        {
            var value = Expression.Parameter(typeof(BigInteger));
            var expr = Expression.Lambda<Func<BigInteger, int>>(
                Expression.Field(value, "_sign"), value);
            return expr.Compile();
        }

        private static readonly Func<BigInteger, int> GetSign = CreateGetSignFunc();

        #endregion

        /// From System.Runtime.Numerics, Version=4.1.1.0
        /// uses in <see cref="Log(BigInteger, double)"/>
        private static int CbitHighZero(uint u)
        {
            if (u == 0)
                return 32;

            int cbit = 0;
            if ((u & 0xFFFF0000) == 0)
            {
                cbit += 16;
                u <<= 16;
            }
            if ((u & 0xFF000000) == 0)
            {
                cbit += 8;
                u <<= 8;
            }
            if ((u & 0xF0000000) == 0)
            {
                cbit += 4;
                u <<= 4;
            }
            if ((u & 0xC0000000) == 0)
            {
                cbit += 2;
                u <<= 2;
            }
            if ((u & 0x80000000) == 0)
                cbit += 1;
            return cbit;
        }

        /// From System.Runtime.Numerics, Version=4.1.1.0
        /// Current algorith (in 4.0.0.0) is very bad
        private static double Log(BigInteger value, double baseValue)
        {
            int _sign = GetSign(value);
            uint[] _bits = GetBits(value);

            if (_sign < 0 || baseValue == 1.0D)
                return double.NaN;
            if (baseValue == double.PositiveInfinity)
                return value.IsOne ? 0.0D : double.NaN;
            if (baseValue == 0.0D && !value.IsOne)
                return double.NaN;
            if (_bits == null)
                return Math.Log(_sign, baseValue);

            ulong h = _bits[_bits.Length - 1];
            ulong m = _bits.Length > 1 ? _bits[_bits.Length - 2] : 0;
            ulong l = _bits.Length > 2 ? _bits[_bits.Length - 3] : 0;

            int c = CbitHighZero((uint)h);
            long b = (long)_bits.Length * 32 - c;

            ulong x = (h << 32 + c) | (m << c) | (l >> 32 - c);

            return Math.Log(x, baseValue) + (b - 64) / Math.Log(baseValue, 2);
        }

        private static BigInteger BIpow10(int exp) => BigInteger.Pow(10, exp);

        static public Num Pow10(int exp) => new Num() { self = BIpow10(exp) };

        static public Num Pow(Num value, int exponent) => new Num() { self = BigInteger.Pow(value.self, exponent) };

        static public double Log10(Num val) => Log(val.self, 10);

        static public double Log(Num val, double exponent) => Log(val.self, exponent);

        static public Num Pow(Num value, Num exponent)
        {
            BigInteger exp = exponent.self & int.MaxValue;
            Num pow = Pow(value, (int)exp);
            if (exponent.self == exp) return pow;
            return Pow(pow, new Num() { self = exponent.self >> 32 });
        }

        #endregion

        #region TODO strings convert
        public string FirstDigits(int count)
        {
            int len = DigitCount;
            var big = BIpow10(len - count);
            return (self / big).ToString();
        }
        public string SkipDigits(int count)
        {
            int len = DigitCount;
            var big = BIpow10(len - count);
            return (self % big).ToString();
        }
        public string LastDigits(int count)
        {
            var big = BIpow10(count);
            return (self % big).ToString();
        }
        #endregion

        /// <summary>
        /// Maximum digits to print.
        /// </summary>
        const int maxDigits = 100;
        /// <summary>
        /// Number of first printable digits in large values.
        /// </summary>
        const int fstDigits = 10;
        /// <summary>
        /// Number of last printable digits in large values.
        /// </summary>
        const int lstDigits = 10;
        const string largeNumMusk = "{{{0}...[about {2} digits]...{1}}}";

        public override string ToString()
        {
            int dc = DigitCount;
            if (dc <= maxDigits)
                return self.ToString();
            return string.Format(largeNumMusk, FirstDigits(fstDigits), LastDigits(lstDigits).PadLeft(lstDigits, '0'), dc);
            // TODO DONE!? It run to another dimension on realy big numbers
        }

        #region Interfaces implementation

        #region override from Object
        public override bool Equals(object obj) => obj is Num && Equals((Num)obj);

        public override int GetHashCode() => self.GetHashCode();
        #endregion

        #region IFormattable
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return self.ToString(format, formatProvider);
        }
        #endregion

        #region IComparable
        public int CompareTo(object obj) => self.CompareTo(obj is Num ? ((Num)obj).self : obj);
        #endregion

        #region IComparable<Num>
        public int CompareTo(Num other) => self.CompareTo(other.self);
        #endregion

        #region IEquatable<Num>
        public bool Equals(Num other) => self.Equals(other.self);
        #endregion

        #endregion
    }
}