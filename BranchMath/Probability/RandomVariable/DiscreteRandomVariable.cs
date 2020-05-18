using System;
using BranchMath.Arithmetic.Number;
using BranchMath.Value;

namespace BranchMath.Probability.RandomVariable {
    public abstract class DiscreteRandomVariable : RandomVariable<Integer> {
        public static DiscreteRandomVariable operator +(DiscreteRandomVariable var1, DiscreteRandomVariable var2) {
            return new DiscreteComposedRandomVariable(() => var1.realize() + var2.realize());
        }

        public static DiscreteRandomVariable operator +(DiscreteRandomVariable var1, Integer n) {
            return new DiscreteComposedRandomVariable(() => var1.realize() + n);
        }

        public static DiscreteRandomVariable operator +(Integer n, DiscreteRandomVariable var1) {
            return new DiscreteComposedRandomVariable(() => n + var1.realize());
        }

        public static DiscreteRandomVariable operator -(DiscreteRandomVariable var1, DiscreteRandomVariable var2) {
            return new DiscreteComposedRandomVariable(() => var1.realize() - var2.realize());
        }

        public static DiscreteRandomVariable operator -(Integer n, DiscreteRandomVariable var1) {
            return new DiscreteComposedRandomVariable(() => var1.realize() - n);
        }

        public static DiscreteRandomVariable operator -(DiscreteRandomVariable var1, Integer n) {
            return new DiscreteComposedRandomVariable(() => n - var1.realize());
        }

        public static DiscreteRandomVariable operator *(DiscreteRandomVariable var1, DiscreteRandomVariable var2) {
            return new DiscreteComposedRandomVariable(() => var1.realize() * var2.realize());
        }

        public static DiscreteRandomVariable operator *(Integer n, DiscreteRandomVariable var1) {
            return new DiscreteComposedRandomVariable(() => var1.realize() * n);
        }

        public static DiscreteRandomVariable operator *(DiscreteRandomVariable var1, Integer n) {
            return new DiscreteComposedRandomVariable(() => var1.realize() * n);
        }
    }

    internal class DiscreteComposedRandomVariable : DiscreteRandomVariable {
        private readonly Func<Integer> real;

        /// <summary>
        ///     Create a combined random variable with given function and random variable
        /// </summary>
        /// <param name="real">Function to apply random variable to</param>
        internal DiscreteComposedRandomVariable(Func<Integer> real) {
            this.real = real;
        }

        public override Integer realize() {
            return real.Invoke();
        }
    }
}