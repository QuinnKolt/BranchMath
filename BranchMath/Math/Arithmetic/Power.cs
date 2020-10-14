using System;
using BranchMath.Math.Value;
using ValueType = BranchMath.Math.Value.ValueType;

namespace BranchMath.Math.Arithmetic {
    /// <summary>
    ///     Represents the sum of many numbers
    /// </summary>
    public class Power<B, P> : BiFunction<B, P, B> where B : Powerable<B, P>, ValueType where P : ValueType {
        public string ToLaTeX() {
            return "^";
        }

        public string ClassLaTeX() {
            throw new NotImplementedException();
        }

        public B evaluate(B input1, P input2) {
            return input1.pow(input2);
        }

        public string ToLaTeX(B input1, P input2) {
            return $"{input1.ToLaTeX()}^{{{input2.ToLaTeX()}}}";
        }
    }
}