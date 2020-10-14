using BranchMath.Math.Value;

namespace BranchMath.Math.Arithmetic {
    public interface FieldLikeObject<S> : Divideable<S>, Scalable<S, S>, ValueType where S : FieldLikeObject<S> {
        
    }
}