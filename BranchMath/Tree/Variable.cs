namespace BranchMath.Tree {
    public class Variable<I> : Node<I> where I : ValueType {
        private readonly string rep;
        public I value { get; private set; } 
        
        public Variable(string rep) {
            this.rep = rep;
            this.value = default(I);
        }

        public override string ToString() {
            return rep;
        }

        public I assign(I val) {
            var temp = value;
            value = val;
            return temp;
        }
    }
}