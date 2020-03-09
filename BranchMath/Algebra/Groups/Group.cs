using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using BranchMath.Tree;

namespace BranchMath.Algebra.Groups {
    /// <summary>
    ///     Represents a mathematical group with a binary operation of multiplication.
    /// </summary>
    /// <typeparam name="I">The type of the identifiers of the elements of the group</typeparam>
    public abstract class Group<I> : AlgebraicStructure<I> {

        /// <summary>
        ///     Find the product of two elements in the group.
        /// </summary>
        /// <param name="g">The first element to multiply.</param>
        /// <param name="h">The second element to multiply.</param>
        /// <returns>The element gh.</returns>
        public abstract AlgebraicElement<I> MultiplyElements(AlgebraicElement<I> g, AlgebraicElement<I> h);

        /// <summary>
        ///     Find the inverse of the given element in the group.
        /// </summary>
        /// <param name="g">The element to find the inverse of</param>
        /// <returns>The inverse of the given element</returns>
        public abstract AlgebraicElement<I> GetInverse(AlgebraicElement<I> g);
    }
}