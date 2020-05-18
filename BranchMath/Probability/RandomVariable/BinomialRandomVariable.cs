using BranchMath.Arithmetic.Number;

namespace BranchMath.Probability.RandomVariable {
    /// <summary>
    ///     Represents a binomial random variable. A binomial random variable is a random variable which represents
    ///     Bernoulli trials, which conducts a fixed number of binary (success/failure) trials and counts the number of
    ///     successes.
    /// </summary>
    public class BinomialRandomVariable : DiscreteRandomVariable {
        /// <summary>
        ///     Number of trials conducted
        /// </summary>
        private readonly int n;

        /// <summary>
        ///     Probability of a success
        /// </summary>
        private readonly double p;

        /// <summary>
        ///     Create a new binomial random variable
        /// </summary>
        /// <param name="k">Number of trials</param>
        /// <param name="p">Probability of success</param>
        public BinomialRandomVariable(int n, double p) {
            this.n = n;
            this.p = p;
        }

        public override Integer realize() {
            Integer total = 0;
            for (var i = 0; i < n; ++i)
                if (rng.NextDouble() <= p)
                    ++total;

            return total;
        }
    }
}