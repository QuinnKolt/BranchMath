using BranchMath.Arithmetic.Numbers;
using BranchMath.Value;

namespace BranchMath.Arithmetic {
    /// <summary>
    ///     Represents the sum of many numbers
    /// </summary>
    public class Sum<N> : Mapping<N, N> where N : Number.Number {
        public Sum() {}

        public override string ToLaTeX() {
            return "+";
        }

        public override string ClassLaTeX() {
            throw new System.NotImplementedException();
        }

        public override N evaluate(N[] input) {
            throw new System.NotImplementedException();
        }

        /// <summary>
        ///     The numbers being added
        /// </summary>
        public override string ToLaTeX(N[] summands) {
            var latex = "";
            for (var i = 0; i < summands.Length; ++i) {
                latex += summands[i].ClassLaTeX();
                if (i != summands.Length - 1)
                    latex += " + ";
            }

            return latex;
        }
    }
}