using System.Collections.Generic;

namespace BranchMath.Tree {
    public interface FunctionNode<out V> : Node where V : ValueType {
        public Node simplify();
        public FunctionNode<V> deep_copy();

        public V evaluate();
    }
}