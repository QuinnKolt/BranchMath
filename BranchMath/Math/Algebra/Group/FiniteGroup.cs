using System.Linq;
using BranchMath.Display;
using BranchMath.Math.Arithmetic.Number;
using BranchMath.Math.Set;
using Boolean = BranchMath.Math.Logic.Boolean;

namespace BranchMath.Math.Algebra.Group {
    public abstract class FiniteGroup<I> : Group<I> {
        /// <summary>
        ///     The set of elements in the algebraic structure
        /// </summary>
        public ExplicitSet<GroupElement<I>> Elements = new ExplicitSet<GroupElement<I>>();

        /// <summary>
        ///     Validate that this is in fact a group structure
        /// </summary>
        /// <returns>True if this is in fact a group</returns>
        public Boolean validate() {
            if (is_closed() && is_associative()) {
                var iden = ManualIdentity();
                if (iden != null && has_inverses(iden) && iden.Equals(GetIdentity()))
                    return true;
            }

            return false;
        }

        private bool is_closed() {
            var found = false;
            foreach (var g1 in Elements.Elements)
                foreach (var g2 in Elements.Elements) {
                    foreach (var g3 in Elements.Elements) {
                        if (!(g1 * g2).Equals(g3)) continue;
                        found = true;
                        break;
                    }
                    if (!found)
                        return false;
                }

            return true;
        }

        private bool is_associative() {
            return !(from GroupElement<I> el1 in Elements.Elements
                from GroupElement<I> el2 in Elements.Elements
                from GroupElement<I> el3 in Elements.Elements
                where !(el1 * (el2 * el3)).Equals((el1 * el2) * el3)
                select el1).Any();
        }

        private bool has_inverses(GroupElement<I> identity) {
            return Elements.Elements.Select(g1 =>
                Elements.Elements.Any(g2 =>
                    identity.Equals(g1 * g2))).All(hasInverse => hasInverse);
        }

        private GroupElement<I> ManualIdentity() {
            return (from g1 in Elements.Elements
                let identity = Elements.Elements.All(g2 =>
                    g2.Equals(g1 * g2) && g2.Equals(g2 * g1))
                where identity
                select g1).FirstOrDefault();
        }

        public override GroupElement<I> GetIdentity() {
            return ManualIdentity();
        }

        /// <summary>
        ///     Create a Cayley table using the elements of this group
        /// </summary>
        /// <returns>The Cayley table</returns>
        /// <exception cref="InfiniteSizeException">If the set is not explicit</exception>
        public Table<string, string, string> GetCayleyTable() {
            var elements = Elements.Elements.ToArray();
            var xlabels = new string[elements.Length];
            var ylabels = new string[elements.Length];
            var products = new string[elements.Length, elements.Length];
            for (var i = 0; i < elements.Length; ++i) {
                xlabels[i] = DisplayElement(elements[i]);
                ylabels[i] = DisplayElement(elements[i]);
                for (var j = 0; j < elements.Length; ++j)
                    products[i, j] = DisplayElement(elements[i] * elements[i]);
            }

            return new Table<string, string, string>(products, xlabels, ylabels);
        }

        /// <summary>
        ///     Test if a given subgroup is normal
        /// </summary>
        /// <param name="subgroup">The subgroup to test</param>
        /// <returns>whether or not the group is normal</returns>
        public Boolean is_normal(FiniteGroup<I> subgroup) {
            return !(from g in Elements.Elements
                from h in subgroup.Elements.Elements
                let gg = g
                let hg = h
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