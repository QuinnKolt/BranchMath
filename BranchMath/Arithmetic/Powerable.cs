using BranchMath.Value;

namespace BranchMath.Arithmetic {
    public interface Powerable<Base, Pow> where Base : ValueType where Pow : ValueType{
        public Base pow(Pow p);
    }
}