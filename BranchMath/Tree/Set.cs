using BranchMath.Numbers;

namespace BranchMath.Tree {
    public interface Set<in T> : ValueType where T : ValueType {
        public Cardinal getCardinality();

        public bool isElement(T obj);
    }
}