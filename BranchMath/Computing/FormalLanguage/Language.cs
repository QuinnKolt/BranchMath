using BranchMath.Value;

namespace BranchMath.Computing.FormalLanguage {
    public interface Language<in C> : ValueType where C : ValueType {
        public bool contains(C[] str);
    }
}