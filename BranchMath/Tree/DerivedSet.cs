using System;

namespace BranchMath.Tree {
    public class DerivedSet<I> : Set<I> where I : Node {
        private readonly Func<I, bool> _contains; 

        public DerivedSet(Func<I, bool> contains) {
            _contains = contains;
        }

        public bool isElement(I obj) {
            return _contains(obj);
        }
    }
}