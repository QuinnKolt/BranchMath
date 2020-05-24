using System;
using System.Linq;
using BranchMath.Value;
using ValueType = BranchMath.Value.ValueType;

namespace BranchMath.Arithmetic {
    public class Product<N> : Mapping<N, N> where N : Multipliable<N>, ValueType {
        public Product() : base(-1) { }

        public override string ToLaTeX() {
            return "\\times";
        }

        public override string ClassLaTeX() {
            throw new NotImplementedException();
        }

        public override N evaluate(N[] input) {
            var tot = input[0];
            for (var i = 1; i < input.Length; ++i) {
                tot = tot.times(input[i]);
            }

            return tot;
        }

        /// <summary>
        ///     The numbers being added
        /// </summary>
        public override string ToLaTeX(N[] summands) {
            return summands.Aggregate("", (current, t) => current + t.ClassLaTeX());
        }
    }
}