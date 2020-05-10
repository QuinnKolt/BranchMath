using System;
using System.Linq;
using System.Numerics;

namespace BranchMath.Arithmetic.Number {
    public class Integer : Rational {
        public static readonly Integer ZERO = new Integer(0);
        public Integer(BigInteger n) : base(n, 1) { }

        public static Natural operator %(Integer a, Integer b) {
            return new Natural((a.numerator % b.numerator + b.numerator) % b.numerator);
        }
        
        public static Integer operator +(Integer a, Integer b) {
            return new Integer(a.numerator + b.numerator);
        }
        
        public static Integer operator -(Integer a, Integer b) {
            return new Integer(a.numerator - b.numerator);
        }
        
        public static Integer operator *(Integer a, Integer b) {
            return new Integer(a.numerator * b.numerator);
        }
        
        public static Integer operator ++(Integer a) {
            return a + 1;
        }

        public static Rational operator ^(Integer b, Integer p) {
            if (p > 0)
                return new Integer(BigInteger.Pow(b.numerator, p));
            if (p < 0)
                return new Rational( 1, BigInteger.Pow(b.numerator, p));
            return new Natural(1);
        }
        
        public override string ToLaTeX() {
            return $"{numerator}";
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

        public static implicit operator Integer(ulong n) {
            return new Integer(n);
        }

        public static implicit operator int(Integer i) {
            if(i.numerator.GetByteCount() > 4) 
                throw new InvalidCastException();
            var b = i.numerator.ToByteArray();
            if(BitConverter.IsLittleEndian) 
                b = b.Reverse().ToArray();
            return BitConverter.ToInt32(b);
        }
    }
}