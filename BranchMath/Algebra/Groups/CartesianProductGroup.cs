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
        ///     Recursively collects all of the elements in the cartesian product
        /// </summary>
        /// <param name="groups">The groups to compute the cartesian product of</param>
        /// <returns>A bag of all of the elements in the cartesian product</returns>
        private static ConcurrentBag<AlgebraicElement<object[]>> collectElements(Group<object>[] groups) {
            var elements = new ConcurrentBag<AlgebraicElement<object[]>>();
            // If there is only one group, convert the identifiers to singleton arrays of elements
            // containing their identifiers
            if (groups.Length == 1) {
                Parallel.ForEach(groups[0].Elements, el =>
                    elements.Add(new AlgebraicElement<object[]>(new[] {el.Identifier}))
                );
            }

            else {
                // Recursively collect all of the elements in the cartesian product group of all groups except the first
                var otherGroups = new Group<object>[groups.Length - 1];
                Array.Copy(groups, 0, otherGroups, 1, groups.Length);
                var otherGroupElems = collectElements(otherGroups);

                // Find all tuples containing this element as the first entry combined with all other tuples obtained
                // recursively
                Parallel.ForEach(groups[0].Elements, elem =>
                    Parallel.ForEach(otherGroupElems, el => {
                        var tup = new object[groups.Length];
                        tup[0] = elem.Identifier;

                        Parallel.For(1, groups.Length, i => { tup[i] = el.Identifier[i - 1]; });
                        var comb = new AlgebraicElement<object[]>(tup);
                        elements.Add(comb);
                    })
                );
            }

            return elements;
        }

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