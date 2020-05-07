using System.Numerics;

namespace BranchMath.Arithmetic.Number {
    public class Integer : Rational {
        public Integer(BigInteger n) : base(n, 1) { }

        public static Natural operator %(Integer a, Integer b) {
            return new Natural((a.numerator % b.numerator + b.numerator) % b.numerator);
        }
        
        public static Natural operator +(Integer a, Integer b) {
            return new Natural(a.numerator + b.numerator);
        }

        public static explicit operator Integer(byte n) {
            return new Integer(n);
        }

        public static explicit operator Integer(int n) {
            return new Integer(n);
        }

        public static explicit operator Integer(uint n) {
            return new Integer(n);
        }

        public static explicit operator Integer(short n) {
            return new Integer(n);
        }

        public static explicit operator Integer(ushort n) {
            return new Integer(n);
        }

        public static explicit operator Integer(long n) {
            return new Integer(n);
        }

        public static explicit operator Integer(ulong n) {
            return new Integer(n);
        }
    }
}