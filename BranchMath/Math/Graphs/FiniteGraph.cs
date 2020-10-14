

using System.Collections.Generic;
using BranchMath.Math.Logic;
using BranchMath.Math.Set;
using BranchMath.Math.Value;

namespace BranchMath.Math.Graphs {
    public class FiniteGraph<N> : Graph<N> where N : ValueType {
        private readonly ExplicitSet<N> nodes;
        private readonly ExplicitSet<Tuple<N>> neighbors;

        public FiniteGraph(ExplicitSet<N> nodes, ExplicitSet<Tuple<N>> neighbors) {
            this.nodes = nodes;
            this.neighbors = neighbors;
        }

        public override Set<N> GetNeighbors(N n) {
            var neigh = new HashSet<N>();
            foreach (var nb in neighbors.Elements) {
                if (nb[0].Equals(n)) {
                    neigh.Add(nb[1]);
                }
                else if (nb[1].Equals(n)) {
                    neigh.Add(nb[0]);
                }
            }

            return new ExplicitSet<N>(neigh);
        }

        public override Boolean areConnected(N n, N m) {
            foreach (var nb in neighbors.Elements) {
                if (nb[0].Equals(n) && nb[1].Equals(m)) {
                    return true;
                }
                if (nb[0].Equals(n) && nb[1].Equals(m)) {
                    return true;
                }
            }

            return false;
        }
    }
}