using System.Globalization;
using Boolean = BranchMath.Math.Logic.Boolean;

namespace BranchMath.Math.Arithmetic.Number {
    public class RealNumber : Number, FieldLikeObject<RealNumber> {
        private readonly double x;
        public static double TOLERANCE { get; } = 1e-14;

        public RealNumber(double x) {
            this.x = x;
        }
        
        public Boolean is_finite() {
            return true;
        }

        public object evaluate() {
            return x;
        }

        public string ToLaTeX() {
            return x.ToString(CultureInfo.CurrentCulture);
        }

        public string ClassLaTeX() {
            return "\\mathbb{R}";
        }

        public virtual RealNumber plus(RealNumber a) {
            return this + a;
        }

        public static implicit operator double(RealNumber r) {
            return r.x;
        }
        
        public static implicit operator RealNumber(double x) {
            return new RealNumber(x);
        }

        public RealNumber times(RealNumber a) {
            return this * a;
        }

        public RealNumber pow(Natural p) {
            return System.Math.Pow(this, p);
        }

        public override bool Equals(object obj) {
            if (obj is RealNumber r) {
                return System.Math.Abs(r.x - x) < TOLERANCE;
            }
            
            return false;
        }

        public override int GetHashCode() {
            return x.GetHashCode();
        }

        public RealNumber getZero() {
            return 0;
        }

        public RealNumber minus(RealNumber r) {
            return this - r;
        }

        public RealNumber getOne() {
            return 1;
        }

        public RealNumber dividedBy(RealNumber d) {
            return 1 / d;
        }
    }
}