using System;

namespace BranchMath.Tree {
    /// <summary>
    ///     Thrown if the operands of an operation do not match the operation
    /// </summary>
    public class InvalidOperationException : Exception {
        public InvalidOperationException(string message) : base(message) { }
    }
}