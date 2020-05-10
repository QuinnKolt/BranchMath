namespace BranchMath.Value {
    public interface ValueType {
        /// <summary>
        ///     If a value type can be converted into an object that represents a specific value, then return that object,
        ///     otherwise, return null
        /// </summary>
        /// <returns>Either value of ValueType or null</returns>
        public object evaluate();

        /// <summary>
        ///     Gets the LaTeX representation of this object
        /// </summary>
        /// <returns>string containing LaTeX code for name</returns>
        public string ToLaTeX();

        /// <summary>
        ///     Gets the LaTeX name of the class of objects which this object belongs to
        /// </summary>
        /// <returns>string containing LaTeX code for name/symbol</returns>
        public string ClassLaTeX();
    }
}
