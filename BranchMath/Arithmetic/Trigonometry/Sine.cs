using System;
using BranchMath.Arithmetic.Number;
using BranchMath.Value;

namespace BranchMath.Arithmetic.Trigonometry {
    public class Sine : MonoFunction<RealNumber, RealNumber> {
        public static Sine SIN = new Sine();
        
        private Sine(){}
        
        public override string ToLaTeX() {
            return @"\sin";
        }

        public override string ClassLaTeX() {
            return @"\mathbb{R}\to[-1,1]";
        }

        public override RealNumber evaluate(RealNumber input) {
            return new RealNumber(Math.Sin((double) input.evaluate()));
        }

        public override string ToLaTeX(RealNumber input) {
            return $"\\sin({input.ToLaTeX()})";
        }
    }
}