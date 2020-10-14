using System;
using BranchMath.Math.Value;
using ValueType = BranchMath.Math.Value.ValueType;

namespace BranchMath.Math.Probability.RandomVariable {
    public abstract class RandomVariable<E> : Value.ValueType where E : ValueType {

        public string ClassLaTeX() {
            throw new NotImplementedException();
        }

        public string ToLaTeX() {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Gets a realization of the random variable. (Note: this should be thread-safe)
        /// </summary>
        /// <returns>The value of the random variable</returns>
        public abstract E realize();

        public RandomVariable<C> apply_function<C>(MonoFunction<E, C> function) where C : ValueType {
            return new ComposedRandomVariable<E, C>(function, this);
        }

        /// <summary>
        ///     Return the probability that this random variable takes on the given value
        /// </summary>
        /// <param name="value">Value to test</param>
        /// <returns>Probability of attaining value</returns>
        public double getProbability(E value) {
            return 0;
        }
    }

    internal class ComposedRandomVariable<D, E> : RandomVariable<E> where E : ValueType where D : ValueType {
        private readonly MonoFunction<D, E> real;
        private readonly RandomVariable<D> var;

        /// <summary>
        ///     Create a combined random variable with given function and random variable
        /// </summary>
        /// <param name="real">Function to apply random variable to</param>
        /// <param name="var">Random variable</param>
        internal ComposedRandomVariable(MonoFunction<D, E> real, RandomVariable<D> var) {
            this.real = real;
            this.var = var;
        }

        public override E realize() {
            return real.evaluate(var.realize());
        }
    }
}