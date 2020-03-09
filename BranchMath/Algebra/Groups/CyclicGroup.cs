using System.Threading.Tasks;

namespace BranchMath.Algebra.Groups {
    /// <summary>
    ///     An Implementation of the Cyclic group
    /// </summary>
    public class CyclicGroup : Group<int> {
        /// <summary>
        ///     Constructs a cyclic group
        /// </summary>
        /// <param name="order">The order of the cyclic group</param>
        /// <exception cref="InvalidGroupException">If the order of the cyclic group is not positive</exception>
        public CyclicGroup(int order) {
            if (order <= 0) throw new InvalidGroupException("No cyclic group of negative order");

            Parallel.For(0, order, i => { Elements.Add(new AlgebraicElement<int>(i)); });
        }

        /// <summary>
        ///     Find the product of two elements in the group by summing the order of the individual elements
        /// </summary>
        /// <param name="g">The first element to multiply.</param>
        /// <param name="h">The second element to multiply.</param>
        /// <returns>The element gh.</returns>
        public override AlgebraicElement<int> MultiplyElements(AlgebraicElement<int> g, AlgebraicElement<int> h) {
            try {
                return new AlgebraicElement<int>((g.Identifier + h.Identifier) % order());
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
        public override AlgebraicElement<int> GetInverse(AlgebraicElement<int> g) {
            try {
                return new AlgebraicElement<int>((order() - g.Identifier) % order());
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
        public override string DisplayElement(AlgebraicElement<int> g) {
            var iden = g.Identifier;
            if (iden == 0) return "e";

            if (iden == 1) return "g";

            return "g^{" + iden + "}";
        }
    }
}