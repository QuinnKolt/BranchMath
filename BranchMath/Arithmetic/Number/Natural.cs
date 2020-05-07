using System.Numerics;

namespace BranchMath.Arithmetic.Number {
    public class Natural : Integer {
        public Natural(BigInteger n) : base(n) { }

        public BigInteger gcd(Natural n) {
            if (numerator % n.numerator == 0)
                return n.numerator;
            return n.gcd(new Natural(numerator % n.numerator));
        }

        public static explicit operator Natural(byte n) {
            return new Natural(n);
        }

        public static explicit operator Natural(int n) {
            return new Natural(n);
        }

        public static explicit operator Natural(uint n) {
            return new Natural(n);
        }

        public static explicit operator Natural(short n) {
            return new Natural(n);
        }

        public static explicit operator Natural(ushort n) {
            return new Natural(n);
        }

        public static explicit operator Natural(long n) {
            return new Natural(n);
        }

        public static explicit operator Natural(ulong n) {
            return new Natural(n);
        }
    }
}