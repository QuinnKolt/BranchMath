using BranchMath.Math.Arithmetic;
using BranchMath.Math.Arithmetic.Number;
using BranchMath.Math.Value;

namespace BranchMath.Math.Analysis {
    public abstract class InnerProduct<I, Scalar> : BiFunction<I, I, RealNumber> where I : Scalable<I, Scalar>, Subtractable<I>, ValueType
        where Scalar : FieldLikeObject<Scalar>, ValueType {
        public abstract string ToLaTeX();
        public abstract string ClassLaTeX();
        public abstract RealNumber evaluate(I input1, I input2);

        public Metric<I> getMetric() {
            return new InnerProductMetric(this);
        }

        public virtual string ToLaTeX(I input1, I input2) {
            return $"\\langle {input1.ToLaTeX()}, {input2.ToLaTeX()}\\rangle";
        }
        
        public static implicit operator InnerProductMetric(InnerProduct<I, Scalar> ip) {
            return new InnerProductMetric(ip);
        }
        
        public static implicit operator InnerProduct<I, Scalar>(InnerProductMetric metric) {
            return metric.ip;
        }
        
        public class InnerProductMetric : Metric<I> {
            internal InnerProduct<I, Scalar> ip;

            internal InnerProductMetric(InnerProduct<I, Scalar> ip) {
                this.ip = ip;
            }
            
            public override RealNumber evaluate(I input) {
                return ip.evaluate(input, input);
            }

            public override string ToLaTeX() {
                return ip.ToLaTeX();
            }
            
            public override string ToLaTeX(I input) {
                return ip.ToLaTeX(input, input);
            }

            public override string ClassLaTeX() {
                return ip.ClassLaTeX();
            }
        }
    }

}