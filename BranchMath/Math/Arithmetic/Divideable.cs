using BranchMath.Math.Value;

namespace BranchMath.Math.Arithmetic {
    public interface Divideable<Self> : Multipliable<Self> where Self : Divideable<Self>, ValueType {
        public Self getOne();
        public Self dividedBy(Self d);
    }
}