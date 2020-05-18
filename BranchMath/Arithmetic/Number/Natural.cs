using System;
using System.Numerics;

namespace BranchMath.Arithmetic.Number {
    public class Natural : Integer {
        public new static readonly Natural ONE = new Natural(1);

        public Natural(BigInteger n) : base(n) {
            if (n <= 0) throw new InvalidCastException("Naturals start with 1.");
        }

        public Natural gcd(Natural n) {
            return val % n.val == 0 ? n : n.gcd(new Natural(val % n.val));
        }

        public static Natural operator *(Natural a, Natural b) {
            return new Natural(a.val * b.val);
        }

        public static Natural operator +(Natural a, Natural b) {
            return new Natural(a.val + b.val);
        }

        public static Natural operator ++(Natural a) {
            return a + ONE;
        }

        public static Natural operator ^(Natural b, Natural p) {
            return new Natural(BigInteger.Pow(b.val, p));
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

        public override string ClassLaTeX() {
            return "\\mathbb{N}_{1}";
        }
    }
}