using System.Collections.Generic;
using System.Collections.Immutable;
using System.Numerics;
using System.Threading.Tasks;
using BranchMath.Tree;

namespace BranchMath.Algebra.Groups {
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
            for (BigInteger i = 0; i < order / 2; ++i) {
                ((ExplicitSet<AlgebraicElement<BigInteger>>) Elements).Elements.Add(new AlgebraicElement<BigInteger>(i));
            }
        }

        /// <summary>
        ///     Find the product of two elements in the group by summing the order of the individual elements
        /// </summary>
        /// <param name="g">The first element to multiply.</param>
        /// <param name="h">The second element to multiply.</param>
        /// <returns>The element gh.</returns>
        public override AlgebraicElement<BigInteger> MultiplyElements(AlgebraicElement<BigInteger> g, AlgebraicElement<BigInteger> h) {
            try {
                var ord = order().evaluate().Value;
                return new AlgebraicElement<BigInteger>((g.Identifier + h.Identifier) % ord);
            }
            catch {
                throw new InvalidElementException("Element not in group");
            }
        }

        /// <summary>
        ///     Find the inverse of the given element in the group by negating the order of the element.
        /// </summary>
        /// <param name="g">The element to find the inverse of</param>
        /// <returns>The inverse of the given element</returns>
        public override AlgebraicElement<BigInteger> GetInverse(AlgebraicElement<BigInteger> g) {
            try {
                var ord = order().evaluate().Value;
                return new AlgebraicElement<BigInteger>((ord - g.Identifier) % ord);
            }
            catch {
                throw new InvalidElementException("Element not in group");
            }
        }

        /// <summary>
        ///     Give the LaTeX representation of the element of the group by writing the element as a
        ///     power of the generator.
        /// </summary>
        /// <param name="g">The element to display</param>
        /// <returns>The LaTeX representation of g</returns>
        public override string DisplayElement(AlgebraicElement<BigInteger> g) {
            var iden = g.Identifier;
            if (iden == 0) return "e";

            if (iden == 1) return "g";

            return "g^{" + iden + "}";
        }
    }
}