using BranchMath.Numbers;

namespace BranchMath.Tree {
    public interface Set<T> : ValueType where T : Node {
        public Cardinal getCardinality();

        public bool isElement(T obj);
    }
}