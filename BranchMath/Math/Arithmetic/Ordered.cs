using BranchMath.Math.Logic;
using BranchMath.Math.Value;

namespace BranchMath.Math.Arithmetic {
    public interface Ordered<in Self> where Self : Ordered<Self>, ValueType {
        public Boolean is_less_than(Self s);
    }
}