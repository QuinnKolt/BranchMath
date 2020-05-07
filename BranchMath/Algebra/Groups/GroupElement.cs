namespace BranchMath.Algebra.Groups {
    /// <summary>
    ///     Represents an element of a group (e.g. an integer in the integers over addition)
    /// </summary>
    /// <typeparam name="I">The identifier type of for the elements of this group</typeparam>
    public class GroupElement<I> : AlgebraicElement<I> {
        /// <summary>
        ///     Create a new Group Element
        /// </summary>
        /// <param name="identifier">Identifier that allows manipulation of the element</param>
        /// <param name="structure">The group to which this element belongs to</param>
        public GroupElement(I identifier, Group<I> structure) : base(identifier, structure) { }

        /// <summary>
        ///     Perform group multiplication between two elements
        /// </summary>
        /// <param name="g">The left element to multiply</param>
        /// <param name="h">The right element to multiply</param>
        /// <returns>The product of the two elements</returns>
        public static GroupElement<I> operator *(GroupElement<I> g, GroupElement<I> h) {
            return ((Group<I>) g.structure).MultiplyElements(g, h);
        }
    }
}