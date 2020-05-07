using System;
using System.Collections.Generic;
using BranchMath.Arithmetic.Number;
using BranchMath.Arithmetic.Numbers;
using BranchMath.Value;

namespace BranchMath {
    internal class Program {
        private static void Main(string[] args) {
            // var D12 = new DihedralGroup(12);
            // var D16 = new DihedralGroup(16);
            //
            // var r3 = new GroupElement<BigInteger[]>(new BigInteger[]{0, 3}, D12);
            // var sr = new GroupElement<BigInteger[]>(new BigInteger[]{1, 1}, D12);
            // var e = new GroupElement<BigInteger[]>(new BigInteger[]{0, 0}, D12);
            //
            // var sr4 = sr * r3;
            // var ee = sr * sr;
            // Console.WriteLine(new Natural(8).gcd(new Natural(6)));

            var Set0 = new ExplicitSet<Integer>(new HashSet<Integer>(new[] {new Integer(1), new Integer(2)}));
            var Set1 = new ExplicitSet<Integer>(new HashSet<Integer>(new[]
                {new Integer(3), new Integer(2), new Integer(8)}));
            var Set2 = new Powerset<Integer>(Set1).evaluate();
            Console.WriteLine(((Set<Set<Integer>>) Set2).ToLaTeX());
        }
    }
}