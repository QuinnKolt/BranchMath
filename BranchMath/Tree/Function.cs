using System;

namespace BranchMath.Tree {
    /// <summary>
    /// Represents a mathematical function in terms of its actual value
    /// </summary>
    /// <typeparam name="C">The ambient codomain of the function</typeparam>
    public interface Function<out C> : ValueType where C : ValueType {
    }
}