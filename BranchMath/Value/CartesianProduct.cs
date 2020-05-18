using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace BranchMath.Value {
    /// <summary>
    ///     Represents the cartesian product operator.
    /// </summary>
    /// <typeparam name="I">The value type of the sets</typeparam>
    public class CartesianProduct<I> : Mapping<Set<I>, Set<Tuple<I>>> where I : ValueType {
        public CartesianProduct() : base(-1) { }

        public override string ToLaTeX(Set<I>[] sets) {
            var latex = "";
            for (var i = 0; i < sets.Length; ++i) {
                latex += sets[i].ToLaTeX();
                if (i != sets.Length - 1)
                    latex += "\\times ";
            }

            return latex;
        }

        public override string ToLaTeX() {
            throw new NotImplementedException();
        }

        public override Set<Tuple<I>> evaluate(Set<I>[] input) {
            throw new NotImplementedException();
        }

        public override string ClassLaTeX() {
            return "\\mathrm{Set}^{n}";
        }

        /// <summary>
        ///     Recursively collects all of the elements in the cartesian product
        /// </summary>
        /// <param name="sets">The groups to compute the cartesian product of</param>
        /// <returns>A bag of all of the elements in the cartesian product</returns>
        private static ConcurrentBag<Tuple<I>> collectElements(ExplicitSet<I>[] sets) {
            var elements = new ConcurrentBag<Tuple<I>>();
            // If there is only one set, convert the identifiers to singleton arrays of elements
            // containing their identifiers
            if (sets.Length == 1) {
                Parallel.ForEach(sets[0].Elements, el =>
                    elements.Add(new Tuple<I>(new[] {el}))
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
                        var tup = new I[sets.Length];
                        tup[0] = elem;

                        Parallel.For(1, sets.Length, i => { tup[i] = el[i - 1]; });
                        var comb = new Tuple<I>(tup);
                        elements.Add(comb);
                    })
                );
            }

            return elements;
        }
    }
}