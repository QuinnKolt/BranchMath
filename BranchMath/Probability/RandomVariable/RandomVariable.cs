

using System;
using BranchMath.Arithmetic.Number;
using BranchMath.Value;
using ValueType = BranchMath.Value.ValueType;

namespace BranchMath.Probability.RandomVariable {
    public abstract class RandomVariable<E> : AtomicValueType where E : ValueType {
        /// <summary>
        /// Gets a realization of the random variable
        /// </summary>
        /// <returns>The value of the random variable</returns>
        public abstract E realize();

        /// <summary>
        /// Random number generator for use by random variables
        /// </summary>
        protected static Random rng = new Random();
        
        public override string ClassLaTeX() {
            throw new NotImplementedException();
        }

        public override string ToLaTeX() {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return the probability that this random variable takes on the given value
        /// </summary>
        /// <param name="value">Value to test</param>
        /// <returns>Probability of attaining value</returns>
        public double getProbability(E value) {
            return 0;
        }
    }

    public class CombinedRandomVariable<E> : RandomVariable<E> where E : ValueType {
        private Func<E> real;
        
        /// <summary>
        /// Create a combined random variable with given function and random variable
        /// </summary>
        /// <param name="func">Function to apply random variable to</param>
        /// <param name="rand">Random variable</param>
        internal CombinedRandomVariable(Func<E, E> func, RandomVariable<E> rand) {
            real = () => func.Invoke(rand.realize());
        }
        
        /// <summary>
        /// Create a combined random variable with given realization function
        /// </summary>
        /// <param name="real">A realization function</param>
        internal CombinedRandomVariable(Func<E> real) {
            this.real = real;
        }

        public override E realize() {
            return real.Invoke();
        }
    }
}