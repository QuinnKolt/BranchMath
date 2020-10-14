using BranchMath.Math.Arithmetic.Number;
using BranchMath.Math.Logic;
using BranchMath.Math.Value;

namespace BranchMath.Math.Set {
    public abstract class Set<T> : ValueType where T : ValueType {
        public static readonly ExplicitSet<T> EmptySet = new ExplicitSet<T>();

        public string ClassLaTeX() {
            return "\\mathrm{Set}";
        }

        public abstract object evaluate();

        public abstract string ToLaTeX();

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
        public abstract Boolean IsElement(T obj);

        public abstract Boolean IsSubset(Set<T> set);
    }
}