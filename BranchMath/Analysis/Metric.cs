using BranchMath.Arithmetic.Number;
using BranchMath.Value;

namespace BranchMath.Analysis {
    public abstract class Metric<I> : Mapping<I, RealNumber> where I : ValueType {
        public override string ToLaTeX(I[] inputs) {
            return $"\\left\\|{inputs[0]}\\right\\|";
        }
    }
}