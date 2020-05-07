namespace BranchMath.Arithmetic.Number {
    public class RealNumber : Number {
        private readonly double? x;

        public RealNumber(double x) {
            this.x = x;
        }

        protected RealNumber() {
            x = null;
        }

        public override bool is_finite() {
            return true;
        }

        public override object evaluate() {
            return x;
        }

        public override string ToLaTeX() {
            return x.ToString();
        }

        public override string ClassLaTeX() {
            return "\\mathbb{R}";
        }
    }
}