using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using BranchMath.Display;
using BranchMath.Numbers;
using BranchMath.Tree;

namespace BranchMath.Algebra.Groups {
    /// <summary>
    ///     Represents a mathematical group with a binary operation of multiplication.
    /// </summary>
    /// <typeparam name="I">The type of the identifiers of the elements of the group</typeparam>
    public abstract class Group<I> : AlgebraicStructure<I> {

        /// <summary>
        ///     Find the product of two elements in the group.
        /// </summary>
        /// <param name="g">The first element to multiply.</param>
        /// <param name="h">The second element to multiply.</param>
        /// <returns>The element gh.</returns>
        public abstract AlgebraicElement<I> MultiplyElements(AlgebraicElement<I> g, AlgebraicElement<I> h);

        /// <summary>
        ///     Find the inverse of the given element in the group.
        /// </summary>
        /// <param name="g">The element to find the inverse of</param>
        /// <returns>The inverse of the given element</returns>
        public abstract AlgebraicElement<I> GetInverse(AlgebraicElement<I> g);


        public Table<string, string, string> GetCayleyTable() {
            if (Elements is ExplicitSet<AlgebraicElement<I>>) {
                AlgebraicElement<I>[] elements = ((ExplicitSet<AlgebraicElement<I>>) Elements).Elements.ToArray();
                string[] xlabels = new string[elements.Length];
                string[] ylabels = new string[elements.Length];
                string[,] products = new string[elements.Length,elements.Length];
                for (int i = 0; i < elements.Length; ++i) {
                    xlabels[i] = DisplayElement(elements[i]);
                    ylabels[i] = DisplayElement(elements[i]);
                    for (int j = 0; j < elements.Length; ++j) {
                        products[i,j] = DisplayElement(MultiplyElements(elements[i], elements[j]));
                    } 
                }
                return new Table<string, string, string>(products, xlabels, ylabels);
            }

            throw new InfiniteSizeException("Cardinality is infinite");
        }
    }
}