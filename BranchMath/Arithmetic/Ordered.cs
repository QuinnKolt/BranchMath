using BranchMath.Value;

namespace BranchMath.Arithmetic {
    public interface Ordered<in Self> where Self : ValueType {
        public bool is_less_than(Self s);
    }
}