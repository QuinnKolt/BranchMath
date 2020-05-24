using BranchMath.Value;

namespace BranchMath.Probability {
    public interface Event : ValueType {
        public bool happened();
    }
}