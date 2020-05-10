using System.Collections.Generic;
using BranchMath.Value;

namespace BranchMath.Tree {
    /// <summary>
    ///     Represents a non-leaf node in the operation tree
    /// </summary>
    /// <typeparam name="V"></typeparam>
    public abstract class OperationNode<V> : Node<V> where V : ValueType {
        private HashSet<SimplificationRule<V>> rules = new HashSet<SimplificationRule<V>>();

        /// <summary>
        ///     Simplify this object using the set of simplification rules
        /// </summary>
        /// <returns></returns>
        public abstract Node<V> simplify();
        
        public abstract V evaluate();
        
        public abstract string ToLaTeX();
    }
}