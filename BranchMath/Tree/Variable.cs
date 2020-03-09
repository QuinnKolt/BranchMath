namespace BranchMath.Tree {
    public class Variable<I> : Node where I : Node {
        private readonly string rep;
        public Variable(string rep) {
            this.rep = rep;
        }

        public override string ToString() {
            return rep;
        }
    }
}