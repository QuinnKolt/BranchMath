using System;
using System.Collections.Generic;
using BranchMath.Algebra.Groups;

namespace BranchMath {
    internal class Program {
        private static void Main(string[] args) {
            var D12 = new DihedralGroup(12);
            var D16 = new DihedralGroup(16);
            
            new CartesianProductGroup(new[] {D12, D16});
        }
    }
}