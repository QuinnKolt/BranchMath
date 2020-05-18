using BranchMath.Value;

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
        /// <param name="identifier">Identifier that allows manipulation of the element</param>
        /// <param name="structure">The structure to which this element belongs to</param>
        public AlgebraicElement(I identifier, AlgebraicStructure<I> structure) {
            Identifier = identifier;
            this.structure = structure;
        }

        /// <summary>
        ///     The identifier of this element for distinguishing elements in the algebraic structure
        /// </summary>
        public I Identifier { get; }

        public AlgebraicStructure<I> structure { protected get; set; }

        public virtual object evaluate() {
            return Identifier;
        }

        public virtual string ToLaTeX() {
            return structure.DisplayElement(this);
        }

        public virtual string ClassLaTeX() {
            return structure.ToLaTeX();
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

        /// <summary>
        ///     The hashcode of this element is only its identifier. The structure to which
        ///     the group belongs is not relevant
        /// </summary>
        /// <returns>The hash of the identifier</returns>
        public override int GetHashCode() {
            return Identifier.GetHashCode();
        }
    }
}