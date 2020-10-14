using System;
using ValueType = BranchMath.Math.Value.ValueType;

namespace BranchMath.Tree {
    /// <summary>
    ///     Represents a variable in
    /// </summary>
    /// <typeparam name="V"></typeparam>
    public class VariableNode<V> : Variable<V> where V : ValueType {
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

        public Node<V> DeepCopy() {
            return this;
        }

        public V GetValue() {
            throw new NullReferenceException();
        }

        public string ToLaTeX() {
            return rep;
        }
        
        public bool Matches(Node<ValueType> node) {
            return node is Node<V>;
        }

        public Assignment MakeAssignment(Node<V> node) {
            return new Assignment(this, node);
        }
        
        public class Assignment {
            internal VariableNode<V> var;
            internal Node<V> val;
            public Assignment(VariableNode<V> var, Node<V> val) {
                this.var = var;
                this.val = val;
            }
        }
        
        public string structure(int indents) {

            var str = "";
            if (indents > 0) {
                for (var i = 0; i < indents - 1; ++i)
                    str += "|   ";

                str += "|-  ";
            }
            
            return  str + rep;
        }


        public bool DeepEquals(Node<ValueType> node) {
            return this == node;
        }
    }
}