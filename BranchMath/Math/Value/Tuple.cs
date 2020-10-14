using BranchMath.Math.Arithmetic.Number;
using BranchMath.Math.Logic;

namespace BranchMath.Math.Value {
    public class Tuple<I> : ValueType where I : ValueType {
        private readonly I[] entries;

        public Tuple(I[] entries) {
            this.entries = entries;
        }

        public Integer Length() {
            return entries.Length;
        }

        public I this[int i] => entries[i];

        public object evaluate() {
            var vals = new object[entries.Length];
            for (var i = 0; i < entries.Length; ++i) vals[i] = entries[i].evaluate();

            return vals;
        }

        public string ToLaTeX() {
            var latex = "(";
            for (var i = 0; i < entries.Length; ++i) {
                latex += entries[i].ToLaTeX();
                if (i != entries.Length - 1)
                    latex += ", ";
            }

            latex += ")";

            return latex;
        }

        public string ClassLaTeX() {
            var latex = "";
            for (var i = 0; i < entries.Length; ++i) {
                latex += entries[i].ClassLaTeX();
                if (i != entries.Length - 1)
                    latex += "\\times ";
            }

            return latex;
        }

        public Boolean Equals(Tuple<I> tup) {
            for(var i = 0; i < entries.Length; ++i)
                if (!this[i].Equals(tup[i]))
                    return false;
            return true;
        }
    }
}