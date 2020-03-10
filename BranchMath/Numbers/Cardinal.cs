using System;
using System.Numerics;

namespace BranchMath.Numbers {
    public class Cardinal : Number {
        private readonly BigInteger? int_val;
        private uint card_val;

        public Cardinal(BigInteger? int_val, uint card_val) {
            this.int_val = int_val;
            this.card_val = card_val;
        }
        
        public BigInteger? evaluate() {
            if (is_finite()) {
                return int_val;
            }

            return null;
        }

        public bool is_finite() {
            return card_val == 0;
        }
        
        public static Cardinal operator *(Cardinal a, Cardinal b) {
            if (a.is_finite() && b.is_finite()) {
                return new Cardinal(a.int_val * b.int_val,0);
            }
            return new Cardinal(0, Math.Max(a.card_val, b.card_val));
        }
        
        public static Cardinal operator +(Cardinal a, Cardinal b) {
            if (a.is_finite() && b.is_finite()) {
                return new Cardinal(a.int_val + b.int_val,0);
            }
            return new Cardinal(0, Math.Max(a.card_val, b.card_val));
        }
        
        public static Cardinal operator -(Cardinal a, Cardinal b) {
            if (a.is_finite() && b.is_finite()) {
                return new Cardinal(a.int_val - b.int_val,0);
            }
            return new Cardinal(0, Math.Max(a.card_val, b.card_val));
        }
        
        public static Cardinal operator %(Cardinal a, Cardinal b) {
            if (a.is_finite() && b.is_finite()) {
                return new Cardinal(a.int_val % b.int_val,0);
            }

            if (a.is_finite()) {
                return a;
            }
            throw new ArithmeticException("Cannot perform modulo to infinite numbers");
        }
        
        public static Cardinal operator /(Cardinal a, Cardinal b) {
            if (a.is_finite() && b.is_finite()) {
                return new Cardinal(a.int_val / b.int_val,0);
            }
            
            if (a.is_finite()) {
                return new Cardinal(0, 0);
            }
            
            if (b.is_finite()) {
                return a;
            }
            throw new ArithmeticException("Indeterminant form");
        }

        public override string ToString() {
            if (is_finite())
                return int_val.ToString();
            return "Aleph " + card_val;
        }
    }
}