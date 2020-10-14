using BranchMath.Math.Arithmetic.Number;
using BranchMath.Math.Value;

namespace BranchMath.Math.Analysis {
    public abstract class Metric<I> : MonoFunction<I, RealNumber> where I : ValueType {
        public override string ToLaTeX(I input) {
            return $"\\left\\|{input}\\right\\|";
        }
    }
}