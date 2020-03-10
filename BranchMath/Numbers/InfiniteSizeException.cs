using System;

namespace BranchMath.Numbers {
    public class InfiniteSizeException : Exception {
        
        public InfiniteSizeException(string message) : base(message) { }
    }
}