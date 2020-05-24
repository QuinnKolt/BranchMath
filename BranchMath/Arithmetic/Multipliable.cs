using BranchMath.Value;

namespace BranchMath.Arithmetic {
    public interface Multipliable<Self>  where Self : ValueType {
        public Self times(Self a);
    }
}