using BranchMath.Arithmetic.Numbers;
using BranchMath.Value;

namespace BranchMath.Arithmetic {
    /// <summary>
    ///     Represents the sum of many numbers
    /// </summary>
    public class Sum<N> : Mapping<N> where N : Number.Number {
        /// <summary>
        ///     The numbers being added
        /// </summary>
        public N[] summands;

        public Sum(N[] summands) {
            this.summands = summands;
        }

        public override string ToLaTeX() {
            var latex = "";
            for (var i = 0; i < summands.Length; ++i) {
                latex += summands[i].ClassLaTeX();
                if (i != summands.Length - 1)
                    latex += " + ";
            }

            return latex;
        }

        public override string ClassLaTeX() {
            return summands[0].ClassLaTeX();
        }
    }
}