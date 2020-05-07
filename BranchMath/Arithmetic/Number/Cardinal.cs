using System;
using System.Numerics;

namespace BranchMath.Arithmetic.Number {
    public class Cardinal : Number {
        private readonly BigInteger? int_val;
        private readonly uint card_val;

        public Cardinal(BigInteger? int_val, uint card_val) {
            this.int_val = int_val;
            this.card_val = card_val;
        }

        public override object evaluate() {
            return is_finite() ? int_val : null;
        }

        public override string ClassLaTeX() {
            return "X";
        }

        public override bool is_finite() {
            return card_val == 0;
        }

        public static Cardinal operator *(Cardinal a, Cardinal b) {
            if (a.is_finite() && b.is_finite()) return new Cardinal(a.int_val * b.int_val, 0);
            return new Cardinal(0, Math.Max(a.card_val, b.card_val));
        }

        public static Cardinal operator +(Cardinal a, Cardinal b) {
            if (a.is_finite() && b.is_finite()) return new Cardinal(a.int_val + b.int_val, 0);
            return new Cardinal(0, Math.Max(a.card_val, b.card_val));
        }

        public static Cardinal operator -(Cardinal a, Cardinal b) {
            if (a.is_finite() && b.is_finite()) return new Cardinal(a.int_val - b.int_val, 0);
            return new Cardinal(0, Math.Max(a.card_val, b.card_val));
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

        public override string ToLaTeX() {
            if (is_finite())
                return int_val.ToString();
            return "\\aleph " + card_val;
        }

        public Cardinal powerset() {
            if (is_finite()) {
                var pow = BigInteger.One;
                for (var b = BigInteger.Zero; b < int_val.Value; b++) pow *= 2;

                return new Cardinal(pow, 0);
            }

            return new Cardinal(0, card_val + 1);
        }
    }
}