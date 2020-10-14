using BranchMath.Math.Arithmetic.Number;

namespace BranchMath.Math.Analysis {
    public class L2InnerProduct : InnerProduct<RealFunction, RealNumber> {
        public static L2InnerProduct prod = new L2InnerProduct();
        private L2InnerProduct(){}
        
        public override string ToLaTeX() {
            throw new System.NotImplementedException();
        }

        public override string ClassLaTeX() {
            throw new System.NotImplementedException();
        }

        public override RealNumber evaluate(RealFunction input1, RealFunction input2) {
            throw new System.NotImplementedException();
        }
    }
}