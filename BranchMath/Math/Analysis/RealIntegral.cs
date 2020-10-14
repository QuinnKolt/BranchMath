using BranchMath.Math.Arithmetic.Number;
using BranchMath.Math.Value;

namespace BranchMath.Math.Analysis {
    public class RealIntegral : MonoFunction<Mapping<RealNumber, RealNumber>, Mapping<RealNumber, RealNumber>>, BiFunction<Mapping<RealNumber, RealNumber>, Value.Tuple<Interval>, RealNumber> {

        private RealIntegral() {
            
        }
        
        
        public static double Precision { get; set; } = .000001;
        
        public override Mapping<RealNumber, RealNumber> evaluate(Mapping<RealNumber, RealNumber> input) {
            throw new System.NotImplementedException();
        }

        public override string ToLaTeX(Mapping<RealNumber, RealNumber> input) {
            throw new System.NotImplementedException();
        }

        public override string ToLaTeX() {
            throw new System.NotImplementedException();
        }

        public override string ClassLaTeX() {
            throw new System.NotImplementedException();
        }

        public RealNumber evaluate(Mapping<RealNumber, RealNumber> input1, RealNumber input2) {
            throw new System.NotImplementedException();
        }

        public string ToLaTeX(Mapping<RealNumber, RealNumber> input1, RealNumber input2) {
            throw new System.NotImplementedException();
        }

        public RealNumber evaluate(Mapping<RealNumber, RealNumber> input1, Value.Tuple<Interval> input2) {
            if (input1.Arity() != -1 && input1.Arity() != input2.Length()) {
                
            }
            throw new System.NotImplementedException();
        }

        public string ToLaTeX(Mapping<RealNumber, RealNumber> input1, Value.Tuple<Interval> input2) {
            throw new System.NotImplementedException();
        }
    }
}