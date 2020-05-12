using System;
using System.Collections.Generic;
using BranchMath.Arithmetic.Number;
using BranchMath.Arithmetic.Numbers;

namespace BranchMath.Value {
    /// <summary>
    /// </summary>
    /// <typeparam name="I">The type of objects which are stored in this set</typeparam>
    public class DerivedSet<I> : Set<I> where I : ValueType {
        private readonly Func<I, bool> _contains;

        /// <summary>
        ///     The cardinality of this set; null if not known.
        /// </summary>
        private readonly Cardinal cardinality;

        private readonly string rules;

        /// <summary>
        ///     Create a set using a condition
        /// </summary>
        /// <param name="contains"></param>
        /// <param name="cardinality"></param>
        /// <param name="rules"></param>
        public DerivedSet(Func<I, bool> contains, Cardinal cardinality, string rules) {
            _contains = contains;
            this.cardinality = cardinality;
            this.rules = rules;
        }

        public override bool IsElement(I obj) {
            return _contains(obj);
        }

        public override Cardinal GetCardinality() {
            return cardinality;
        }

        public override string ToLaTeX() {
            return "\\{ x | " + rules + " \\}";
        }

        public override object evaluate() {
            throw new NotImplementedException();
        }

        public override bool IsSubset(Set<I> set) {
            if (set is ExplicitSet<I> explicitSet) {
                foreach (var elem in explicitSet.Elements)
                    if (!IsElement(elem))
                        return false;

                return true;
            }

            throw new NotImplementedException();
        }
    }
}