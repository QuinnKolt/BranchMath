using System;
using System.Numerics;

namespace BranchMath.Algebra.Ring {
    public class Integers : Ring<BigInteger> {
        public override string ToLaTeX() {
            return @"\mathbb{Z}";
        }

        public override string DisplayElement(AlgebraicElement<BigInteger> g) {
            return g.Identifier.ToString();
        }

        public override RingElement<BigInteger> MultiplyElements(RingElement<BigInteger> g, RingElement<BigInteger> h) {
            return new IntElement(((IntElement) g).Identifier * ((IntElement) h).Identifier, this);
        }

        public override RingElement<BigInteger> AddElements(RingElement<BigInteger> g, RingElement<BigInteger> h) {
            return new IntElement(((IntElement) g).Identifier + ((IntElement) h).Identifier, this);
        }

        public override RingElement<BigInteger> GetAdditiveInverse(RingElement<BigInteger> g) {
            return new IntElement(-g.Identifier, this);
        }

        public override RingElement<BigInteger> GetMultiplicativeInverse(RingElement<BigInteger> g) {
            if (g.Identifier == 1 || g.Identifier == -1)
                return g;
            throw new DivideByZeroException();
        }

        public override RingElement<BigInteger> getOne() {
            return new IntElement(1, this);
        }

        public override RingElement<BigInteger> getZero() {
            return new IntElement(0, this);
        }

        public class IntElement : RingElement<BigInteger> {
            public IntElement(BigInteger identifier, Ring<BigInteger> structure) : base(identifier, structure) { }
        }
    }
}