using BranchMath.Math.Logic;
using BranchMath.Math.Value;

namespace BranchMath.Math.Probability {
    public interface Event : ValueType {
        public Boolean happened();
    }
}