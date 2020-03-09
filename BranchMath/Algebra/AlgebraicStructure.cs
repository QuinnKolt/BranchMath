using BranchMath.Tree;

namespace BranchMath.Algebra {
    /// <summary>
    ///     Represents an algebraic structure of some type
    /// </summary>
    /// <typeparam name="I">The type identifier of the elements of the structure</typeparam>
    public abstract class AlgebraicStructure<I> : Node {
        
        public Set<AlgebraicElement<I>> Elements = new ExplicitSet<AlgebraicElement<I>>();
        
        /// <summary>
        ///     Give the LaTeX representation of the element of the structure
        /// </summary>
        /// <param name="g">The element to display</param>
        /// <returns>The LaTeX representation of g</returns>
        public abstract string DisplayElement(AlgebraicElement<I> g);

        /// <summary>
        ///     The size of the structure
        /// </summary>
        /// <returns>The number of elements in the Algebraic Structure</returns>
        public Node order() {
            return Elements.getCardinality();
        }
    }
}