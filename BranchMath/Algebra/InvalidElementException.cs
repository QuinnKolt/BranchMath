using System;

namespace BranchMath.Algebra {
    /// <summary>
    ///     An exception which is thrown if an element is trying to be used while not within the group it is used in.
    /// </summary>
    public class InvalidElementException : Exception {
        public InvalidElementException() { }
        public InvalidElementException(string message) : base(message) { }
    }
}