using System;

namespace BranchMath.Arithmetic.Numbers {
    public class InfiniteSizeException : Exception {
        public InfiniteSizeException(string message) : base(message) { }
    }
}