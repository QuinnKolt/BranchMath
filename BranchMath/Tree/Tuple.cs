namespace BranchMath.Tree {
    public class Tuple : ValueType {
        private readonly ValueType[] entries;
        
        public Tuple(ValueType[] entries) {
            this.entries = entries;
        }

        public ValueType[] evaluate() {
            return entries;
        }
    }
}