using BranchMath.Value;

namespace BranchMath.Topology {
    public abstract class TopologicalSpace<I> : ValueType where I : ValueType {
        public abstract string ToLaTeX();

        public string ClassLaTeX() {
            return "\\mathrm{Top}";
        }

        public abstract bool IsOpen(ExplicitSet<I> set);

        public abstract bool IsClosed(ExplicitSet<I> set);
    }
}