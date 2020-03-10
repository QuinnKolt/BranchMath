using System.Numerics;

namespace BranchMath.Numbers {
    public class Rational : RealNumber {
        public readonly BigInteger numerator;
        public readonly BigInteger denominator;

        public Rational(BigInteger denominator, BigInteger numerator) {
            this.numerator = numerator;
            this.denominator = denominator;
        }
    }
}