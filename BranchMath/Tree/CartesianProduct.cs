using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using BranchMath.Algebra;
using BranchMath.Algebra.Groups;

namespace BranchMath.Tree {
    public class CartesianProduct<I> : FunctionNode<Set<Tuple<I>>> where I : ValueType {
        
        
        public Node simplify() {
            return this;
        }

        public FunctionNode<Set<Tuple<I>>> deep_copy() {
            return this;
        }


        public Set<Tuple<I>> evaluate() {
            return null;
        }
        
        
        /// <summary>
        ///     Recursively collects all of the elements in the cartesian product
        /// </summary>
        /// <param name="sets">The groups to compute the cartesian product of</param>
        /// <returns>A bag of all of the elements in the cartesian product</returns>
        private static ConcurrentBag<I> collectElements(Set<I>[] sets) {
            // var elements = new ConcurrentBag<I>();
            // // If there is only one group, convert the identifiers to singleton arrays of elements
            // // containing their identifiers
            // if (sets.Length == 1) {
            //     Parallel.ForEach(sets[0].Elements, el =>
            //         elements.Add(new AlgebraicElement<object[]>(new[] {el.Identifier}))
            //     );
            // }
            //
            // else {
            //     // Recursively collect all of the elements in the cartesian product group of all groups except the first
            //     var otherGroups = new Group<object>[sets.Length - 1];
            //     Array.Copy(sets, 0, otherGroups, 1, sets.Length);
            //     var otherGroupElems = collectElements(otherGroups);
            //
            //     // Find all tuples containing this element as the first entry combined with all other tuples obtained
            //     // recursively
            //     Parallel.ForEach(sets[0].Elements, elem =>
            //         Parallel.ForEach(otherGroupElems, el => {
            //             var tup = new I[sets.Length];
            //             tup[0] = elem.Identifier;
            //
            //             Parallel.For(1, sets.Length, i => { tup[i] = el.Identifier[i - 1]; });
            //             var comb = new Tuple<I>(tup);
            //             elements.Add(comb);
            //         })
            //     );
            // }
            //
            // return elements;
            return null;
        }
    }
}