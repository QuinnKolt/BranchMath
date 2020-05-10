namespace BranchMath.Arithmetic.Number {
    public class RealNumber : Number {
        private readonly double? x;

        public RealNumber(double x) {
            this.x = x;
        }

        protected RealNumber() {
            x = null;
        }

        public virtual bool is_finite() {
            return true;
        }

        public virtual object evaluate() {
            return x;
        }

        public virtual string ToLaTeX() {
            return x.ToString();
        }

        public virtual string ClassLaTeX() {
            return "\\mathbb{R}";
        }
    }
}