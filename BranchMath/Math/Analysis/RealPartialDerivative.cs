using System.Linq;
using BranchMath.Math.Arithmetic.Number;
using BranchMath.Math.Value;

namespace BranchMath.Math.Analysis {
    public class RealPartialDerivative : MonoFunction<Mapping<RealNumber, RealNumber>, Mapping<RealNumber, RealNumber>> {
        private int var = 0;
        public static double Precision { get; set; } = .000001;

        public RealPartialDerivative(int index) {
            var = index;
        }
        
        public override string ToLaTeX() {
            return $"\\dfrac{{\\partial}}{{\\partial x_{{{var+1}}}";
        }

        public override string ClassLaTeX() {
            return @"\mathbb{R}^{\mathbb{R}}\to\mathbb{R}^{\mathbb{R}}";
        }

        public override Mapping<RealNumber, RealNumber> evaluate(Mapping<RealNumber, RealNumber> input) {
            return new DifferentiatedFunction(input, var);
        }

        public override string ToLaTeX(Mapping<RealNumber, RealNumber> input) {
            return $"\\dfrac{{\\partial {input.ToLaTeX()}}}{{\\partial x_{{{var+1}}}}}";
        }

        private class DifferentiatedFunction : Mapping<RealNumber, RealNumber> {
            private readonly int var = 0;
            private readonly Mapping<RealNumber, RealNumber> func;

            public DifferentiatedFunction(Mapping<RealNumber, RealNumber> func, int var) {
                this.var = var;
                this.func = func;
            }

            public string ToLaTeX() {
                return $"\\dfrac{{\\partial {func.ToLaTeX()}}}{{\\partial x_{{{var+1}}}";
            }

            public string ClassLaTeX() {
                return @"\mathbb{R}\to\mathbb{R}";
            }

            public int Arity() {
                return func.Arity();
            }

            public RealNumber evaluate(RealNumber[] input) {
                var varlow = (double) input[var].evaluate() - Precision;
                var varhigh = (double) input[var].evaluate() + Precision;
                
                var Xlow = input.ToArray();
                var Xhigh = input.ToArray();
                
                Xlow[var] = new RealNumber(varlow);
                Xhigh[var] = new RealNumber(varhigh);

                var flow = (double) func.evaluate(Xlow).evaluate();
                var fhigh = (double) func.evaluate(Xhigh).evaluate();
                
                return new RealNumber((fhigh - flow) / (2 * Precision));
            }

            public string ToLaTeX(RealNumber[] inputs) {
                var st = "";
                
                for(var i = 0; i < inputs.Length; ++i) {
                    st += $"x_{{{i}}}";
                    if (i != inputs.Length)
                        st += ",";
                }
                
                return $"\\dfrac{{\\partial {func.ToLaTeX()}}}{{\\partial x_{{{var+1}}}({st})";
            }
        }

    }
}