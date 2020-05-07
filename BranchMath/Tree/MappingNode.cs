using System.Collections.Generic;
using BranchMath.Value;

namespace BranchMath.Tree {
    /// <summary>
    ///     Represents a non-leaf node in the operation tree
    /// </summary>
    /// <typeparam name="C"></typeparam>
    public abstract class MappingNode<C> : Node<C> where C : ValueType {
        private HashSet<SimplificationRule<C>> rules = new HashSet<SimplificationRule<C>>();

        /// <summary>
        ///     Simplify this object using
        /// </summary>
        /// <returns></returns>
        public abstract Node<C> simplify();

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public abstract C evaluate();
    }
}