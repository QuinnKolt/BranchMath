namespace BranchMath.Math.Value {
    public interface BiFunction<in D1, in D2, out C> : Operator<C>
        where C : ValueType where D1 : ValueType where D2 : ValueType {
        public C evaluate(D1 input1, D2 input2);

        public string ToLaTeX(D1 input1, D2 input2);
    }
}