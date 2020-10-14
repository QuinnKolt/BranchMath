using System;
using System.Linq;
using BranchMath.Math.Value;
using ValueType = BranchMath.Math.Value.ValueType;

namespace BranchMath.Math.Arithmetic {
    public class Product<N> : Mapping<N, N> where N : Multipliable<N>, ValueType {

        public string ToLaTeX() {
            return "\\times";
        }

        public string ClassLaTeX() {
            throw new NotImplementedException();
        }

        public int Arity() {
            return -1;
        }

        public N evaluate(N[] input) {
            var tot = input[0];
            for (var i = 1; i < input.Length; ++i) {
                tot = tot.times(input[i]);
            }

            return tot;
        }

        /// <summary>
        ///     The numbers being added
        /// </summary>
        public string ToLaTeX(N[] summands) {
            return summands.Aggregate("", (current, t) => current + t.ClassLaTeX());
        }
    }
}