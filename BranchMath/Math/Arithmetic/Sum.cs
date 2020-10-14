using System;
using BranchMath.Math.Value;
using ValueType = BranchMath.Math.Value.ValueType;

namespace BranchMath.Math.Arithmetic {
    /// <summary>
    ///     Represents the sum of many numbers
    /// </summary>
    public class Sum<N> : Mapping<N, N> where N : Summable<N>, ValueType {
        public string ToLaTeX() {
            return "+";
        }

        public int Arity() {
            return -1;
        }
        
        public string ClassLaTeX() {
            throw new NotImplementedException();
        }

        public N evaluate(N[] input) {
            var tot = input[0];
            for (var i = 1; i < input.Length; ++i) {
                tot = tot.plus(input[i]);
            }

            return tot;
        }

        /// <summary>
        ///     The numbers being added
        /// </summary>
        public string ToLaTeX(N[] summands) {
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