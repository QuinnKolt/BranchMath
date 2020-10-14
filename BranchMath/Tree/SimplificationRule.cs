using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValueType = BranchMath.Math.Value.ValueType;

namespace BranchMath.Tree {
    /// <summary>
    ///     Represents a rule to determine if a given node is simplifiable
    /// </summary>
    public class SimplificationRule<C> where C : ValueType {
        private readonly OperationNode<C> before;
        private readonly Node<C> after;
        private readonly Dictionary<Variable<ValueType>, Func<ValueType, bool>> check_validity = new Dictionary<Variable<ValueType>, Func<ValueType, bool>>();

        protected SimplificationRule() {}
        
        public SimplificationRule(OperationNode<C> before, Node<C> after) {
            this.before = before;
            this.after = after;
        }

        // /// <summary>
        // ///     Gives an explanation of why or why not this simplification rule is/isn't applicable
        // /// </summary>
        // /// <param name="orig">The node being checked</param>
        // /// <returns>A string containing the explanation</returns>
        // public abstract string Explanation(OperationNode<C> orig);

        private static bool CanApply(Node<ValueType> orig, Node<ValueType> bef, IDictionary<Variable<ValueType>, Node<ValueType>> assignments) {

            if (!bef.Matches(orig)) {
                return false;
            }

            if (bef is Variable<ValueType> var) {
                if (assignments.ContainsKey(var)) {
                    return assignments[var].DeepEquals(orig);
                }
                assignments.Add(var, orig);
                return true;
            }

            if (!(orig is OperationNode<ValueType> oper))
                return true;
            
            var origchild = oper.GetChildren();
            var befchild = ((OperationNode<ValueType>) bef).GetChildren();
            return !origchild.Where((t, i) => !CanApply(t, befchild[i], assignments)).Any();
        }

        /// <summary>
        ///     Determines whether or not the simplification rule can be applied to the given node
        /// </summary>
        /// <param name="orig">The node being checked</param>
        /// <returns>Whether or not the rule is applicable</returns>
        public virtual bool IsApplicable(OperationNode<C> orig) {
            return CanApply((Node<ValueType>) orig, (Node<ValueType>) before, 
                new Dictionary<Variable<ValueType>, Node<ValueType>>());
        }

        private static Node<ValueType> Assign(Node<ValueType> aft, IDictionary<Variable<ValueType>, Node<ValueType>> assignments) {
            if (!(aft is OperationNode<ValueType> aftop)) {
                if (aft is Variable<ValueType> var && assignments.ContainsKey(var)) {
                    return assignments[var];
                }

                return aft.DeepCopy();
            }

            var child = aftop.GetChildren();
            for (var i = 0; i < child.Length; ++i) {
                child[i] = Assign(child[i], assignments);
            }
            return aftop.CopyWithNewChildren(child);
        }

        /// <summary>
        ///     Applies the simplification rule to the given node, assuming the rule is applicable
        /// </summary>
        /// <param name="orig">The original node</param>
        /// <returns>The simplified node</returns>
        public virtual Node<C> TryApply(OperationNode<C> orig) {
            var assignments = new Dictionary<Variable<ValueType>, Node<ValueType>>();
            if (!CanApply((Node<ValueType>) orig, (Node<ValueType>) before, assignments)) 
                return orig;
            
            return (Node<C>) Assign((Node<ValueType>) after, assignments);
        }

    }
}