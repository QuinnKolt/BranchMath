using System;
using BranchMath.Math.Algebra.Ring;

namespace BranchMath.Math.Algebra.Field {
    public abstract class Field<I> : Ring<I> {
        public override string ClassLaTeX() {
            return "\\mathrm{Field}";
        }

        public Ring<I> GetPolynomialRing() {
            throw new NotImplementedException();
        }
    }
}