using System.Numerics;
using BranchMath.Value;

namespace BranchMath.Algebra.Group {
    /// <summary>
    ///     An Implementation of the Cyclic group
    /// </summary>
    public class CyclicGroup : FiniteGroup<BigInteger> {
        /// <summary>
        ///     Constructs a cyclic group
        /// </summary>
        /// <param name="order">The order of the cyclic group</param>
        /// <exception cref="InvalidGroupException">If the order of the cyclic group is not positive</exception>
        public CyclicGroup(int order) {
            if (order <= 0) throw new InvalidGroupException("No cyclic group of negative order");
            Elements = new ExplicitSet<AlgebraicElement<BigInteger>>();
            for (BigInteger i = 0; i < order / 2; ++i)
                ((ExplicitSet<AlgebraicElement<BigInteger>>) Elements).Elements.Add(
                    new GroupElement<BigInteger>(i, this));
        }

        public override GroupElement<BigInteger> MultiplyElements(GroupElement<BigInteger> g,
            GroupElement<BigInteger> h) {
            try {
                var ord = ((BigInteger?) order().evaluate()).Value;
                return new GroupElement<BigInteger>((g.Identifier + h.Identifier) % ord, this);
            }
            catch {
                throw new InvalidElementException("Element not in group");
            }
        }

        public override GroupElement<BigInteger> GetInverse(GroupElement<BigInteger> g) {
            try {
                var ord = ((BigInteger?) order().evaluate()).Value;
                return new GroupElement<BigInteger>((ord - g.Identifier) % ord, this);
            }
            catch {
                throw new InvalidElementException("Element not in group");
            }
        }

        public override GroupElement<BigInteger> GetIdentity() {
            return new GroupElement<BigInteger>(0, this);
        }

        public override string DisplayElement(AlgebraicElement<BigInteger> g) {
            var iden = g.Identifier;
            if (iden == 0) return "e";

            if (iden == 1) return "g";

            return $"g^{iden}";
        }

        public override string ToLaTeX() {
            return "C" + order().ToLaTeX();
        }
    }
}