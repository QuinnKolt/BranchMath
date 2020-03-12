namespace BranchMath.Tree {
    /// <summary>
    ///     Represents a single node within a tree
    /// </summary>
    public interface Node<V> where V : ValueType {
        /// <summary>
        ///     Get the given tree in LaTeX
        /// </summary>
        /// <returns> a string that can be directly copied into LaTeX </returns>
        public string toLaTeX() {
            return "";
        }

        public Node<V> deep_copy() {
            return this;
        }
    }
}