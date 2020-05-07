using BranchMath.Value;

namespace BranchMath.Tree {
    /// <summary>
    ///     Represents a constant value as a node in the operation tree. This can be anything from a function (itself/no
    ///     variables)
    ///     to a group to a number.
    /// </summary>
    /// <typeparam name="V">The type of value which this constant represents</typeparam>
    public class ConstantNode<V> : ValueNode<V> where V : ValueType {
        public readonly V value;

        /// <summary>
        ///     Constructs a new constant
        /// </summary>
        /// <param name="value">The value of the constant</param>
        public ConstantNode(V value) {
            this.value = value;
        }

        public override string ToLaTeX() {
            return value.ToLaTeX();
        }
    }
}