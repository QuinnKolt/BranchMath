using BranchMath.Value;

namespace BranchMath.Tree {
    /// <summary>
    ///     Represents a rule to determine if a given node is simplifiable
    /// </summary>
    /// <typeparam name="V"></typeparam>
    public interface SimplificationRule<D, C> where D : ValueType where C : ValueType {
        /// <summary>
        ///     Gives an explanation of why or why not this simplification rule is/isn't applicable
        /// </summary>
        /// <param name="orig">The node being checked</param>
        /// <returns>A string containing the explanation</returns>
        public string Explanation(OperationNode<D, C> orig);

        /// <summary>
        ///     Determines whether or not the simplification rule can be applied to the given node
        /// </summary>
        /// <param name="orig">The node being checked</param>
        /// <returns>Whether or not the rule is applicable</returns>
        public bool IsApplicable(OperationNode<D, C> orig);

        /// <summary>
        ///     Applies the simplification rule to the given node, assuming the rule is applicable
        /// </summary>
        /// <param name="orig">The original node</param>
        /// <returns>The simplified node</returns>
        public Node<C> Apply(OperationNode<D, C> orig);
    }
}