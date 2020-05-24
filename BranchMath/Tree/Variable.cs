using BranchMath.Value;

namespace BranchMath.Tree {
    internal interface Variable<out V> : ValueNode<V> where V : ValueType {
        
    }
}