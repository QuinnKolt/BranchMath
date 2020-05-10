using System;
using System.Numerics;

namespace BranchMath.Arithmetic.Number {
    public class ComplexNumber : Number {
        private Complex z;

        public ComplexNumber(Complex z) {
            this.z = z;
        }

        public double TOLERANCE { get; } = 1e-8;

        public virtual bool is_finite() {
            return true;
        }

        public virtual object evaluate() {
            return z;
        }

        public virtual string ClassLaTeX() {
            return "\\mathbb{C}";
        }

        public virtual string ToLaTeX() {
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