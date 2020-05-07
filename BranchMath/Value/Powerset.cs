using System.Linq;

namespace BranchMath.Value {
    /// <summary>
    ///     The powerset operator
    /// </summary>
    /// <typeparam name="I">The value type of the contents of the original set</typeparam>
    public class Powerset<I> : Mapping<Set<Set<I>>> where I : ValueType {
        /// <summary>
        ///     The set to compute the powerset of
        /// </summary>
        private readonly Set<I> set;

        public Powerset(Set<I> set) {
            this.set = set;
        }

        public override object evaluate() {
            switch (set) {
                case ExplicitSet<I> explicitSet: {
                    var subsets = new ExplicitSet<Set<I>>();
                    subsets.Elements.Add(Set<I>.EmptySet);
                    foreach (var elem in explicitSet.Elements) {
                        var combos = subsets.Elements.ToHashSet();

                        foreach (var copy in combos.Select(s => ((ExplicitSet<I>) s).Elements.ToHashSet())) {
                            copy.Add(elem);
                            subsets.Elements.Add(new ExplicitSet<I>(copy));
                        }
                    }

                    return subsets;
                }
                case DerivedSet<I> derivedSet:
                    return new DerivedSet<Set<I>>(s => s.IsSubset(set), derivedSet.GetCardinality().powerset(),
                        "x \\subseteq" + set.ToLaTeX());
                default:
                    return null;
            }
        }

        public override string ToLaTeX() {
            return "P(" + set.ToLaTeX() + ")";
        }

        public override string ClassLaTeX() {
            return "\\mathrm\\{Set\\} \\to \\mathrm\\{Set\\}";
        }
    }
}