using BranchMath.Math.Value;

namespace BranchMath.Math.Arithmetic {
    public interface Powerable<out Base, in Pow> : ValueType where Base : ValueType where Pow : ValueType{
        public Base pow(Pow p);
    }
}