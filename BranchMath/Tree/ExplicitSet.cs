using System.Collections.Immutable;

namespace BranchMath.Tree {
    /// <summary>
    ///     Represents a mathematical set
    /// </summary>
    /// <typeparam name="I">The type of objects contained within the set</typeparam>
    public class ExplicitSet<I> : Set<I> where I : Node {
        /// <summary>
        ///     Construct an empty set, which can have elements added
        /// </summary>
        public ExplicitSet() {
            Elements = ImmutableHashSet<I>.Empty;
        }

        /// <summary>
        ///     Construct a mathematical set given a HashSet
        /// </summary>
        /// <param name="elements">The HashSet</param>
        public ExplicitSet(ImmutableHashSet<I> elements) {
            Elements = elements;
        }

        /// <summary>
        ///     The HashSet holding the elements of the mathematical set.
        /// </summary>
        public ImmutableHashSet<I> Elements { get; protected set; }
    }
}