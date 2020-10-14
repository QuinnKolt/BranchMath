using BranchMath.Math.Arithmetic;
using BranchMath.Math.Arithmetic.Number;
using BranchMath.Math.Value;

namespace BranchMath.Math.Analysis.FEM {
    public interface FiniteDimensionalFunctionSpace<R, S, F> : ValueType
      where R : Scalable<R, F>, Subtractable<R>, Multipliable<R>, ValueType 
      where S : Scalable<S, F>, Subtractable<S>, Multipliable<S>, ValueType 
      where F : FieldLikeObject<F> {
        public abstract Integer getDimension();
        
        
    }
}