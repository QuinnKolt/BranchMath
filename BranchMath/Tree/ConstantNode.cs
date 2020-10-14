using System;
using ValueType = BranchMath.Math.Value.ValueType;

namespace BranchMath.Tree {
    /// <summary>
    ///     Represents a constant value as a node in the operation tree. This can be anything from a function (itself/no
    ///     variables)
    ///     to a group to a number.
    /// </summary>
    /// <typeparam name="V">The type of value which this constant represents</typeparam>
    public class ConstantNode<V> : ValueNode<V> where V : ValueType {
        public readonly V value;

        /// <summary>
        ///     Constructs a new constant
        /// </summary>
        /// <param name="value">The value of the constant</param>
        public ConstantNode(V value) {
            this.value = value;
        }

        public Node<V> DeepCopy() {
            return new ConstantNode<V>(value);
        }
        
        public V GetValue() {
            return value;
        }

        public string ToLaTeX() {
            return value.ToLaTeX();
        }
        
        public bool Matches(Node<ValueType> node) {
            
            if (node is ConstantNode<V> constantNode) {
                return constantNode.value.Equals(value);
            }

            return false;
        }
        
        public string structure(int indents) {
            var str = "";
            if (indents > 0) {
                for (var i = 0; i < indents - 1; ++i)
                    str += "|   ";

                str += "|-  ";
            }

            return str + value.ToLaTeX();
        }


        public bool DeepEquals(Node<ValueType> node) {
            if (node is ConstantNode<V> constantNode) {
                return value.Equals(constantNode.value);
            }

            return false;
        }
    }
}