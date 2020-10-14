using BranchMath.Math.Arithmetic.Number;
using BranchMath.Math.Value;

namespace BranchMath.Math.Arithmetic.Trigonometry {
    public class Cosine : MonoFunction<RealNumber, RealNumber> {
        public static Cosine COS = new Cosine();
        
        private Cosine(){}
        
        public override string ToLaTeX() {
            return @"\cos";
        }

        public override string ClassLaTeX() {
            return @"\mathbb{R}\to[-1,1]";
        }

        public override RealNumber evaluate(RealNumber input) {
            return new RealNumber(System.Math.Cos((double) input.evaluate()));
        }

        public override string ToLaTeX(RealNumber input) {
            return $"\\sin({input.ToLaTeX()})";
        }
    }
}