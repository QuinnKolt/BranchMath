using System;
using BranchMath.Numbers;

namespace BranchMath.Tree {
    public class DerivedSet<I> : Set<I> where I : ValueType {
        private readonly Func<I, bool> _contains;
        /// <summary>
        /// The cardinality of this set; null if not known.
        /// </summary>
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