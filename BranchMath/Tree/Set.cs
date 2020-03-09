namespace BranchMath.Tree {
    public interface Set<T> : Node where T : Node {
        public Node getCardinality() {
            return null;
        }
    }
}