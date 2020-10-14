using System.Threading.Tasks;
using BranchMath.Math.Arithmetic;
using BranchMath.Math.Arithmetic.Number;
using BranchMath.Math.Probability.RandomVariable;

namespace BranchMath.Math.Linear {
    public static class LinearBuilder {
        public static Vector<RealNumber> range(RealNumber a, RealNumber b, Integer n) {
            var entries = new RealNumber[n];
            var step = (RealNumber) ((b - a) / (n - 1));
            for (var i = 0; i < n; ++i) {
                entries[i] = a + step * i;
            }

            return entries;
        }

        public static Matrix<R> random<R>(RandomVariable<R> rand, int n, int m) where R : FieldLikeObject<R> {
            var ent = new R[n, m];

            Parallel.For(0, n, i => { 
                Parallel.For(0, m, j => {
                    ent[i, j] = rand.realize();
                });
            });

            return ent;
        }
    }
} 