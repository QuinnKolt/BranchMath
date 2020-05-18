using System;
using System.Collections.Generic;
using System.Linq;
using BranchMath.Arithmetic.Number;

namespace BranchMath.Value {
    /// <summary>
    ///     Represents a mathematical set
    /// </summary>
    /// <typeparam name="I">The type of objects contained within the set</typeparam>
    public class ExplicitSet<I> : Set<I> where I : ValueType {
        /// <summary>
        ///     Construct an empty set, which can have elements added
        /// </summary>
        public ExplicitSet() {
            Elements = new HashSet<I>();
        }

        /// <summary>
        ///     Construct a mathematical set given a HashSet
        /// </summary>
        /// <param name="elements">The collection of objects in the set</param>
        public ExplicitSet(IEnumerable<I> elements) {
            Elements = elements.ToHashSet();
        }

        /// <summary>
        ///     The HashSet holding the elements of the mathematical set.
        /// </summary>
        public HashSet<I> Elements { get; protected set; }

        public override bool IsElement(I obj) {
            return Elements.Contains(obj);
        }

        public override Cardinal GetCardinality() {
            return new Cardinal(Elements.Count, 0);
        }

        public override string ToLaTeX() {
            if (Elements.Count == 0)
                return "\\varnothing";

            var latex = "\\{";
            foreach (var el in Elements) {
                latex += el.ToLaTeX();
                latex += ", ";
            }

            latex = latex.Substring(0, latex.Length - 2);
            latex += "\\}";

            return latex;
        }

        public override object evaluate() {
            return Elements;
        }

        public override bool IsSubset(Set<I> set) {
            if (set is ExplicitSet<I> explicitSet) return explicitSet.Elements.IsSubsetOf(Elements);
            throw new NotImplementedException();
        }
    }
}