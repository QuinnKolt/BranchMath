using System;
using System.Linq;
using System.Numerics;
using Boolean = BranchMath.Math.Logic.Boolean;

namespace BranchMath.Math.Arithmetic.Number {
    public class Integer : Rational {
        public new static readonly Integer ZERO = new Integer(0);

        public readonly BigInteger val;

        public Integer(BigInteger n) : base(n, 1) {
            val = n;
        }

        public static Integer operator %(Integer a, Integer b) {
            return (a.val % b.val + b.val) % b.val;
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
            return p < 0 ? new Rational(1, BigInteger.Pow(b.val, p)) : ONE;
        }

        public static Boolean operator >(Integer a, Integer b) {
            return a.val > b.val;
        }

        public static Boolean operator <(Integer a, Integer b) {
            return a.val < b.val;
        }

        public static Boolean operator ==(Integer a, Integer b) {
            return a?.val == b?.val;
        }

        public static Boolean operator !=(Integer a, Integer b) {
            return !(a == b);
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
        
        
        public static implicit operator BigInteger(Integer n) {
            return n.val;
        }
        
        public static implicit operator Integer(BigInteger n) {
            return new Integer(n);
        }

        public override object evaluate() {
            return val;
        }

        public bool divides(Integer i) {
            return (i % this).Equals(Integer.ZERO);
        }

        public static Boolean operator |(Integer k, Integer n) {
            return k.divides(n);
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
            if (b.Length < 8) {
                var bytes = new byte[8];
                for (var j = 0; j < b.Length; ++j) {
                    bytes[j] = b[j];
                }

                for (var j = b.Length; j < 8; ++j) {
                    bytes[j] = 0;
                }
                Console.WriteLine(BitConverter.ToInt64(bytes));
                return BitConverter.ToInt64(bytes);
            }
            return BitConverter.ToInt64(b);
        }

        public override string ClassLaTeX() {
            return "\\mathbb{Z}";
        }

        public override bool Equals(object obj) {
            if (obj is Integer i) {
                return val == i.val;
            }

            return false;
        }

        public override int GetHashCode() {
            return val.GetHashCode();
        }
    }
}