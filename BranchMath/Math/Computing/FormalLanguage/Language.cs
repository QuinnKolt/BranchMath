using BranchMath.Math.Logic;
using BranchMath.Math.Value;

namespace BranchMath.Math.Computing.FormalLanguage {
    public interface Language<in C> : ValueType where C : ValueType {
        public Boolean contains(C[] str);
    }
}