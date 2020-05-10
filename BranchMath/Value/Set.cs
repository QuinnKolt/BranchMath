using BranchMath.Arithmetic.Number;
using BranchMath.Arithmetic.Numbers;

namespace BranchMath.Value {
    public abstract class Set<T> : ValueType where T : ValueType {
        public static readonly ExplicitSet<T> EmptySet = new ExplicitSet<T>();

        /// <summary>
        ///     Returns the size of this set
        /// </summary>
        /// <returns>A Cardinal number representing the size of this set</returns>
        public abstract Cardinal GetCardinality();

        /// <summary>
        ///     Checks if the given value is in this set
        /// </summary>
        /// <param name="obj">The value to check</param>
        /// <returns>Whether or not the value is in this set</returns>
        public abstract bool IsElement(T obj);

        public string ClassLaTeX() {
            return "\\mathrm{Set}";
        }

        public abstract object evaluate();

        public abstract string ToLaTeX();

        public abstract bool IsSubset(Set<T> set);
    }
}