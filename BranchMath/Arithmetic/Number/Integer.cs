using System;
using System.Linq;
using System.Numerics;

namespace BranchMath.Arithmetic.Number {
    public class Integer : Rational {
        public new static readonly Integer ZERO = new Integer(0);

        public BigInteger val;

        public Integer(BigInteger n) : base(n, 1) {
            val = n;
        }

        public static Natural operator %(Integer a, Integer b) {
            return new Natural((a.val % b.val + b.val) % b.val);
        }

        public static Integer operator +(Integer a, Integer b) {
            return new Integer(a.val + b.val);
        }

        public static Integer operator -(Integer a, Integer b) {
            return new Integer(a.val - b.val);
        }

        public static Integer operator *(Integer a, Integer b) {
            return new Integer(a.val * b.val);
        }

        public static Integer operator ++(Integer a) {
            return a + 1;
        }

        public static Integer operator ^(Integer b, Natural p) {
            return new Integer(BigInteger.Pow(b.val, p));
        }

        public static Rational operator ^(Integer b, Integer p) {
            if (p > 0) return new Rational(BigInteger.Pow(b.val, p), 1);
            if (p < 0) return new Rational(1, BigInteger.Pow(b.val, p));

            return ONE;
        }

        public override string ToLaTeX() {
            return $"{val}";
        }

        public static implicit operator Integer(byte n) {
            return new Integer(n);
        }

        public static implicit operator Integer(int n) {
            return new Integer(n);
        }

        public static implicit operator Integer(uint n) {
            return new Integer(n);
        }

        public static implicit operator Integer(short n) {
            return new Integer(n);
        }

        public static implicit operator Integer(ushort n) {
            return new Integer(n);
        }

        public static implicit operator Integer(long n) {
            return new Integer(n);
        }

        public override object evaluate() {
            return val;
        }

        public static implicit operator Integer(ulong n) {
            return new Integer(n);
        }

        public static implicit operator int(Integer i) {
            return (int) ToLong(i.val);
        }

        public static long ToLong(BigInteger i) {
            if (i.GetByteCount() > 8)
                throw new InvalidCastException();
            var b = i.ToByteArray();
            if (BitConverter.IsLittleEndian)
                b = b.Reverse().ToArray();
            return BitConverter.ToInt64(b);
        }

        public override string ClassLaTeX() {
            return "\\mathbb{Z}";
        }
    }
}