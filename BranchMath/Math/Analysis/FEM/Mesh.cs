using BranchMath.Math.Graphs;
using BranchMath.Math.Set;
using BranchMath.Math.Value;

namespace BranchMath.Math.Analysis.FEM {
    public abstract class Mesh : FiniteGraph<Coordinate> {
        protected Mesh(ExplicitSet<Coordinate> nodes, ExplicitSet<Tuple<Coordinate>> neighbors) :
            base(nodes, neighbors) {
            
        }
    }
}