using BranchMath.Arithmetic.Number;

namespace BranchMath.Probability.RandomVariable {
    /// <summary>
    ///     Represents a negative binomial random variable. A negative binomial random variable is a
    ///     random variable which represents Bernoulli trials, where instead of conducting a specified
    ///     number of trials and counting the number of successes, this specifies the number of successes
    ///     and counts the number of trials.
    /// </summary>
    public class NegativeBinomialRandomVariable : DiscreteRandomVariable {
        /// <summary>
        ///     Number of successes needed to stop
        /// </summary>
        private readonly int k;

        /// <summary>
        ///     Probability of a success
        /// </summary>
        private readonly double p;

        /// <summary>
        ///     Create a new negative binomial random variable
        /// </summary>
        /// <param name="k">Number of successes needed to stop</param>
        /// <param name="p">Probability of success</param>
        public NegativeBinomialRandomVariable(int k, double p) {
            this.k = k;
            this.p = p;
        }

        public override Integer realize() {
            Integer n = 0;
            for (var i = 0; i < k; ++n)
                if (rng.NextDouble() <= p)
                    ++i;

            return n;
        }
    }
}