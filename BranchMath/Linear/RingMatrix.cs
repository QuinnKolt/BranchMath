using System;
using BranchMath.Algebra.Ring;
using ValueType = BranchMath.Value.ValueType;

namespace BranchMath.Linear {
    public class RingMatrix<I, R> : ValueType where R : RingElement<I> {
        private R[][] entries;

        public RingMatrix(R[][] entries) {
            this.entries = entries;
        }

        public object evaluate() {
            throw new NotImplementedException();
        }

        public string ToLaTeX() {
            throw new NotImplementedException();
        }

        public string ClassLaTeX() {
            throw new NotImplementedException();
        }
    }
}