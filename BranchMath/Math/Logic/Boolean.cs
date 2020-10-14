using BranchMath.Math.Value;

namespace BranchMath.Math.Logic {
    public class Boolean : ValueType {
        private readonly bool validity;
        public static readonly Boolean True = new Boolean(true);
        public static readonly Boolean False = new Boolean(false);
        
        private Boolean(bool validity) {
            this.validity = validity;
        }
        
        public string ToLaTeX() {
            return validity ? @"\top": @"\bot";
        }

        public string ClassLaTeX() {
            return @"\{\top, \bot\}";
        }

        public static implicit operator bool(Boolean b) {
            return b.validity;
        }

        public static implicit operator Boolean(bool b) {
            return b ? True : False;
        }
    }
}