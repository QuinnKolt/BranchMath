using System.Threading.Tasks;
using BranchMath.Tree;

namespace BranchMath.Algebra {
    /// <summary>
    ///     Represents an element in the algebraic structure. Uses an identifier for the structure to distinguish its
    ///     elements. Note that the same element can be used in several algebraic structures.
    /// </summary>
    /// <typeparam name="I">The type of the identifier</typeparam>
    public class AlgebraicElement<I> : ValueType {
        /// <summary>
        ///     Create a new Algebraic Element
        /// </summary>
        /// <param name="identifier"></param>
        public AlgebraicElement(I identifier) {
            Identifier = identifier;
        }

        /// <summary>
        ///     The identifier of this element for distinguishing elements in the algebraic structure
        /// </summary>
        public I Identifier { get; }

        /// <summary>
        ///     Creates a tuple of elements from an array of elements
        /// </summary>
        /// <param name="elems">List of elements</param>
        /// <returns>tuple of elements</returns>
        public static AlgebraicElement<object[]> ToTuple(AlgebraicElement<object>[] elems) {
            var identifiers = new object[elems.Length];

            Parallel.For(0, elems.Length, i => identifiers[i] = (I) elems[i].Identifier);

            return new AlgebraicElement<object[]>(identifiers);
        }

        /// <summary>
        ///     Checks if two elements are equal. Note this will only return true if the operation trees have enough
        ///     information about its variables to simplify the elements to be the same
        /// </summary>
        /// <param name="obj">The object to check</param>
        /// <returns>True if the two elements can be simplified into one another</returns>
        public override bool Equals(object obj) {
            if (obj != null && obj is AlgebraicElement<I> element)
                return element.Identifier.Equals(Identifier);

            return false;
        }

        public override int GetHashCode() {
            return Identifier.GetHashCode();
        }
    }
}