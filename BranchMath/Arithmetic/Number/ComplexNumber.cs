using System;
using System.Numerics;

namespace BranchMath.Arithmetic.Number {
    public class ComplexNumber : Number {
        private Complex z;

        public ComplexNumber(Complex z) {
            this.z = z;
        }

        public double TOLERANCE { get; } = 1e-8;

        public override bool is_finite() {
            return true;
        }

        public override object evaluate() {
            return z;
        }

        public override string ClassLaTeX() {
            return "\\mathbb{C}";
        }

        public override string ToLaTeX() {
            if (Math.Abs(z.Real) > TOLERANCE && Math.Abs(z.Imaginary) > TOLERANCE)
                return z.Real + z.Imaginary + "i";
            if (Math.Abs(z.Real) > TOLERANCE)
                return z.Real.ToString();
            if (Math.Abs(z.Imaginary) > TOLERANCE)
                return z.Imaginary + "i";
            return "0";
        }
    }
}