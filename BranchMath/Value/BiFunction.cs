namespace BranchMath.Value {
    public interface BiFunction<D1, D2, C> : ValueType
        where C : ValueType where D1 : ValueType where D2 : ValueType {
        public C evaluate(D1 input1, D2 input2);

        public string ToLaTeX(D1 input1, D2 input2);
    }
}