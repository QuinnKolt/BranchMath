using System;
using System.Collections.Generic;
using System.Numerics;
using BranchMath.Algebra;
using BranchMath.Algebra.Groups;

namespace BranchMath {
    internal class Program {
        private static void Main(string[] args) {
            var D12 = new DihedralGroup(12);
            var D16 = new DihedralGroup(16);
            
            var r3 = new AlgebraicElement<BigInteger[]>(new BigInteger[]{0, 3});
            var sr = new AlgebraicElement<BigInteger[]>(new BigInteger[]{1, 1});
            var e = new AlgebraicElement<BigInteger[]>(new BigInteger[]{0, 0});

            var sr4 = D12.MultiplyElements(sr, r3);
            var ee = D12.MultiplyElements(sr, sr);
            Console.WriteLine(D16.GetCayleyTable());
        }
    }
}