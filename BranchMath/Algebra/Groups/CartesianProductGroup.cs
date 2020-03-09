using System;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.Threading.Tasks;

namespace BranchMath.Algebra.Groups {
    /// <summary>
    ///     Represents the cartesian product of several groups whose group operation is the individual group operations of
    ///     the individual groups.
    /// </summary>
    public class CartesianProductGroup : Group<object[]> {
        /// <summary>
        ///     Returns the cartesian product of the groups given
        /// </summary>
        /// <param name="groups">The groups to compute the cartesian product of</param>
        public CartesianProductGroup(Group<object>[] groups) {
            Groups = groups;
            var elements = collectElements(groups);
            Elements = elements.ToImmutableHashSet();
        }

        /// <summary>
        ///     The ordering of the groups which are being multiplied
        /// </summary>
        private Group<object>[] Groups { get; }

        /// <summary>
        ///     Find the product of two elements in the group by multiplying the individual pairs of elements in their tuples.
        /// </summary>
        /// <param name="g">The first element to multiply.</param>
        /// <param name="h">The second element to multiply.</param>
        /// <returns>The element gh.</returns>
        public override AlgebraicElement<object[]> MultiplyElements(AlgebraicElement<object[]> g,
            AlgebraicElement<object[]> h) {
            var iden = new object[Groups.Length];
            Parallel.For(0, Groups.Length, i => iden[i] = Groups[i].MultiplyElements(
                new AlgebraicElement<object>(g.Identifier[i]),
                new AlgebraicElement<object>(h.Identifier[i])));
            return new AlgebraicElement<object[]>(iden);
        }

        /// <summary>
        ///     Find the inverse of the given element in the group by inverting the individual element in the tuple.
        /// </summary>
        /// <param name="g">The element to find the inverse of</param>
        /// <returns>The inverse of the given element</returns>
        public override AlgebraicElement<object[]> GetInverse(AlgebraicElement<object[]> g) {
            try {
                var iden = new object[Groups.Length];
                Parallel.For(0, Groups.Length, i => iden[i] = Groups[i].GetInverse(
                    new AlgebraicElement<object>(g.Identifier[i])));
                return new AlgebraicElement<object[]>(iden);
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
        public override string DisplayElement(AlgebraicElement<object[]> g) {
            try {
                var str = "(";
                for (var i = 0; i < Groups.Length; ++i) {
                    str += Groups[i].DisplayElement(new AlgebraicElement<object>(g.Identifier[i]));
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