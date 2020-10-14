using BranchMath.Math.Value;

namespace BranchMath.Tree {
    public interface Variable<out V> : ValueNode<V> where V : ValueType {
        
    }
}