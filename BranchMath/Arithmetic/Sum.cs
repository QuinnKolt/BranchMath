﻿using System;
using System.Threading.Tasks;
using BranchMath.Value;
using ValueType = BranchMath.Value.ValueType;

namespace BranchMath.Arithmetic {
    /// <summary>
    ///     Represents the sum of many numbers
    /// </summary>
    public class Sum<N> : Mapping<N, N> where N : Summable<N>, ValueType {
        public Sum() : base(-1) { }

        public override string ToLaTeX() {
            return "+";
        }

        public override string ClassLaTeX() {
            throw new NotImplementedException();
        }

        public override N evaluate(N[] input) {
            var tot = input[0];
            for (var i = 1; i < input.Length; ++i) {
                tot = tot.sum(input[i]);
            }

            return tot;
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