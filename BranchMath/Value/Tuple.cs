namespace BranchMath.Value {
    public class Tuple : ValueType {
        private readonly ValueType[] entries;

        public Tuple(ValueType[] entries) {
            this.entries = entries;
        }

        public ValueType this[int i] => entries[i];

        public override object evaluate() {
            var vals = new object[entries.Length];
            for (var i = 0; i < entries.Length; ++i) vals[i] = entries[i].evaluate();

            return vals;
        }

        public override string ToLaTeX() {
            var latex = "(";
            for (var i = 0; i < entries.Length; ++i) {
                latex += entries[i].ToLaTeX();
                if (i != entries.Length - 1)
                    latex += ", ";
            }

            latex += ")";

            return latex;
        }

        public override string ClassLaTeX() {
            var latex = "";
            for (var i = 0; i < entries.Length; ++i) {
                latex += entries[i].ClassLaTeX();
                if (i != entries.Length - 1)
                    latex += "\\times ";
            }

            return latex;
        }
    }
}