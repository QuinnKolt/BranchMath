using System.Collections.Generic;

namespace BranchMath.Tree {
    public interface FunctionNode : Node {
        public FunctionNode simplify();
        public FunctionNode deep_copy();
        public FunctionNode evaluate(Dictionary<Variable, Node> variables);

    }
}