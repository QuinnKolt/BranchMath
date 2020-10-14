using BranchMath.Math.Logic;
using BranchMath.Math.Value;

namespace BranchMath.Math.Algebra {
    /// <summary>
    ///     Represents an algebraic structure of some type
    /// </summary>
    /// <typeparam name="I">The type identifier of the elements of the structure</typeparam>
    public interface AlgebraicStructure<I> : ValueType {
        /// <summary>
        ///     Give the LaTeX representation of the element of the structure
        /// </summary>
        /// <param name="g">The element to display</param>
        /// <returns>The LaTeX representation of g</returns>
        public string DisplayElement(AlgebraicElement<I> g);

        public Boolean compare(AlgebraicElement<I> g, AlgebraicElement<I> h) {
            return g.evaluate().Equals(h.evaluate());
        }
    }
}