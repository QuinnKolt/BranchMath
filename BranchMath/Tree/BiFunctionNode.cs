using System;
using System.Collections.Generic;
using System.Linq;
using BranchMath.Value;
using ValueType = BranchMath.Value.ValueType;

namespace BranchMath.Tree {
    /// <summary>
    ///     Represents a non-leaf node in the operation tree
    /// </summary>
    /// <typeparam name="C">Codomain of operation</typeparam>
    /// <typeparam name="D1">Domain of first argument</typeparam>
    /// <typeparam name="D2">Domain of second argument</typeparam>
    public class BiFunctionNode<D1, D2, C> : OperationNode<C> where C : ValueType where D1 : ValueType where D2 : ValueType {
        private readonly BiFunction<D1, D2, C> map;

        private Node<D1> node1;
        private Node<D2> node2;
        private List<SimplificationRule<C>> rules = new List<SimplificationRule<C>>();

        public BiFunctionNode(BiFunction<D1, D2, C> map, Node<D1> node1, Node<D2> node2, List<SimplificationRule<C>> rules) {
            this.node1 = node1;
            this.node2 = node2;
            this.map = map;
            this.rules = rules;
        }

        public BiFunctionNode(BiFunction<D1, D2, C> map, Node<D1> node1, Node<D2> node2) {
            this.node1 = node1;
            this.node2 = node2;
            this.map = map;
        }

        /// <summary>
        ///     Simplify this object using the set of simplification rules
        /// </summary>
        /// <returns></returns>
        public Node<C> simplify() {
            throw new NotImplementedException();
        }

        public Node<ValueType>[] GetChildren() {
            return new []{(Node<ValueType>) node1.DeepCopy(), (Node<ValueType>) node2.DeepCopy()};
        }

        public OperationNode<C> CopyWithNewChildren(Node<ValueType>[] children) {
            var n1 = children[0] as Node<D1>;
            var n2 = children[1] as Node<D2>;
            return new BiFunctionNode<D1, D2, C>(map, n1, n2, rules);
        }

        public C evaluate() {
            return map.evaluate(node1.evaluate(), node2.evaluate());
        }

        public Node<C> DeepCopy() {
            return new BiFunctionNode<D1, D2, C>(map, node1.DeepCopy(), node2.DeepCopy(), rules);
        }

        public string ToLaTeX() {
            throw new NotImplementedException();
        }

        public bool Matches(Node<ValueType> node) {
            if (node is BiFunctionNode<D1, D2, C> mappingNode) {
                return mappingNode.map == map;
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
            
            str += map.ToLaTeX() + "\n";
            str += node1.structure(indents + 1);
            str += "\n";
            str += node2.structure(indents + 1);

            return str;
        }
        
        
        public bool DeepEquals(Node<ValueType> node) {
            if (node is BiFunctionNode<D1, D2, C> mapNode) {
                return map == mapNode.map && node1.Equals(mapNode.node1) && node2.Equals(mapNode.node2);
            }

            return false;
        }
    }
}