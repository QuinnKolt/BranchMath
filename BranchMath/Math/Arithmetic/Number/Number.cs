using BranchMath.Math.Logic;
using BranchMath.Math.Value;

namespace BranchMath.Math.Arithmetic.Number {
    public interface Number : ValueType {
        public Boolean is_finite();
    }
}