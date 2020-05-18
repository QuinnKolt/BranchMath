using System;
using System.Numerics;
using BranchMath.Algebra.Ring;

namespace BranchMath {
    internal static class Program {
        private static void Main(string[] args) {
            var theintegers = new Integers();
            var polys = new PolynomialRing<BigInteger, Integers.IntElement>(theintegers);
            
            var xp1 = new PolynomialRing<BigInteger, Integers.IntElement>.Polynomial(
                new []{ (Integers.IntElement)theintegers.getOne(), 
                    (Integers.IntElement) theintegers.getOne()}, polys);
            var x = new PolynomialRing<BigInteger, Integers.IntElement>.Polynomial(
                new []{ (Integers.IntElement)theintegers.getZero(), 
                    (Integers.IntElement) theintegers.getOne()}, polys);

            Console.WriteLine((xp1 + x).ToLaTeX());
            Console.WriteLine((xp1 * x).ToLaTeX());
            Console.WriteLine(((PolynomialRing<BigInteger, Integers.IntElement>.Polynomial) (xp1 ^ 6) 
                               + new Integers.IntElement(3, theintegers)).ToLaTeX());
        }
    }
}