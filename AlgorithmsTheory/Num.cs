using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmTheory
{
    public struct Num : IFormattable, IComparable, IComparable<Num>, IEquatable<Num>
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private BigInteger self;

        #region readonly constants
        readonly public static Num Zero = new Num() { self = BigInteger.Zero };
        readonly public static Num One = new Num() { self = BigInteger.One };
        readonly public static Num Two = new Num() { self = 2 };
        #endregion

#if DEBUG
        public static int BIctor = 0, INTctor = 0, UINTctor = 0;
#endif

        #region constructors
        public Num(BigInteger value)
        {
            self = value < 0 ? 0 : value;
#if DEBUG
            BIctor++;
            Debug.WriteLine("new num(BIG) with {0}", value);
#endif
        }
        public Num(int value)
        {
            self = new BigInteger(value < 0 ? 0 : value);
#if DEBUG
            INTctor++;
            Debug.WriteLine("new num(INT) with {0}", value);
#endif
        }
        public Num(uint value)
        {
            self = new BigInteger(value);
#if DEBUG
            UINTctor++;
            Debug.WriteLine("new num(UINT) with {0}", value);
#endif
        }
        public Num(ulong value)
        {
            self = new BigInteger(value);
        }
        #endregion

        #region operators

        #region arithmetic
        static public Num operator +(Num left, Num right) => new Num { self = left.self + right.self };
        static public Num operator *(Num left, Num right) => new Num { self = left.self * right.self };
        static public Num operator /(Num left, Num right) => new Num { self = left.self / right.self };
        static public Num operator %(Num left, Num right) => new Num { self = left.self % right.self };
        static public Num operator -(Num left, Num right) => new Num(left.self - right.self);
        #endregion

        #region unary
        static public Num operator ++(Num left) => new Num { self = left.self + BigInteger.One };
        static public Num operator --(Num left) => new Num(left.self - BigInteger.One);
        #endregion

        #region logic
        static public bool operator ==(Num left, Num right) => (left.self == right.self);
        static public bool operator !=(Num left, Num right) => (left.self != right.self);
        static public bool operator <=(Num left, Num right) => (left.self <= right.self);
        static public bool operator >=(Num left, Num right) => (left.self >= right.self);
        static public bool operator <(Num left, Num right) => (left.self < right.self);
        static public bool operator >(Num left, Num right) => (left.self > right.self);
        #endregion

        #region converting
        static public implicit operator Num(int value) => new Num(value);
        static public explicit operator int(Num value) => (int)value.self;
        static public implicit operator Num(uint value) => new Num(value);
        static public implicit operator Num(ulong value) => new Num(value);
        #endregion

        #endregion

        #region properties
        public bool IsOne => self.IsOne;
        public bool IsZero => self.IsZero;
        public bool IsEven => self.IsEven;
        public bool IsPowerOfTwo => self.IsPowerOfTwo;
        public int DigitCount => self.IsZero ? 0 : (int)(Math.Floor(BigInteger.Log10(self)) + 1);
        #endregion

        private static BigInteger BIpow10(int exp) => BigInteger.Pow(10, exp);

        static public Num Pow10(int exp) => new Num() { self = BIpow10(exp) };

        static public Num Pow(Num value, int exponent) => new Num() { self = BigInteger.Pow(value.self, exponent) };

        static public double Log10(Num val) => BigInteger.Log10(val.self);

        static public Num Pow(Num value, Num exponent)
        {
            BigInteger exp = exponent.self & int.MaxValue;
            Num pow = Pow(value, (int)exp);
            int dc = pow.DigitCount;
            if (exponent.self == exp) return pow;
            return Pow(pow, new Num() { self = exponent.self >> 32 });
        }

        #region TODO strings convert
        public string FirstDigits(int count)
        {
            int len = DigitCount;
            var big = BIpow10(len - count);
            return "{" + (self / big) + "}";
        }
        public string SkipDigits(int count)
        {
            int len = DigitCount;
            var big = BIpow10(len - count);
            return "{" + (self % big) + "}";
        }
        public string LastDigits(int count)
        {
            var big = BIpow10(count);
            return "{" + (self % big) + "}";
        }
        public string ToStringF()
        {
            const int take = 50;
            var sb = new StringBuilder();
            var mask = BIpow10(take);
            int len = DigitCount, length = len / take;
            for (int i = length; i >= 0; i--)
            {
                sb.Append(self / BIpow10(i*take) % mask);
            }
            return sb.ToString();
        }
        #endregion

        public override string ToString()
        {
            return self.ToString();
            return "0"; // TODO!
        }

        #region Interfaces

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
