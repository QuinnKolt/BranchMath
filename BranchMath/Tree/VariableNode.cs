using System;
using ValueType = BranchMath.Value.ValueType;

namespace BranchMath.Tree {
    /// <summary>
    ///     Represents a variable in
    /// </summary>
    /// <typeparam name="I"></typeparam>
    public class VariableNode<I> : ValueNode<I> where I : ValueType {
        /// <summary>
        ///     The representation of this variable in LaTeX (e.g. x or \omega)
        /// </summary>
        private readonly string rep;

        /// <summary>
        ///     Create a new variable
        /// </summary>
        /// <param name="rep">The LaTeX representation of the variable</param>
        public VariableNode(string rep) {
            this.rep = rep;
        }

        public I evaluate() {
            throw new NullReferenceException();
        }

        public string ToLaTeX() {
            return rep;
        }
    }
}