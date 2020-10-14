using BranchMath.Math.Arithmetic.Number;
using BranchMath.Math.Value;

namespace BranchMath.Math.Arithmetic {
    public interface Multipliable<Self> : Powerable<Self, Natural> where Self : Multipliable<Self>, ValueType {
        public Self times(Self a);
    }
}