namespace BranchMath.Value {
    /// <summary>
    ///     Represents a mathematical function in terms of its actual value
    /// </summary>
    /// <typeparam name="C">The ambient codomain of the function</typeparam>
    public abstract class Mapping<C> : AtomicValueType where C : ValueType { }
}