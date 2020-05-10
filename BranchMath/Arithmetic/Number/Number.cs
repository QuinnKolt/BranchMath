using BranchMath.Value;

namespace BranchMath.Arithmetic.Number {
    public interface Number : ValueType {
        public bool is_finite();
    }
}