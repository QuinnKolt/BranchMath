namespace BranchMath.Value {
    /// <summary>
    ///     Corresponds to a value type which cannot be converted to a standard C# type.
    /// </summary>
    public abstract class AtomicValueType : ValueType {
        /// <summary>
        ///     Evaluate will simply return this object because it cannot be simplified.
        /// </summary>
        /// <returns>this</returns>
        public virtual object evaluate() {
            return this;
        }

        public abstract string ToLaTeX();

        public abstract string ClassLaTeX();
    }
}