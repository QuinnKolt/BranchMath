using System;
using BranchMath.Value;

namespace BranchMath.Arithmetic {
    /// <summary>
    ///     Represents the sum of many numbers
    /// </summary>
    public class Power<N, M> : Mapping<N, M> where N : Number.Number where M : Number.Number {
        public Power() : base(2) { }

        public override string ToLaTeX() {
            return "^";
        }

        public override string ClassLaTeX() {
            throw new NotImplementedException();
        }

        public override M evaluate(N[] input) {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     The numbers being added
        /// </summary>
        public override string ToLaTeX(N[] summands) {
            return $"{summands[0]}^{{{summands[1]}}}";
        }
    }
}