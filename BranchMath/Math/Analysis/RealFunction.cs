using System;
using BranchMath.Math.Arithmetic;
using BranchMath.Math.Arithmetic.Number;
using BranchMath.Math.Value;

namespace BranchMath.Math.Analysis {
    public abstract class RealFunction : MonoFunction<RealNumber, RealNumber>, Scalable<RealFunction, RealNumber>, Multipliable<RealFunction> {
        public RealFunction plus(RealFunction a) {
            throw new System.NotImplementedException();
        }

        public RealFunction getZero() {
            throw new System.NotImplementedException();
        }

        public RealFunction minus(RealFunction r) {
            throw new System.NotImplementedException();
        }

        public RealFunction scale(RealNumber x) {
            throw new System.NotImplementedException();
        }

        public RealFunction times(RealFunction a) {
            throw new System.NotImplementedException();
        }

        public RealFunction pow(Natural p) {
            throw new NotImplementedException();
        }
    }
}