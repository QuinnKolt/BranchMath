namespace BranchMath.Math.Value {
    public abstract class MonoFunction<D, C> : Mapping<D, C> where C : ValueType where D : ValueType {
        public abstract C evaluate(D input);

        public int Arity() {
            return 1;
        }

        public C evaluate(D[] input) {
            return evaluate(input[0]);
        }

        public abstract string ToLaTeX(D input);

        public string ToLaTeX(D[] inputs) {
            return ToLaTeX(inputs[0]);
        }

        public abstract string ToLaTeX();

        public abstract string ClassLaTeX();
    }
}