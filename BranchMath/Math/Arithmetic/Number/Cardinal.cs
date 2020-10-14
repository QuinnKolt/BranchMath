using System;
using System.Numerics;
using Boolean = BranchMath.Math.Logic.Boolean;

namespace BranchMath.Math.Arithmetic.Number {
    public class Cardinal : Number {
        private readonly uint card_val;
        private readonly BigInteger? int_val;

        public Cardinal(BigInteger? int_val, uint card_val) {
            this.int_val = int_val;
            this.card_val = card_val;
        }

        public virtual object evaluate() {
            return is_finite() ? int_val : null;
        }

        public virtual string ClassLaTeX() {
            return "X";
        }

        public virtual Boolean is_finite() {
            return card_val == 0;
        }

        public virtual string ToLaTeX() {
            if (is_finite())
                return int_val.ToString();
            return "\\aleph " + card_val;
        }

        public static Cardinal operator *(Cardinal a, Cardinal b) {
            if (a.is_finite() && b.is_finite()) return new Cardinal(a.int_val * b.int_val, 0);
            return new Cardinal(0, System.Math.Max(a.card_val, b.card_val));
        }

        public static Cardinal operator +(Cardinal a, Cardinal b) {
            if (a.is_finite() && b.is_finite()) return new Cardinal(a.int_val + b.int_val, 0);
            return new Cardinal(0, System.Math.Max(a.card_val, b.card_val));
        }

        public static Cardinal operator -(Cardinal a, Cardinal b) {
            if (a.is_finite() && b.is_finite()) return new Cardinal(a.int_val - b.int_val, 0);
            return new Cardinal(0, System.Math.Max(a.card_val, b.card_val));
        }

        public static Cardinal operator %(Cardinal a, Cardinal b) {
            if (a.is_finite() && b.is_finite()) return new Cardinal(a.int_val % b.int_val, 0);

            if (a.is_finite()) return a;
            throw new ArithmeticException("Cannot perform modulo to infinite numbers");
        }

        public static Cardinal operator /(Cardinal a, Cardinal b) {
            if (a.is_finite() && b.is_finite()) return new Cardinal(a.int_val / b.int_val, 0);

            if (a.is_finite()) return new Cardinal(0, 0);

            if (b.is_finite()) return a;
            throw new ArithmeticException("Indeterminant form");
        }

        public virtual Cardinal powerset() {
            if (is_finite()) {
                var pow = BigInteger.One;
                for (var b = BigInteger.Zero; b < int_val.Value; b++) pow *= 2;

                return new Cardinal(pow, 0);
            }

            return new Cardinal(0, card_val + 1);
        }
    }
}