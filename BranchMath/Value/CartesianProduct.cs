using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BranchMath.Value {
    /// <summary>
    ///     Represents the cartesian product operator.
    /// </summary>
    /// <typeparam name="I">The value type of the sets</typeparam>
    public class CartesianProduct<I> : Mapping<Set<Tuple>> where I : ValueType {
        public HashSet<Tuple> explicitCart;
        private readonly Set<I>[] sets;

        public CartesianProduct(Set<I>[] sets) {
            this.sets = sets;
        }

        public CartesianProduct(ExplicitSet<I>[] sets) {
            this.sets = new Set<I>[sets.Length];
            for (var i = 0; i < sets.Length; ++i) this.sets[i] = sets[i];

            explicitCart = collectElements(sets).ToHashSet();
        }

        public override object evaluate() {
            return null;
        }

        public override string ToLaTeX() {
            var latex = "";
            for (var i = 0; i < sets.Length; ++i) {
                latex += sets[i].ToLaTeX();
                if (i != sets.Length - 1)
                    latex += "\\times ";
            }

            return latex;
        }

        public override string ClassLaTeX() {
            var latex = "";
            for (var i = 1; i < sets.Length; ++i) latex += "\\mathrm{Set}\\times";
            latex += "\\mathrm{Set} \\to \\mathrm{Set}";

            return latex;
        }

        /// <summary>
        ///     Recursively collects all of the elements in the cartesian product
        /// </summary>
        /// <param name="sets">The groups to compute the cartesian product of</param>
        /// <returns>A bag of all of the elements in the cartesian product</returns>
        private static ConcurrentBag<Tuple> collectElements(ExplicitSet<I>[] sets) {
            var elements = new ConcurrentBag<Tuple>();
            // If there is only one set, convert the identifiers to singleton arrays of elements
            // containing their identifiers
            if (sets.Length == 1) {
                Parallel.ForEach(sets[0].Elements, el =>
                    elements.Add(new Tuple(new ValueType[] {el}))
                );
            }

            else {
                // Recursively collect all of the elements in the cartesian product of all sets except the first
                var otherSets = new ExplicitSet<I>[sets.Length - 1];
                Array.Copy(sets, 1, otherSets, 0, sets.Length - 1);
                var otherGroupElems = collectElements(otherSets);

                // Find all tuples containing this element as the first entry combined with all other tuples obtained
                // recursively
                Parallel.ForEach(sets[0].Elements, elem =>
                    Parallel.ForEach(otherGroupElems, el => {
                        var tup = new ValueType[sets.Length];
                        tup[0] = elem;

                        Parallel.For(1, sets.Length, i => { tup[i] = el[i - 1]; });
                        var comb = new Tuple(tup);
                        elements.Add(comb);
                    })
                );
            }

            return elements;
        }
    }
}