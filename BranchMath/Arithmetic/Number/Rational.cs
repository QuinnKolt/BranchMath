using System.Numerics;

namespace BranchMath.Arithmetic.Number {
    public class Rational : RealNumber {
        protected readonly BigInteger denominator;
        protected readonly BigInteger numerator;

        public Rational(BigInteger numerator, BigInteger denominator) {
            this.numerator = numerator;
            this.denominator = denominator;
        }
        
        public static Rational operator +(Rational a, Rational b) {
            return new Rational(a.numerator * b.denominator+ b.numerator * a.denominator, 
                a.denominator * b.denominator);
        }
        
        public override string ToLaTeX() {
            return denominator != 1 ? $"\\dfrac{numerator}{denominator}" : numerator.ToString();
        }

        public override string ClassLaTeX() {
            return "\\mathbb{Q}";
        }
    }
}