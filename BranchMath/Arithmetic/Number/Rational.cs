using System;
using System.Numerics;

namespace BranchMath.Arithmetic.Number {
    public class Rational : Number {
        public static readonly Rational ZERO = new Rational(0,1);
        public static readonly Rational ONE = new Rational(1,1);
        internal readonly BigInteger denominator;
        internal readonly BigInteger numerator;

        public Rational(BigInteger numerator, BigInteger denominator) {
            if(denominator == 0)
                throw new DivideByZeroException();
            
            this.numerator = numerator;
            this.denominator = denominator;
        }
        
        public static Rational operator +(Rational a, Rational b) {
            return new Rational(a.numerator * b.denominator+ b.numerator * a.denominator, 
                a.denominator * b.denominator);
        }
        
        
        public static Rational operator /(Rational n, Rational d) {
            return new Rational(n.numerator * d.denominator, d.numerator * n.denominator);
        }

        public static Rational operator ^(Rational b, Integer p) {
            if (p > 0)
                return new Rational(BigInteger.Pow(b.numerator, p), BigInteger.Pow(b.denominator, p));
            if (p < 0)
                return new Rational( BigInteger.Pow(b.denominator, p), BigInteger.Pow(b.numerator, p));
            return new Natural(1);
        }

        public virtual object evaluate() {
            return Integer.ToLong(numerator) / (double) Integer.ToLong(denominator);
        }

        public virtual string ToLaTeX() {
            return denominator != 1 ? $"\\dfrac{numerator}{denominator}" : numerator.ToString();
        }

        public virtual string ClassLaTeX() {
            return "\\mathbb{Q}";
        }

        public bool is_finite() {
            return true;
        }
    }
}