using BranchMath.Math.Value;

namespace BranchMath.Tree {
    public interface OperationNode<out V> : Node<V> where V : ValueType {
        public Node<V> simplify();

        public Node<ValueType>[] GetChildren();

        public OperationNode<V> CopyWithNewChildren(Node<ValueType>[] children);

        public Operator<V> getOperator();
    }
}