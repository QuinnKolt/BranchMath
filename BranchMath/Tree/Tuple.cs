namespace BranchMath.Tree {
    public class Tuple<I> : ValueType where I : ValueType {
        private I[] entries;
        
        public Tuple(I[] entries) {
            this.entries = entries;
        }

        public I[] evaluate() {
            return entries;
        }
    }
}