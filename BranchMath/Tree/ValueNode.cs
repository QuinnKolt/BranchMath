using BranchMath.Math.Value;

namespace BranchMath.Tree {
    /// <summary>
    ///     This represents a leaf on the operation tree: either a variable or a constant
    /// </summary>
    /// <typeparam name="V">The type of object which this node stores</typeparam>
    public interface ValueNode<out V> : Node<V> where V : ValueType { }
}