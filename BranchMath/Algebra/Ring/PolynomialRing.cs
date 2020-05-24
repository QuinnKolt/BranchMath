using System;
using System.Collections.Generic;
using System.Linq;
using BranchMath.Algebra.Field;
using BranchMath.Arithmetic;
using BranchMath.Arithmetic.Number;
using BranchMath.Value;

namespace BranchMath.Algebra.Ring {
    public class PolynomialRing<F, R> : Ring<R[]> where R : RingElement<F> {

        public Ring<F> Ring;

        public PolynomialRing(Ring<F> ring) {
            Ring = ring;
        }
        
        public override string DisplayElement(AlgebraicElement<R[]> g) {
            var poly = (Polynomial) g;
            var str = "";
            
            for (var i = poly.degree(); i >= 0; --i) {
                if (poly[i] == 0)
                    continue;
                switch (i) {
                    case 0:
                        if (i < poly.degree())
                            str += " + ";
                        str += poly[0].ToLaTeX();
                        break;
                    case 1:
                        if (i < poly.degree())
                            str += " + ";
                        str += poly[1] == 1? "x": poly[1].ToLaTeX() + "x";
                        break;
                    default:
                        if (i < poly.degree())
                            str += " + ";
                        str += poly[i] == 1? $"x^{{{i}}}":  poly[i].ToLaTeX() + $"x^{{{i}}}";
                        break;
                }

            }

            return str;
        }

        public override string ToLaTeX() {
            return Ring.ToLaTeX() + "[x]";
        }

        public override RingElement<R[]> MultiplyElements(RingElement<R[]> g, RingElement<R[]> h) {
            var polyg = (Polynomial) g;
            var polyh = (Polynomial) h;
            var len = polyg.degree() + polyh.degree() + 2;
            var coeffs = new R[len];

            for (var pow = 0; pow < len; ++pow) {
                coeffs[pow] = (R) Ring.getZero();
                for (var gi = 0; gi <= pow; ++gi) {
                    var hi = pow - gi;
                    coeffs[pow] = (R) (coeffs[pow] + polyg[gi] * polyh[hi]);
                }
            }

            return new Polynomial(coeffs.ToArray(), this);
        }

        public override RingElement<R[]> AddElements(RingElement<R[]> g, RingElement<R[]> h) {
            var polyg = (Polynomial) g;
            var polyh = (Polynomial) h;
            var len = Math.Max(polyg.degree() + 1, polyh.degree() + 1);
            var coeffs = new List<R>();
            
            for (var i = 0; i < len; ++i) { 
                coeffs.Add((R) (polyg[i] + polyh[i]));
            }
            
            return new Polynomial(coeffs.ToArray(), this);
        }

        public override RingElement<R[]> GetAdditiveInverse(RingElement<R[]> g) {
            var polyg = (Polynomial) g;
            var coeffs = new R[polyg.degree() + 1];
            for (var i = 0; i < coeffs.Length; ++i) {
                coeffs[i] = (R)(-polyg[i]);
            }

            return new Polynomial(coeffs, this);
        }

        public override RingElement<R[]> GetMultiplicativeInverse(RingElement<R[]> g) {
            var polyg = (Polynomial) g;
            if (polyg.degree() == 1) {
                return new Polynomial(new []{(R) (1 / polyg[0])}, this);
            }

            throw new DivideByZeroException();
        }

        public override RingElement<R[]> getOne() {
            return new Polynomial(new []{(R) Ring.getOne()}, this);
        }

        public override RingElement<R[]> getZero() {
            return new Polynomial(new []{(R) Ring.getZero()}, this);
        }
        
        public class Polynomial : RingElement<R[]>, Multipliable<Polynomial>, Summable<Polynomial>, Powerable<Polynomial, Integer> {
            
            public readonly R[] Coefficients;

            public R this[int i] => i < degree() + 1 ? Coefficients[i]: 
                (R) ((PolynomialRing<F, R>) structure).Ring.getZero();

            public Polynomial(R[] coefficients, PolynomialRing<F, R> structure) : base(coefficients, structure) {
                var coeffs = coefficients.ToList();
            
                for (var i = coefficients.Length - 1; i >= 0; --i) {
                    if (coefficients[i] == 0) {
                        coeffs.RemoveAt(i);
                    }
                    else {
                        break;
                    }
                }

                Coefficients = coeffs.ToArray();
            }

            public int degree() {
                return Coefficients.Length - 1;
            }
            
            public static Polynomial operator +(Polynomial g, R h) {
                return (Polynomial) (g + new Polynomial(new[] {h}, (PolynomialRing<F, R>) g.structure));
            }
            
            public static Polynomial operator *(Polynomial g, R h) {
                return (Polynomial) (g * new Polynomial(new[] {h}, (PolynomialRing<F, R>) g.structure));
            }
            
            public static Polynomial operator +(R h, Polynomial g) {
                return (Polynomial) (new Polynomial(new[] {h}, (PolynomialRing<F, R>) g.structure) + g);
            }
            
            public static Polynomial operator *(R h, Polynomial g) {
                return (Polynomial) (new Polynomial(new[] {h}, (PolynomialRing<F, R>) g.structure) * g);
            }

            public Polynomial times(Polynomial a) {
                return (Polynomial) (this * a);
            }

            public Polynomial sum(Polynomial a) {
                return (Polynomial) (this + a);
            }

            public new Polynomial pow(Integer p) {
                return (Polynomial) (this ^ p);
            }
        }
    }
}
