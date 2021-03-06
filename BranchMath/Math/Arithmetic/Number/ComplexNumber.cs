﻿using System.Numerics;
using Boolean = BranchMath.Math.Logic.Boolean;

namespace BranchMath.Math.Arithmetic.Number {
    public class ComplexNumber : Number {
        private readonly Complex z;

        public ComplexNumber(Complex z) {
            this.z = z;
        }

        public static double TOLERANCE { get; } = 1e-8;

        public virtual Boolean is_finite() {
            return true;
        }

        public virtual object evaluate() {
            return z;
        }

        public virtual string ClassLaTeX() {
            return "\\mathbb{C}";
        }
        
        
        public override bool Equals(object obj) {
            if (obj is ComplexNumber r) {
                return System.Math.Abs(r.z.Real - z.Real) < TOLERANCE && System.Math.Abs(r.z.Imaginary - z.Imaginary) < TOLERANCE;
            }
            
            return false;
        }

        protected bool Equals(ComplexNumber other) {
            return z.Equals(other.z);
        }

        public override int GetHashCode() {
            return z.GetHashCode();
        }

        public virtual string ToLaTeX() {
            if (System.Math.Abs(z.Real) > TOLERANCE && System.Math.Abs(z.Imaginary) > TOLERANCE)
                return z.Real + z.Imaginary + "i";
            
            if (System.Math.Abs(z.Real) > TOLERANCE)
                return z.Real + "";
            
            if (System.Math.Abs(z.Imaginary) > TOLERANCE)
                return z.Imaginary + "i";
            return "0";
        }
    }
}