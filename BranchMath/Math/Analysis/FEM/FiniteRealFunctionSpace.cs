using BranchMath.Math.Arithmetic.Number;
using BranchMath.Math.Logic;

namespace BranchMath.Math.Analysis.FEM {
    public abstract class FiniteRealFunctionSpace : FiniteDimensionalFunctionSpace<RealNumber, RealNumber, RealNumber> {
        public FiniteRealFunctionSpace(Mesh mesh) {
            
        }

        public abstract Integer getDimension();
        public abstract string ToLaTeX();
        public abstract string ClassLaTeX();
    }
}