using System.Linq;
using BranchMath.Arithmetic.Number;
using BranchMath.Arithmetic.Numbers;
using BranchMath.Display;
using BranchMath.Value;

namespace BranchMath.Algebra.Group {
    public abstract class FiniteGroup<I> : Group<I> {
        /// <summary>
        ///     The set of elements in the algebraic structure
        /// </summary>
        public Set<AlgebraicElement<I>> Elements = new ExplicitSet<AlgebraicElement<I>>();

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

        /// <summary>
        ///     Test if a given subgroup is normal
        /// </summary>
        /// <param name="subgroup">The subgroup to test</param>
        /// <returns>whether or not the group is normal</returns>
        public bool is_normal(FiniteGroup<I> subgroup) {
            return !(from g in ((ExplicitSet<AlgebraicElement<I>>) Elements).Elements
                from h in ((ExplicitSet<AlgebraicElement<I>>) subgroup.Elements).Elements
                let gg = (GroupElement<I>) g
                let hg = (GroupElement<I>) h
                where !subgroup.Elements.IsElement(gg * hg * GetInverse(gg))
                select gg).Any();
        }

        // /// <summary>
        // ///     Get the possible generators of the group.
        // /// </summary>
        // /// <returns>The multiplicative unit of the group</returns>
        // TODO
        // public abstract Set<Set<GroupElement<I>>> GetGenerators();

        /// <summary>
        ///     The size of the structure
        /// </summary>
        /// <returns>The number of elements in the Algebraic Structure</returns>
        public virtual Cardinal order() {
            return Elements.GetCardinality();
        }
    }
}