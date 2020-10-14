using BranchMath.Math.Value;

namespace BranchMath.Math.Arithmetic {
    public interface Subtractable<Self> : Summable<Self> where Self : Subtractable<Self>, ValueType {
        public Self getZero();
        public Self minus(Self r);
    }
}