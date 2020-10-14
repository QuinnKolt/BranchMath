using System.Threading.Tasks;
using BranchMath.Math.Arithmetic;
using BranchMath.Math.Value;

namespace BranchMath.Math.Linear {
    public class Vector<R> : MonoFunction<Vector<R>, R>, Scalable<Vector<R>, R> where R : Divideable<R>, Subtractable<R> {
        private readonly R[] entries;

        public Vector(R[] entries) {
            this.entries = entries;
        }

        private Vector(R[,] ent) {
            if (ent.GetLength(0) == 1) {
                entries = new R[ent.GetLength(1)];
                Parallel.For(0, ent.GetLength(1), i => {
                    this[i] = ent[0, i];
                });
            }
            else if (ent.GetLength(1) == 1) {
                entries = new R[ent.GetLength(0)];
                Parallel.For(0, ent.GetLength(0), i => {
                    this[i] = ent[i, 0];
                });
            }
            else
                throw new DimensionMismatchException();
        }
        
        public virtual object evaluate() {
            return entries;
        }

        public override R evaluate(Vector<R> input) {
            return dot(input);
        }

        public override string ToLaTeX(Vector<R> input) {
            return ToLaTeX() + "\\cdot" + input.ToLaTeX();
        }

        public override string ToLaTeX() {
            var s = @"\begin{bmatrix}";
            s += "\n";
            for (var i = 0; i < Length(); ++i) { 
                s += this[i].ToLaTeX() + "\\\\\n";
            }

            s = s.Substring(0, s.Length - 3) + "\n";
            s += @"\end{bmatrix}";
            return s;
        }

        public virtual int Length() {
            return entries.Length;
        }

        public override string ClassLaTeX() {
            return this[0].ClassLaTeX() +
                   $"^{{{Length()}}}";
        }

        public virtual Vector<R> plus(Vector<R> a) {
            if(Length() != a.Length())
                throw new DimensionMismatchException();
            
            var vals = new R[Length()];

            Parallel.For(0, Length(),
                i => vals[i] = this[i].plus(a[i]));

            return vals;
        }

        public virtual R dot(Vector<R> a) {
            if(Length() != a.Length())
                throw new DimensionMismatchException();

            var val = new object();
            for (var i = 0; i < Length(); ++i) {
                if (i == 0) {
                    val = this[i].times(a[i]);
                }
                else {
                    val = ((R) val).plus(
                        this[i].times(a[i]));
                }
            }

            return (R) val;
        }
        
        public virtual Vector<R> timesLeft(Matrix<R> a) {
            if(Length() != a.NumCols())
                throw new DimensionMismatchException();

            var vals = new R[a.NumRows()];
            Parallel.For(0, a.NumRows(), j => {
                for (var i = 0; i < Length(); ++i) {
                    if (i == 0) {
                        vals[j] = this[i].times(a[j, i]);
                    }
                    else {
                        vals[j] = vals[j].plus(
                            this[i].times(a[j, i]));
                    }
                }
            });

            return vals;
        }

        public virtual Vector<R> timesRight(Matrix<R> a) {
            if (Length() != a.NumRows())
                throw new DimensionMismatchException();

            var vals = new R[a.NumCols()];
            Parallel.For(0, a.NumCols(), j => {
                for (var i = 0; i < Length(); ++i) {
                    if (i == 0) {
                        vals[j] = this[i].times(a[i, j]);
                    }
                    else {
                        vals[j] = vals[j].plus(this[i].times(a[i, j]));
                    }
                }
            });

        return vals;
        }

        /// <summary>
        /// Multiply As, where s is a scalar
        /// </summary>
        /// <param name="scalar"></param>
        /// <returns></returns>
        public virtual Vector<R> timesRight(R scalar) {
            var vals = new R[Length()];

            Parallel.For(0, Length(),
                i => {
                    vals[i] = this[i].times(scalar);
                });

            return vals;
        }
        
        /// <summary>
        /// Multiply sA, where s is a scalar
        /// </summary>
        /// <param name="scalar"></param>
        /// <returns></returns>
        public virtual Vector<R> timesLeft(R scalar) {
            var vals = new R[Length()];

            Parallel.For(0, Length(),
                i => {
                        vals[i] = scalar.times(this[i]);
                });

            return vals;
        }

        public virtual Matrix<R> transpose() {
            var vals = new R[1, Length()];

            Parallel.For(0, Length(),
                i => { vals[0, i] = this[i];
            });

            return vals;
        }

        public virtual Vector<R> ZeroVector() {
            var vals = new R[Length()];

            Parallel.For(0, Length(),
            i => {
                    vals[i] = this[i].getZero();
            });

            return vals;
        }
        
        public static Vector<R> CreateSingleValueVector(R val, int n) {
            var vals = new R[n];

            Parallel.For(0, n,
                i => {
                    vals[i] = val;
                });

            return vals;
        }

        public virtual Vector<R> getZero() {
            return ZeroVector();
        }

        public virtual Vector<R> minus(Vector<R> A) {
            if(Length() != A.Length())
                throw new DimensionMismatchException();

            var vals = new R[Length()];

            Parallel.For(0, Length(),
                i => {
                    vals[i] = this[i].minus(A[i]);
                });

            return vals;
        }

        public virtual Vector<R> negative() {
            var vals = new R[Length()];

            Parallel.For(0, Length(),
                i => {
                        vals[i] = this[i].getZero().minus(this[i]);
                });

            return vals;
        }

        public virtual Vector<R> TensorProduct(Vector<R> v) {
            var vals = new R[Length() * v.Length()];
        
            Parallel.For(0, Length(),
                i1 => {
                        Parallel.For(0, v.Length(),
                            i2 => {
                                    vals[i2 + i1 * v.Length()] = this[i1].times(v[i2]);
                            });
                });
        
            return vals;
        }

        public Vector<R> scale(R x) {
            return timesLeft(x);
        }
        
        public Vector<F> EntryWiseApply<F>(MonoFunction<R, F> func) where F : FieldLikeObject<F> {
            var ent = new F[Length()];
            Parallel.For(0, Length(), i => {
                ent[i] = func.evaluate(entries[i]);
            });
            return ent;
        }

        public virtual R this[int i] {
            get => entries[i];
            set => entries[i] = value; 
        }
        
        public static implicit operator R[](Vector<R> A) {
            return A.entries;
        }

        public static implicit operator Vector<R>(R[] arr) {
            return new Vector<R>(arr);
        }

        public static implicit operator R(Vector<R> A) {
            if(A.Length() != 1)
                throw new DimensionMismatchException();
            return A[0];
        }

        public static implicit operator Vector<R>(R entry) {
            return new Vector<R>(new[] {entry});
        }
        
        public static implicit operator Matrix<R>(Vector<R> A) {
            var ent = new R[A.Length(), 1];
            Parallel.For(0, A.Length(), i => {
                ent[i, 0] = A[i];
            });
            return ent;
        }

        public static implicit operator Vector<R>(Matrix<R> A) {
            return new Vector<R>(A);
        }

        public static Vector<R> operator +(Vector<R> A, R B) {
            return A.plus(CreateSingleValueVector(B, A.Length()));
        }
        
        public static Vector<R> operator +(R B, Vector<R> A) {
            return CreateSingleValueVector(B, A.Length()).plus(A);
        }
        
        public static Vector<R> operator +(Vector<R> A, Vector<R> B) {
            return A.plus(B);
        }

        public static R operator *(Vector<R> A, Vector<R> B) {
            return A.dot(B);
        }
        
        public static Vector<R> operator *(Vector<R> A, Matrix<R> B) {
            return A.timesRight(B);
        }

        public static Vector<R> operator *(Matrix<R> A, Vector<R> B) {
            return B.timesLeft(A);
        }

        public static Vector<R> operator -(Vector<R> A, Vector<R> B) {
            return A.minus(B);
        }
        
        public static Vector<R> operator -(Vector<R> A) {
            return A.negative();
        }

        public static Vector<R> operator &(Vector<R> A, Vector<R> B) {
            return A.TensorProduct(B);
        }

        public static Matrix<R> operator ~(Vector<R> A) {
            return A.transpose();
        }
        
        public static Vector<R> operator *(Vector<R> A, R s) {
            return A.timesRight(s);
        }
        
        public static Vector<R> operator *(R s, Vector<R> A) {
            return A.timesLeft(s);
        }
    }
}