namespace BranchMath.Math.Value {
    /// <summary>
    ///     Represents a mathematical function in terms of its actual value
    /// </summary>
    /// <typeparam name="C">The ambient codomain of the function</typeparam>
    /// <typeparam name="D">The domain of the function</typeparam>
    public interface Mapping<in D, out C> : Operator<C> where C : ValueType where D : ValueType {
        public int Arity();

        public C evaluate(D[] input);

        public string ToLaTeX(D[] inputs);
    }
}