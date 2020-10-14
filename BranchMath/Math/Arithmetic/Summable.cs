using BranchMath.Math.Value;

namespace BranchMath.Math.Arithmetic {
    /// <summary>
    /// Denotes an element type which has a commutative and associative operation.
    /// </summary>
    /// <typeparam name="Self">The class which implements this interface. This allows specification of the input and output
    /// types.</typeparam>
    public interface Summable<Self> : ValueType where Self : Summable<Self>, ValueType {
        public Self plus(Self a);
    }
}