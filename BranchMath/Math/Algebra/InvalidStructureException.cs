using System;

namespace BranchMath.Math.Algebra {
    /// <summary>
    ///     An exception which is thrown if an invalid algebraic structure has been created.
    /// </summary>
    public class InvalidGroupException : Exception {
        public InvalidGroupException(string message) : base(message) { }
    }
}