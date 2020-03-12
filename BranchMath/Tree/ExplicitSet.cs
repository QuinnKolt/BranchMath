using System.Collections.Generic;
using System.Collections.Immutable;
using BranchMath.Numbers;

namespace BranchMath.Tree {
    /// <summary>
    ///     Represents a mathematical set
    /// </summary>
    /// <typeparam name="I">The type of objects contained within the set</typeparam>
    public class ExplicitSet<I> : Set<I> where I : ValueType {
        /// <summary>
        ///     The HashSet holding the elements of the mathematical set.
        /// </summary>
        public HashSet<I> Elements { get; protected set; }
        
        /// <summary>
        ///     Construct an empty set, which can have elements added
        /// </summary>
        public ExplicitSet() {
            Elements = new HashSet<I>();
        }

        /// <summary>
        ///     Construct a mathematical set given a HashSet
        /// </summary>
        /// <param name="elements">The HashSet</param>
        public ExplicitSet(HashSet<I> elements) {
            Elements = elements;
        }


        public bool isElement(I obj) {
            return Elements.Contains(obj);
        }

        public Cardinal getCardinality() {
            return new Cardinal(Elements.Count,0);
        }
    }
}