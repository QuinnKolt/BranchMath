using System;
using BranchMath.Math.Arithmetic.Number;

namespace BranchMath.Math.Probability.RandomVariable {
    public class ContinuousUniformRandomVariable : ContinuousRandomVariable {
        private RealNumber a;
        private RealNumber b;

        public ContinuousUniformRandomVariable(RealNumber a, RealNumber b) {
            this.a = a;
            this.b = b;
        }
        
        public override RealNumber realize() {
            return (b - a) * new Random().NextDouble() + a;
        }
    }
}