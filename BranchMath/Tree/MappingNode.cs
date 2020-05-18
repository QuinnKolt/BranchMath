using System;
using System.Collections.Generic;
using BranchMath.Value;
using ValueType = BranchMath.Value.ValueType;

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
            if (nodes.Length != map.arity && map.arity == -1) throw new InvalidCastException();
            this.nodes = nodes;
            this.map = map;
            this.rules = rules;
        }

        public MappingNode(Mapping<D, C> map, Node<D>[] nodes) {
            if (nodes.Length != map.arity && map.arity == -1) throw new InvalidCastException();
            this.nodes = nodes;
        }

        /// <summary>
        ///     Simplify this object using the set of simplification rules
        /// </summary>
        /// <returns></returns>
        public Node<C> simplify() {
            throw new NotImplementedException();
        }

        public C evaluate() {
            var inp = new D[nodes.Length];
            for (var i = 0; i < nodes.Length; ++i)
                inp[i] = nodes[i].evaluate();
            return map.evaluate(inp);
        }

        public Node<C> DeepCopy() {
            var copied = new Node<D>[nodes.Length];
            for (var i = 0; i < nodes.Length; ++i)
                copied[i] = nodes[i].DeepCopy();
            return new MappingNode<D, C>(map, copied);
        }

        public string ToLaTeX() {
            throw new NotImplementedException();
        }
    }
}