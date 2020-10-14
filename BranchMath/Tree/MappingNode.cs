using System;
using System.Collections.Generic;
using System.Linq;
using BranchMath.Math.Value;
using ValueType = BranchMath.Math.Value.ValueType;

namespace BranchMath.Tree {
    /// <summary>
    ///     Represents a non-leaf node in the operation tree
    /// </summary>
    /// <typeparam name="C">Codomain of operation</typeparam>
    /// <typeparam name="D">Domain of operation</typeparam>
    public class MappingNode<D, C> : OperationNode<C> where C : ValueType where D : ValueType {
        private readonly Mapping<D, C> map;

        private readonly Node<D>[] nodes;
        private List<SimplificationRule<C>> rules = new List<SimplificationRule<C>>();

        public MappingNode(Mapping<D, C> map, Node<D>[] nodes, List<SimplificationRule<C>> rules) {
            if (nodes.Length != map.Arity() && map.Arity() != -1) throw new InvalidCastException();
            this.nodes = nodes;
            this.map = map;
            this.rules = rules;
        }

        public MappingNode(Mapping<D, C> map, Node<D>[] nodes) {
            if (nodes.Length != map.Arity() && map.Arity() != -1) throw new InvalidCastException();
            this.map = map;
            this.nodes = nodes;
        }

        /// <summary>
        ///     Simplify this object using the set of simplification rules
        /// </summary>
        /// <returns></returns>
        public Node<C> simplify() {
            throw new NotImplementedException();
        }

        public Node<ValueType>[] GetChildren() {
            var copied = new Node<ValueType>[nodes.Length];
            for(var i = 0; i < nodes.Length; ++i) {
                copied[i] = (Node<ValueType>) nodes[i];
            }

            return copied;
        }

        public OperationNode<C> CopyWithNewChildren(Node<ValueType>[] children) {
            var node = new Node<D>[children.Length];
            for (var i = 0; i < children.Length; ++i)
                node[i] = (Node<D>) children[i];
            return new MappingNode<D, C>(map, node, rules);
        }

        public Operator<C> getOperator() {
            return map;
        }

        public C GetValue() {
            var inp = new D[nodes.Length];
            for (var i = 0; i < nodes.Length; ++i)
                inp[i] = nodes[i].GetValue();
            return map.evaluate(inp);
        }

        public Node<C> DeepCopy() {
            var copied = new Node<D>[nodes.Length];
            for (var i = 0; i < nodes.Length; ++i)
                copied[i] = nodes[i].DeepCopy();
            return new MappingNode<D, C>(map, copied);
        }
        
        public bool DeepEquals(Node<ValueType> node) {
            if (!(node is MappingNode<D, C> mapNode)) 
                return false;
            
            if (map != mapNode.map)
                return false;
            return !nodes.Where((t, i) => !t.DeepEquals((Node<ValueType>) mapNode.nodes[i])).Any();

        }

        public string ToLaTeX() {
            throw new NotImplementedException();
        }

        public bool Matches(Node<ValueType> node) {
            if (node is MappingNode<D, C> mappingNode) {
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
            for (var i = 0; i < nodes.Length; ++i) {
                str += nodes[i].structure(indents + 1);
                if(i < nodes.Length-1) 
                    str += "\n";
            }

            return str;
        }
    }
}