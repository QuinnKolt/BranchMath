using System;
using System.Globalization;

namespace BranchMath.Arithmetic.Number {
    public class RealNumber : ComplexNumber, Summable<RealNumber>, Powerable<RealNumber, Integer> {
        private readonly double x;

        public RealNumber(double x) : base(x) {
            this.x = x;
        }
        
        public override bool is_finite() {
            return true;
        }

        public override object evaluate() {
            return x;
        }

        public override string ToLaTeX() {
            return x.ToString(CultureInfo.CurrentCulture);
        }

        public override string ClassLaTeX() {
            return "\\mathbb{R}";
        }

        public RealNumber sum(RealNumber a) {
            return this + a;
        }

        public static implicit operator double(RealNumber r) {
            return r.x;
        }
        
        public static implicit operator RealNumber(double x) {
            return new RealNumber(x);
        }

        public RealNumber pow(Integer p) {
            return Math.Pow(x, p);
        }

        public override bool Equals(object? obj) {
            if (obj is RealNumber r) {
                return Math.Abs(r.x - x) < TOLERANCE;
            }
            
            return false;
        }

        public override int GetHashCode() {
            return x.GetHashCode();
        }
    }
}