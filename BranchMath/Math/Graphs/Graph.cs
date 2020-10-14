using BranchMath.Math.Logic;
using BranchMath.Math.Set;
using BranchMath.Math.Value;

namespace BranchMath.Math.Graphs {
    public abstract class Graph<N> : ValueType where N : ValueType {
        public string ToLaTeX() {
            throw new System.NotImplementedException();
        }

        public string ClassLaTeX() {
            throw new System.NotImplementedException();
        }

        public abstract Set<N> GetNeighbors(N n);

        public abstract Boolean areConnected(N n, N m);
    }
}