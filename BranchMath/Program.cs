using System;
using BranchMath.Display;
using BranchMath.Math.Arithmetic.Number;
using BranchMath.Math.Linear;
using BranchMath.Math.Probability.RandomVariable;

namespace BranchMath {
    internal static class Program {
        
        private static void Main(string[] args) {
            
            // var sin = Sine.SIN;
            // var cos = Cosine.COS;
            // var pow = new Power<RealNumber, Integer>();
            // var plus = new Sum<RealNumber>();
            // var x = new VariableNode<RealNumber>("x");
            //
            // var sinnode = new MappingNode<RealNumber, RealNumber>(sin, new Node<RealNumber>[]{x});
            // var cosnode = new MappingNode<RealNumber, RealNumber>(cos, new Node<RealNumber>[]{x});
            // var sin2 = new BiFunctionNode<RealNumber, Integer, RealNumber>(pow, sinnode, new ConstantNode<Integer>(2));
            // var cos2 = new BiFunctionNode<RealNumber, Integer, RealNumber>(pow, cosnode, new ConstantNode<Integer>(2));
            //
            // var sum = new MappingNode<RealNumber, RealNumber>(plus,new Node<RealNumber>[]{sin2, cos2});
            //
            // var pyth = new SimplificationRule<RealNumber>(sum, new ConstantNode<RealNumber>(1));
            // var four = new ConstantNode<RealNumber>(4);
            //
            // sinnode = new MappingNode<RealNumber, RealNumber>(sin, new Node<RealNumber>[]{new ConstantNode<RealNumber>(1)});
            // cosnode = new MappingNode<RealNumber, RealNumber>(cos, new Node<RealNumber>[]{new ConstantNode<RealNumber>(1)});
            //
            // sin2 = new BiFunctionNode<RealNumber, Integer, RealNumber>(pow, sinnode, new ConstantNode<Integer>(2));
            // cos2 = new BiFunctionNode<RealNumber, Integer, RealNumber>(pow, cosnode, new ConstantNode<Integer>(2));
            //
            // sum = new MappingNode<RealNumber, RealNumber>(plus, 
            //     new Node<RealNumber>[]{sin2, cos2});
            //
            // Console.WriteLine(pyth.IsApplicable(sum));
            // Console.WriteLine(pyth.TryApply(sum).GetValue().evaluate());

            // var r = LinearBuilder.range(0, Math.PI, 100);
            // Console.WriteLine(r.EntryWiseApply(Sine.SIN).ToLaTeX());

            var A = new Matrix<RealNumber>(new RealNumber[,] {{1, 2, 4}, {0, 2, 3}, {6, 0, 1}});
            // var M = LinearBuilder.random(new ContinuousUniformRandomVariable(0, 1), 30, 30);
            var M = ((Matrix<RealNumber>)LinearBuilder.range(1, 40, 1)) * ~LinearBuilder.range(1, 40,1); 

            M[10, 10] = A;

            Console.WriteLine(M.ToLaTeX());
        }
    }
}