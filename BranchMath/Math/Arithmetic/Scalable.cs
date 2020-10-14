using System.Transactions;
using BranchMath.Math.Value;

namespace BranchMath.Math.Arithmetic {
    public interface Scalable<Self, in Scalar> : Subtractable<Self> where Self : Scalable<Self, Scalar>, ValueType 
        where Scalar : Subtractable<Scalar>, Divideable<Scalar>, ValueType {
        public Self scale(Scalar x);
    }
}