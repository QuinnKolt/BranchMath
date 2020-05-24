using BranchMath.Value;

namespace BranchMath.Arithmetic {
    /// <summary>
    /// Denotes an element type which has a commutative and associative operation.
    /// </summary>
    /// <typeparam name="Self">The class which implements this interface. This allows specification of the input and output
    /// types.</typeparam>
    public interface Summable<Self> where Self : ValueType {
        public Self sum(Self a);
    }
}