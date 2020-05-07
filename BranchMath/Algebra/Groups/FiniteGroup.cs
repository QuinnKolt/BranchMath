using System.Linq;
using BranchMath.Arithmetic.Numbers;
using BranchMath.Display;
using BranchMath.Value;

namespace BranchMath.Algebra.Groups {
    public abstract class FiniteGroup<I> : Group<I> {
        /// <summary>
        ///     Validate that this is in fact a group structure
        /// </summary>
        /// <returns>True if this is in fact a group</returns>
        public bool validate() {
            // TODO
            return false;
        }

        /// <summary>
        ///     Create a Cayley table using the elements of this group
        /// </summary>
        /// <returns>The Cayley table</returns>
        /// <exception cref="InfiniteSizeException">If the set is not explicit</exception>
        public Table<string, string, string> GetCayleyTable() {
            if (!(Elements is ExplicitSet<AlgebraicElement<I>>))
                throw new InfiniteSizeException("Cardinality is infinite");
            var elements = ((ExplicitSet<AlgebraicElement<I>>) Elements).Elements.ToArray();
            var xlabels = new string[elements.Length];
            var ylabels = new string[elements.Length];
            var products = new string[elements.Length, elements.Length];
            for (var i = 0; i < elements.Length; ++i) {
                xlabels[i] = DisplayElement(elements[i]);
                ylabels[i] = DisplayElement(elements[i]);
                for (var j = 0; j < elements.Length; ++j)
                    products[i, j] = DisplayElement((GroupElement<I>) elements[i] * (GroupElement<I>) elements[i]);
            }

            return new Table<string, string, string>(products, xlabels, ylabels);
        }

        // /// <summary>
        // ///     Get the possible generators of the group.
        // /// </summary>
        // /// <returns>The multiplicative unit of the group</returns>
        // TODO
        // public abstract Set<Set<GroupElement<I>>> GetGenerators();
    }
}