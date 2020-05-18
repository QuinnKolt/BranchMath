namespace BranchMath.Algebra.Group {
    /// <summary>
    ///     Represents a mathematical group with a binary operation of multiplication.
    /// </summary>
    /// <typeparam name="I">The type of the identifiers of the elements of the group</typeparam>
    public abstract class Group<I> : AlgebraicStructure<I> {
        public abstract string DisplayElement(AlgebraicElement<I> g);
        public abstract string ToLaTeX();

        public string ClassLaTeX() {
            return "\\mathrm{Group}";
        }

        /// <summary>
        ///     Find the product of two elements in the group.
        /// </summary>
        /// <param name="g">The first element to multiply.</param>
        /// <param name="h">The second element to multiply.</param>
        /// <returns>The element gh.</returns>
        public abstract GroupElement<I> MultiplyElements(GroupElement<I> g, GroupElement<I> h);

        /// <summary>
        ///     Find the inverse of the given element in the group.
        /// </summary>
        /// <param name="g">The element to find the inverse of</param>
        /// <returns>The inverse of the given element</returns>
        public abstract GroupElement<I> GetInverse(GroupElement<I> g);

        /// <summary>
        ///     Find the identity of the group.
        /// </summary>
        /// <returns>The multiplicative unit of the group</returns>
        public abstract GroupElement<I> GetIdentity();
    }
}