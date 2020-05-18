using System;
using System.Diagnostics;
using System.Numerics;
using BranchMath.Arithmetic.Number;

namespace BranchMath.Algebra.Ring {
    /// <summary>
    ///     Represents an element of a group (e.g. an integer in the integers over addition)
    /// </summary>
    /// <typeparam name="I">The identifier type of for the elements of this group</typeparam>
    public class RingElement<I> : AlgebraicElement<I> {
        /// <summary>
        ///     Create a new Ring Element
        /// </summary>
        /// <param name="identifier">Identifier that allows manipulation of the element</param>
        /// <param name="structure">The ring to which this element belongs to</param>
        public RingElement(I identifier, Ring<I> structure) : base(identifier, structure) { }

        /// <summary>
        ///     Perform multiplication between two elements
        /// </summary>
        /// <param name="g">The left element to multiply</param>
        /// <param name="h">The right element to multiply</param>
        /// <returns>The product of the two elements</returns>
        public static RingElement<I> operator *(RingElement<I> g, RingElement<I> h) {
            return ((Ring<I>) g.structure).MultiplyElements(g, h);
        }

        /// <summary>
        ///     Perform repeated addition on an element
        /// </summary>
        /// <param name="n">The number of repetitions</param>
        /// <param name="h">The element to multiply</param>
        /// <returns>The product of the number and the element</returns>
        // TODO: write a more quick algorithm for this
        public static RingElement<I> operator *(Integer n, RingElement<I> h) {
            var prod = h;
            for (BigInteger i = 1; i < n.val; ++i) prod += h;

            return prod;
        }

        /// <summary>
        ///     Perform repeated addition on an element
        /// </summary>
        /// <param name="n">The number of repetitions</param>
        /// <param name="h">The element to multiply</param>
        /// <returns>The product of the number and the element</returns>
        public static RingElement<I> operator *(RingElement<I> h, Integer n) {
            return n * h;
        }

        /// <summary>
        ///     Perform addition between two elements
        /// </summary>
        /// <param name="g">The left element to add</param>
        /// <param name="h">The right element to add</param>
        /// <returns>The sum of the two elements</returns>
        public static RingElement<I> operator +(RingElement<I> g, RingElement<I> h) {
            return ((Ring<I>) g.structure).AddElements(g, h);
        }

        /// <summary>
        ///     Perform subtraction between two elements
        /// </summary>
        /// <param name="g">The minuend</param>
        /// <param name="h">The subtrahend</param>
        /// <returns>The difference of the two elements</returns>
        public static RingElement<I> operator -(RingElement<I> g, RingElement<I> h) {
            return ((Ring<I>) g.structure).AddElements(g, ((Ring<I>) g.structure).GetAdditiveInverse(h));
        }

        /// <summary>
        ///     Get the additive inverse of the given element
        /// </summary>
        /// <param name="g">The element</param>
        /// <returns>The inverse of the given element</returns>
        public static RingElement<I> operator -(RingElement<I> g) {
            return ((Ring<I>) g.structure).GetAdditiveInverse(g);
        }

        /// <summary>
        ///     Perform division between two elements
        /// </summary>
        /// <param name="g">The dividend</param>
        /// <param name="h">The divisor</param>
        /// <returns>The quotient of the two elements</returns>
        public static RingElement<I> operator /(RingElement<I> g, RingElement<I> h) {
            return ((Ring<I>) g.structure).MultiplyElements(g, ((Ring<I>) g.structure).GetMultiplicativeInverse(h));
        }

        public static RingElement<I> operator ^(RingElement<I> g, Integer n) {
            var pow = g;
            for (BigInteger i = 1; i < n.val; ++i) pow *= g;

            return pow;
        }

        /// <summary>
        ///     Perform multiplication between two elements
        /// </summary>
        /// <param name="g">The left element to multiply</param>
        /// <param name="i">0, 1, or -1</param>
        /// <returns>The product of the two elements</returns>
        public static RingElement<I> operator *(RingElement<I> g, int i) {
            switch (i) {
                case 0:
                    return ((Ring<I>) g.structure).getZero();
                case 1:
                    return g;
                case -1:
                    return -g;
                default:
                    throw new InvalidElementException();
            }
        }

        /// <summary>
        ///     Perform addition between two elements
        /// </summary>
        /// <param name="g">The left element to add</param>
        /// <param name="i">0, 1, or -1</param>
        /// <returns>The sum of the two elements</returns>
        public static RingElement<I> operator +(RingElement<I> g, int i) {
            switch (i) {
                case 0:
                    return g;
                case 1:
                    return g + ((Ring<I>) g.structure).getOne();
                case -1:
                    return g + -((Ring<I>) g.structure).getOne();
                default:
                    throw new InvalidElementException();
            }
        }

        /// <summary>
        ///     Perform subtraction between two elements
        /// </summary>
        /// <param name="g">The minuend</param>
        /// <param name="i">0, 1, or -1</param>
        /// <returns>The difference of the two elements</returns>
        public static RingElement<I> operator -(RingElement<I> g, int i) {
            switch (i) {
                case 0:
                    return g;
                case 1:
                    return g + -((Ring<I>) g.structure).getOne();
                case -1:
                    return g + ((Ring<I>) g.structure).getOne();
                default:
                    throw new InvalidElementException();
            }
        }

        /// <summary>
        ///     Perform division between two elements
        /// </summary>
        /// <param name="g">The dividend</param>
        /// <param name="i">0, 1, or -1</param>
        /// <returns>The quotient of the two elements</returns>
        public static RingElement<I> operator /(RingElement<I> g, int i) {
            switch (i) {
                case 0:
                    throw new DivideByZeroException();
                case 1:
                    return g;
                case -1:
                    return -g;
                default:
                    throw new InvalidElementException();
            }
        }

        /// <summary>
        ///     Perform multiplication between two elements
        /// </summary>
        /// <param name="i">0, 1, or -1</param>
        /// <param name="h">The left element to multiply</param>
        /// <returns>The product of the two elements</returns>
        public static RingElement<I> operator *(int i, RingElement<I> h) {
            switch (i) {
                case 0:
                    return ((Ring<I>) h.structure).getZero();
                case 1:
                    return h;
                case -1:
                    return -h;
                default:
                    throw new InvalidElementException();
            }
        }

        /// <summary>
        ///     Perform addition between two elements
        /// </summary>
        /// <param name="i">0, 1, or -1</param>
        /// <param name="h">The right element to add</param>
        /// <returns>The sum of the two elements</returns>
        public static RingElement<I> operator +(int i, RingElement<I> h) {
            switch (i) {
                case 0:
                    return h;
                case 1:
                    return ((Ring<I>) h.structure).getOne() + h;
                case -1:
                    return -((Ring<I>) h.structure).getOne() + h;
                default:
                    throw new InvalidElementException();
            }
        }

        /// <summary>
        ///     Perform subtraction between two elements
        /// </summary>
        /// <param name="i">0, 1, or -1</param>
        /// <param name="h">The subtrahend</param>
        /// <returns>The difference of the two elements</returns>
        public static RingElement<I> operator -(int i, RingElement<I> h) {
            switch (i) {
                case 0:
                    return -h;
                case 1:
                    return ((Ring<I>) h.structure).getOne() - h;
                case -1:
                    return -(((Ring<I>) h.structure).getOne() + h);
                default:
                    throw new InvalidElementException();
            }
        }

        /// <summary>
        ///     Perform division between two elements
        /// </summary>
        /// <param name="i">0, 1, or -1</param>
        /// <param name="h">The divisor</param>
        /// <returns>The quotient of the two elements</returns>
        public static RingElement<I> operator /(int i, RingElement<I> h) {
            switch (i) {
                case 0:
                    throw new DivideByZeroException();
                case 1:
                    return ((Ring<I>) h.structure).GetMultiplicativeInverse(h);
                case -1:
                    return -((Ring<I>) h.structure).GetMultiplicativeInverse(h);
                default:
                    throw new InvalidElementException();
            }
        }

        /// <summary>
        ///     Compare an element to a unit or identity
        /// </summary>
        /// <param name="h">The element</param>
        /// <param name="i">0, 1, or -1</param>
        /// <returns>Whether or not h is the corresponding ring element</returns>
        public static bool operator ==(RingElement<I> h, int i) {
            Debug.Assert(h != null, nameof(h) + " != null");
            switch (i) {
                case 0:
                    return h.Equals(((Ring<I>) h.structure).getZero());
                    ;
                case 1:
                    return h.Equals(((Ring<I>) h.structure).getOne());
                case -1:
                    return h.Equals(-((Ring<I>) h.structure).getOne());
                default:
                    throw new InvalidElementException();
            }
        }

        /// <summary>
        ///     Compare an element to a unit or identity
        /// </summary>
        /// <param name="h">The element</param>
        /// <param name="i">0, 1, or -1</param>
        /// <returns>The negation of whether or not h is the corresponding ring element</returns
        public static bool operator !=(RingElement<I> h, int i) {
            return !(h == i);
        }

        /// <summary>
        ///     Compare an element to a unit or identity
        /// </summary>
        /// <param name="i">0, 1, or -1</param>
        /// <param name="h">The element</param>
        /// <returns>Whether or not h is the corresponding ring element</returns>
        public static bool operator ==(int i, RingElement<I> h) {
            return h == i;
        }

        /// <summary>
        ///     Compare an element to a unit or identity
        /// </summary>
        /// <param name="i">0, 1, or -1</param>
        /// <param name="h">The element</param>
        /// <returns>The negation of whether or not h is the corresponding ring element</returns>
        public static bool operator !=(int i, RingElement<I> h) {
            return !(h == i);
        }
    }
}