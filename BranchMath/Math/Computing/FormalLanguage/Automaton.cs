using BranchMath.Math.Value;

namespace BranchMath.Math.Computing.FormalLanguage {
    public interface Automaton<in Q, in C> : Language<C> where Q : ValueType where C : ValueType { }
}