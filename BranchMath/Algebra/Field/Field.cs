using System;
using BranchMath.Algebra.Ring;

namespace BranchMath.Algebra.Field {
    public abstract class Field<I> : Ring<I> {
        public override string ClassLaTeX() {
            return "\\mathrm{Field}";
        }

        public Ring<I> GetPolynomialRing() {
            throw new NotImplementedException();
        }
    }
}