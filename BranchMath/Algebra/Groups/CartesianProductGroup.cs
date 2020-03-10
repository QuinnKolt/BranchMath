using System;
using System.Threading.Tasks;
using BranchMath.Tree;

namespace BranchMath.Algebra.Groups {
    /// <summary>
    ///     Represents the cartesian product of several groups whose group operation is the individual group operations of
    ///     the individual groups.
    /// </summary>
    public class CartesianProductGroup<I> : Group<I[]> {
        /// <summary>
        ///     Returns the cartesian product of the groups given
        /// </summary>
        /// <param name="groups">The groups to compute the cartesian product of</param>
        public CartesianProductGroup(Group<I>[] groups) {
            Groups = groups;
            Elements = new CartesianProduct<AlgebraicElement<I>>().evaluate();
        }

        /// <summary>
        ///     The ordering of the groups which are being multiplied
        /// </summary>
        private Group<I>[] Groups { get; }

        /// <summary>
        ///     Find the product of two elements in the group by multiplying the individual pairs of elements in their tuples.
        /// </summary>
        /// <param name="g">The first element to multiply.</param>
        /// <param name="h">The second element to multiply.</param>
        /// <returns>The element gh.</returns>
        public override AlgebraicElement<I[]> MultiplyElements(AlgebraicElement<I[]> g,
            AlgebraicElement<I[]> h) {
            var iden = new I[Groups.Length];
            Parallel.For(0, Groups.Length, i => iden[i] = Groups[i].MultiplyElements(
                new AlgebraicElement<I>(g.Identifier[i]),
                new AlgebraicElement<I>(h.Identifier[i])).Identifier);
            return new AlgebraicElement<I[]>(iden);
        }

        /// <summary>
        ///     Find the inverse of the given element in the group by inverting the individual element in the tuple.
        /// </summary>
        /// <param name="g">The element to find the inverse of</param>
        /// <returns>The inverse of the given element</returns>
        public override AlgebraicElement<I[]> GetInverse(AlgebraicElement<I[]> g) {
            try {
                var iden = new I[Groups.Length];
                Parallel.For(0, Groups.Length, i => iden[i] = Groups[i].GetInverse(
                    new AlgebraicElement<I>(g.Identifier[i])).Identifier);
                return new AlgebraicElement<I[]>(iden);
            }
            catch {
                throw new InvalidElementException("Element not in Group");
            }
        }

        /// <summary>
        ///     Give the LaTeX representation of the element of the group by writing a tuple of individual representations
        ///     in the tuple.
        /// </summary>
        /// <param name="g">The element to display</param>
        /// <returns>The LaTeX representation of g</returns>
        public override string DisplayElement(AlgebraicElement<I[]> g) {
            try {
                var str = "(";
                for (var i = 0; i < Groups.Length; ++i) {
                    str += Groups[i].DisplayElement(new AlgebraicElement<I>(g.Identifier[i]));
                    if (i != Groups.Length - 1)
                        str += ",";
                }

                return str + ")";
            }
            catch {
                throw new InvalidElementException("Element not in Group");
            }
        }
    }
}