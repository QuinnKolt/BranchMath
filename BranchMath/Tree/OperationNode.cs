﻿using BranchMath.Value;

namespace BranchMath.Tree {
    public interface OperationNode<out V> : Node<V> where V : ValueType {
        public Node<V> simplify();
    }
}