using System.Collections.Generic;

namespace BranchMath.Tree {
    public interface FunctionNode<C> : Node<C> where C : ValueType{
        public Node<C> simplify();
        public C evaluate();
    }
}