using BranchMath.Analysis;
using BranchMath.Value;

namespace BranchMath.Topology {
    public abstract class MetricSpace<I> : TopologicalSpace<I> where I : ValueType {
        private Metric<I> _metric;

        public MetricSpace(Metric<I> metric) {
            _metric = metric;
        }

        public override bool IsClosed(ExplicitSet<I> set) {
            return true;
        }

        public override bool IsOpen(ExplicitSet<I> set) {
            return set == Set<I>.EmptySet;
        }
    }
}