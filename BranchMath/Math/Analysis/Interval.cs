using BranchMath.Math.Arithmetic.Number;
using BranchMath.Math.Logic;
using BranchMath.Math.Set;

namespace BranchMath.Math.Analysis {
    public class Interval : DerivedSet<RealNumber> {
        public RealNumber[] lowerbounds;
        public RealNumber[] upperbounds;

        public Interval(RealNumber[] lowerbounds, RealNumber[] upperbounds) {
            
        }

        public override Boolean IsElement(RealNumber obj) {
            return base.IsElement(obj);
        }

        public override object evaluate() {
            return base.evaluate();
        }

        public override Boolean IsSubset(Set<RealNumber> set) {
            return base.IsSubset(set);
        }

        public override Cardinal GetCardinality() {
            return base.GetCardinality();
        }

        public override string ToLaTeX() {
            return base.ToLaTeX();
        }
    }
}