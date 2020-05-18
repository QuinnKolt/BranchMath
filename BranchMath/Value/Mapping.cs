namespace BranchMath.Value {
    /// <summary>
    ///     Represents a mathematical function in terms of its actual value
    /// </summary>
    /// <typeparam name="C">The ambient codomain of the function</typeparam>
    /// <typeparam name="D">The domain of the function</typeparam>
    public abstract class Mapping<D, C> : ValueType where C : ValueType where D : ValueType {
        public readonly int arity;

        public Mapping(int arity) {
            this.arity = arity;
        }

        public Mapping() {
            arity = 1;
        }

        public abstract string ToLaTeX();
        public abstract string ClassLaTeX();

        public abstract C evaluate(D[] input);

        public abstract string ToLaTeX(D[] inputs);
    }
}