using BranchMath.Tree;

namespace BranchMath.Algebra.Groups {
    public interface Homomorphism<I, J> : Function<AlgebraicElement<I>> {
        public Group<I> GetKernel();

        public AlgebraicElement<I> evaluate(AlgebraicElement<J> el);
    }
}