using System;
using System.Collections.Generic;
using ValueType = BranchMath.Math.Value.ValueType;

namespace BranchMath.Tree {
    public class LaTeXConversionRule<R> where R : ValueType {
        private string[] parts;
        private Node<R> convert;
        private string[] types;
        private Variable<ValueType>[] inputs;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parts"></param>
        /// <param name="types">
        /// i - LaTeX input, {} (Ex. \frac{1}{2} or \frac 1 2)
        /// c - curly braces, \{\} (Ex. \{1,2,3,4\})
        /// s - square brackets, [] (Ex. Var[X])
        /// p - parentheses () (Ex. \cos(x))
        /// e - empty (Ex. \sin x)
        /// N - no input (Variables will be placed at both the start and end, so if it is not desired to have this,
        /// N will allow a variable to be omitted.)
        /// </param>
        /// <param name="convert"></param>
        /// <param name="inputs"></param>
        public LaTeXConversionRule(string[] parts, string[] types, Node<R> convert, Variable<ValueType>[] inputs) {
            this.parts = parts;
            this.types = types;
            this.convert = convert;
            this.inputs = inputs;
        }
    }
}