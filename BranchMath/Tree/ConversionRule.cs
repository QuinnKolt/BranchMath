using BranchMath.Math.Value;

namespace BranchMath.Tree {
    public interface ConversionRule<out R> where R : ValueType {
        protected string[] parts();
        protected Node<R> convertTo();
        protected string[] types();
        protected Variable<ValueType>[] inputs();
    }
}