namespace BranchMath.Tree {
    public interface ValueType : Node {
        /// <summary>
        /// If a value type can be converted into an object that represents a specific value, then return that object,
        /// otherwise, return null
        /// </summary>
        /// <returns>Either value of ValueType or null</returns>
        public object evaluate() {
            return null;
        }
    }
}