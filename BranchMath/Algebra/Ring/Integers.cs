using System;
using System.Numerics;
using BranchMath.Arithmetic.Number;

namespace BranchMath.Algebra.Ring {
    public class Integers : Ring<BigInteger> {
        public static readonly Integers TheIntegers = new Integers();
        
        private Integers() {}
        
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
            public IntElement times(IntElement a, IntElement b) {
                return (IntElement) (a * b);
            }

            public IntElement sum(IntElement a, IntElement b) {
                return (IntElement) (a + b);
            }

            public IntElement pow(IntElement b, Integer p) {
                return (IntElement) (b ^ p);
            }
            
            public static explicit operator Integer(IntElement n) {
                return new Integer(n.Identifier);
            }
            
            public static explicit operator IntElement(Integer n) {
                return new IntElement(n.val, TheIntegers);
            }
        }
    }
}