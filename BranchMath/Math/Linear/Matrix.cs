using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BranchMath.Math.Arithmetic;
using BranchMath.Math.Arithmetic.Number;
using BranchMath.Math.Value;
using ValueType = BranchMath.Math.Value.ValueType;

namespace BranchMath.Math.Linear {
    public class Matrix<R> : MonoFunction<Vector<R>, Vector<R>>, Scalable<Matrix<R>, R>, Divideable<Matrix<R>>
        where R : Divideable<R>, Subtractable<R> {
        internal readonly R[,] entries;

        public Matrix(R[,] entries) {
            if(entries.Length == 0) 
                throw new DimensionMismatchException();
            
            this.entries = entries;
        }

        public Matrix(IReadOnlyList<R[]> entries) {
            if(entries.Count == 0) 
                throw new DimensionMismatchException();
            this.entries = new R[entries.Count,entries[0].Length];
            Parallel.For(0, entries.Count, i => {
                Parallel.For(0, entries[0].Length, j => {
                    this[i,j] = entries[i][j];
                });
            });
        }
        
        public static Matrix<R> import<D1, D2>(BiFunction<D1, D2, R> func, D1[] rows, D2[] cols) 
            where D1 : ValueType where D2 : ValueType {
            var entries = new R[rows.Length, cols.Length];
            Parallel.For(0, rows.Length, i => {
                Parallel.For(0, rows.Length, j => {
                    entries[i, j] = func.evaluate(rows[i], cols[j]);
                });
            });

            return entries;
        }

        public virtual object evaluate() {
            return entries;
        }

        public override Vector<R> evaluate(Vector<R> input) {
            return times(input);
        }

        public override string ToLaTeX(Vector<R> input) {
            return ToLaTeX() + " " + input.ToLaTeX();
        }

        public override string ToLaTeX() {
            var s = @"\begin{bmatrix}";
            s += "\n";
            for (var i = 0; i < NumRows(); ++i) {
                for (var j = 0; j < NumCols(); ++j) {
                    s += this[i, j].ToLaTeX() + " & ";
                }

                s = s.Substring(0, s.Length-2) + "\\\\\n";
            }

            s = s.Substring(0, s.Length - 3) + "\n";
            s += @"\end{bmatrix}";
            return s;
        }

        public virtual int NumRows() {
            return entries.GetLength(0);
        }
        public virtual int NumCols() {
            return entries.GetLength(1);
        }

        public override string ClassLaTeX() {
            return this[0, 0].ClassLaTeX() +
                   $"^{{{NumRows()} \\times {NumCols()}}}";
        }

        public virtual Matrix<R> plus(Matrix<R> a) {
            if(NumRows() != a.NumRows() || NumCols() != a.NumCols())
                throw new DimensionMismatchException();
            
            var vals = new R[NumRows(), NumCols()];

            Parallel.For(0, NumRows(),
                i => {
                Parallel.For(0, NumCols(), j => {
                    vals[i, j] = this[i, j].plus(a[i, j]);
                });
            });

            return vals;
        }

        public virtual Matrix<R> times(Matrix<R> a) {
            if(NumCols() != a.NumRows())
                throw new DimensionMismatchException();

            var vals = new R[NumRows(), a.NumCols()];

            Parallel.For(0, NumRows(), i => {
                Parallel.For(0, a.NumCols(), k => {
                    for (var j = 0; j < NumCols(); ++j) {
                        if (j == 0) {
                            vals[i, k] = this[i, j].times(a[j, k]);
                        }
                        else {
                            vals[i, k] = vals[i, k].plus(
                                this[i, j].times(a[j, k]));
                        }
                    }
                });
            });

            return vals;
        }

        public virtual Matrix<R> timesLeft(Matrix<R> A) {
            return A.times(this);
        }
        
        public virtual Matrix<R> timesRight(Matrix<R> A) {
            return times(A);
        }

        /// <summary>
        /// Multiply As, where s is a scalar
        /// </summary>
        /// <param name="scalar"></param>
        /// <returns></returns>
        public virtual Matrix<R> timesRight(R scalar) {
            var vals = new R[NumRows(), NumCols()];

            Parallel.For(0, NumRows(),
                i => {
                    Parallel.For(0, NumCols(), j => {
                        vals[i, j] = this[i, j].times(scalar);
                    });
                });

            return vals;
        }
        
        /// <summary>
        /// Multiply sA, where s is a scalar
        /// </summary>
        /// <param name="scalar"></param>
        /// <returns></returns>
        public virtual Matrix<R> timesLeft(R scalar) {
            var vals = new R[NumRows(), NumCols()];

            Parallel.For(0, NumRows(),
                i => {
                    Parallel.For(0, NumCols(), j => {
                        vals[i, j] = scalar.times(entries[i, j]);
                    });
                });

            return vals;
        }

        public virtual Matrix<R> transpose() {
            var vals = new R[NumCols(), NumRows()];

            Parallel.For(0, NumRows(),
                i => { Parallel.For(0, NumCols(), j => {
                    vals[j, i] = this[i, j];
                }); 
            });

            return vals;
        }

        public virtual Matrix<R> ZeroMatrix() {
            var vals = new R[NumRows(), NumCols()];

            Parallel.For(0, NumRows(),
                i => {
                    Parallel.For(0, NumCols(), j => {
                        vals[i, j] = this[0, 0].getZero();
                    });
                });

            return vals;
        }
        
        public static Matrix<R> CreateSingleValueMatrix(R val, int n, int m) {
            var vals = new R[n, m];

            Parallel.For(0, n,
                i => {
                    Parallel.For(0, m, j => {
                        vals[i, j] = val;
                    });
                });

            return vals;
        }
        
        public static Matrix<R> CreateConstantDiagonalMatrix(R diag, R offDiag, int n, int m) {
            var vals = new R[n, m];

            Parallel.For(0, n,
                i => {
                    Parallel.For(0, m, j => {
                        if (i != j)
                            vals[i, j] = offDiag;
                        else
                            vals[i, j] = diag;
                    });
                });

            return vals;
        }
        
        public virtual Matrix<R> IdentityMatrix() {
            if(NumRows() != NumCols())
                throw new DimensionMismatchException();
            if (!(entries[0, 0] is Divideable<R>)) {
                throw new InvalidCastException();
            }
            
            var vals = new R[NumRows(), NumCols()];

            Parallel.For(0, NumRows(),
                i => {
                    Parallel.For(0, NumCols(), j => {
                        if (i != j)
                            vals[i, j] = this[i, j].getZero();
                        else
                            vals[i, j] = ((Divideable<R>) this[i, j]).getOne();
                    });
                });

            return vals;
        }

        public Matrix<R> getZero() {
            return ZeroMatrix();
        }

        public virtual Matrix<R> minus(Matrix<R> A) {
            if(NumRows() != A.NumRows() ||
               NumCols() != A.NumCols())
                throw new DimensionMismatchException();

            var vals = new R[NumRows(), NumCols()];

            Parallel.For(0, NumRows(),
                i => {
                    Parallel.For(0, NumCols(), j => {
                        vals[i, j] = this[i, j].minus(A[i, j]);
                    });
                });

            return vals;
        }

        public virtual Matrix<R> negative() {
            var vals = new R[NumRows(), NumCols()];

            Parallel.For(0, NumRows(),
                i => {
                    Parallel.For(0, NumCols(), j => {
                        vals[i, j] = this[i, j].getZero().minus(entries[i, j]);
                    });
                });

            return vals;
        }

        public virtual Matrix<R> pow(Natural n) {
            if(NumRows() != NumCols())
                throw new DimensionMismatchException();
            
            if (n == 0)
                return IdentityMatrix();

            var times = this;
            var mat = times;
            
            for (var i = 1; i < n.val; ++i) {
                mat = mat.times(times);
            }

            return mat;
        }

        public virtual Matrix<R> TensorProductExpand(Matrix<R> A) {
            var vals = new R[NumRows() * A.NumRows(), 
                NumCols() * A.NumCols()];

            Parallel.For(0, NumRows(),
                i1 => {
                    Parallel.For(0, NumCols(), j1 => {
                        Parallel.For(0, A.NumRows(),
                            i2 => {
                                Parallel.For(0, A.NumCols(), j2 => {
                                    vals[i2 + i1 * A.NumRows(), j2 + j1 * A.NumCols()]
                                        = this[i1, j1].times(A[i2, j2]);
                                });
                            });
                    });
                });

            return vals;
        }
        
        public virtual Matrix<Matrix<R>> TensorProductBlock(Matrix<R> A) {
            var vals = new Matrix<R>[NumRows(), 
                NumCols()];

            Parallel.For(0, NumRows(),
                i1 => {
                    Parallel.For(0, NumCols(), j1 => {
                        vals[i1, j1] = this[i1, j1] * A;
                    });
                });

            return vals;
        }

        public static Matrix<R> unblock(Matrix<Matrix<R>> mat) {
            var vals = new R[mat.NumRows() * mat[0, 0].NumRows(), 
                mat.NumCols() * mat[0, 0].NumCols()];
            
            Parallel.For(0, mat.NumRows(),i1 => {
                Parallel.For(0, mat.NumCols(), j1 => {
                    Parallel.For(0, mat[i1,j1].NumRows(), i2 => {
                        Parallel.For(0, mat[i1,j1].NumCols(), j2 => {
                            vals[i2 + i1 * mat[0,0].NumRows(), j2 + j1 * mat[0,0].NumCols()]
                                = ((Matrix<R>) mat[i1, j1])[i2, j2];
                        });
                    });
                });
            });

            return vals;
        }

        public static implicit operator R[,](Matrix<R> A) {
            return A.entries;
        }

        public static implicit operator Matrix<R>(R[,] arr) {
            return new Matrix<R>(arr);
        }

        public virtual Matrix<R> this[int i, int j] {
            get => entries[i, j];
            set => setSubmatrix(i, j, value);
        }

        public virtual Matrix<R> this[int i1, int i2, int j1, int j2] {
            get => getSubmatrix(i1, i2, j1, j2);
            set => setSubmatrix(i1, j1, value);
        }

        public virtual Matrix<R> getSubmatrix(int i1, int i2, int j1, int j2) {
            var ent = new R[i2 - i1, j2 - j1];
            
            Parallel.For(i1, i2, i => { 
                Parallel.For(j1, j2, j => {
                    ent[i - i1, j - j1] = this[i, j];
                });
            });

            return ent;
        }

        public virtual void setSubmatrix(int i1, int j1, Matrix<R> mat) {
            Parallel.For(0, mat.NumRows(), i => { 
                Parallel.For(0, mat.NumCols(), j => {
                    this[i+i1, j+j1] = mat[i, j];
                });
            });
        }

        public virtual Matrix<R> deleteCross(int row, int col) {
            if(NumRows() == 1 || NumCols() == 1)
                throw new DimensionMismatchException();
            
            var ent = new R[NumRows()-1, NumCols()-1];
            
            Parallel.For(0, NumRows()-1, i => { 
                Parallel.For(0, NumCols()-1, j => {
                    ent[i, j] = this[i < row? i : i + 1, j < col? j : j + 1];
                });
            });

            return ent;
        }

        public virtual R determinant() {
            if(NumCols() != NumRows())
                throw new DimensionMismatchException();
            if (NumRows() == 1)
                return this;
            
            var det = default(R);
            var key = new object();

            Parallel.For(0, NumRows(), i => {
                var del = deleteCross(i, 0);
                var detdel = ((R) this[i, 0]).times(del.determinant());
                
                if (i % 2 == 0)
                    detdel = detdel.getZero().minus(detdel);
                
                lock (key) {
                    det = det == null ? detdel: det.plus(detdel);
                }
            });

            return det;
        }
        

        public Matrix<R> scale(R x) {
            return timesLeft(x);
        }

        public Matrix<F> Apply<F>(MonoFunction<R, F> func) where F : FieldLikeObject<F> {
            var ent = new F[NumRows(),NumCols()];
            Parallel.For(0, NumRows(), i => {
                Parallel.For(0, NumCols(), j => {
                    ent[i, j] = func.evaluate(entries[i, j]); 
                });
            });
            return ent;
        }
        
        public Matrix<F> Apply<R1, F>(Matrix<R1> mat, BiFunction<R, R1, F> func) where F : FieldLikeObject<F> where R1 : FieldLikeObject<R1> {
            var ent = new F[NumRows(), NumCols()];
            Parallel.For(0, NumRows(), i => {
                Parallel.For(0, NumCols(), j => {
                    ent[i, j] = func.evaluate(entries[i, j], mat.entries[i, j]); 
                });
            });
            return ent;
        }

        public static implicit operator R(Matrix<R> A) {
            if(A.NumRows() != 1 || A.NumCols() != 1)
                throw new DimensionMismatchException();
            return A[0, 0];
        }

        public static implicit operator Matrix<R>(R entry) {
            return new Matrix<R>(new[,]{{entry}});
        }

        public Vector<R> solve(Vector<R> b) {
            throw new NotImplementedException();
        }

        public Matrix<R> inverse() {
            // var inverse = IdentityMatrix();
            // for (var row = 0; row < NumRows(); ++row) {
                // if (row) {
                    
                // }
            // }
            throw new NotImplementedException();
        }

        public Matrix<R> getOne() {
            return IdentityMatrix();
        }

        public Matrix<R> dividedBy(Matrix<R> d) {
            return times(d.inverse());
        }
        
        public static Matrix<R> operator +(Matrix<R> A, Matrix<R> B) {
            return B.GetType() != typeof(Matrix<R>) ? B.plus(A) : A.plus(B);
        }

        public static Matrix<R> operator *(Matrix<R> A, Matrix<R> B) {
            return B.GetType() != typeof(Matrix<R>) ? B.timesLeft(A) : A.timesRight(B);
        }

        public static Matrix<R> operator -(Matrix<R> A, Matrix<R> B) {
            return B.GetType() != typeof(Matrix<R>) ? B.negative().plus(A) : A.minus(B);
        }
        
        public static Matrix<R> operator -(Matrix<R> A) {
            return A.negative();
        }

        public static Matrix<R> operator &(Matrix<R> A, Matrix<R> B) {
            return A.TensorProductExpand(B);
        }

        public static Matrix<R> operator ~(Matrix<R> A) {
            return A.transpose();
        }
        
        public static Matrix<R> operator *(Matrix<R> A, R s) {
            return A.timesRight(s);
        }
        
        public static Matrix<R> operator *(R s, Matrix<R> A) {
            return A.timesLeft(s);
        }

        public static Matrix<R> operator ^(Matrix<R> A, Integer n) {
            
            if(A.NumRows() != A.NumCols())
                throw new DimensionMismatchException();
            
            if (n == 0)
                return A.IdentityMatrix();

            var times = n > 0 ? A : A.inverse();
            var mat = times;
            Console.WriteLine(n.val);
            if (n < 0)
                n = -n;
            

            return mat.pow(new Natural(n));
        }
    }
}