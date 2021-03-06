﻿using BranchMath.Math.Value;

namespace BranchMath.Tree {
    /// <summary>
    ///     This represents a node on the operation tree
    /// </summary>
    /// <typeparam name="V">The type of object which this node stores</typeparam>
    public interface Node<out V> where V : ValueType {
        /// <summary>
        ///     Write the operation tree starting with this node as a root in LaTeX
        /// </summary>
        /// <returns>Tree in LaTeX</returns>
        public string ToLaTeX();

        /// <summary>
        ///     Copy the entirety of this node and its children so that modifications can be made without
        ///     affecting the original
        /// </summary>
        /// <returns>A copy of the subtree whose root is this node</returns>
        public Node<V> DeepCopy();

        /// <summary>
        ///     Get the value of the node in terms of its ValueType. Note: this throws an exception if the node is a
        ///     variable.
        /// </summary>
        /// <returns>The value of the node.</returns>
        public V GetValue();
        
        public bool Matches(Node<ValueType> node);

        public string structure(int indents);

        public string structure() {
            return structure(0);
        }

        public bool DeepEquals(Node<ValueType> node);
    }
}