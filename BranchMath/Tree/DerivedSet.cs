using System;
using BranchMath.Numbers;

namespace BranchMath.Tree {
    public class DerivedSet<I> : Set<I> where I : Node {
        private readonly Func<I, bool> _contains;
        private readonly Cardinal cardinality;

        public DerivedSet(Func<I, bool> contains, Cardinal cardinality) {
            _contains = contains;
            this.cardinality = cardinality;
        }

        public bool isElement(I obj) {
            return _contains(obj);
        }

        public Cardinal getCardinality() {
            return cardinality;
        }
    }
}