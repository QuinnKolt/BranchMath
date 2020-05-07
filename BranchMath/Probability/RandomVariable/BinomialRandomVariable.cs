using BranchMath.Arithmetic.Number;

namespace BranchMath.Probability.RandomVariable {
    public class BinomialRandomVariable : RandomVariable<Integer> {
        private int n;
        private double p;
        public BinomialRandomVariable(int n, double p) {
            this.n = n;
            this.p = p;
        }

        public override Integer realize() {
            var total = new Integer(0);
            for (var i = 0; i < n; ++i) {
                if (rng.NextDouble() <= p)
                    total += new Integer(1);
            }

            return total;
        }
    }
}