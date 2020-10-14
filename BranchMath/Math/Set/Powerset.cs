using System.Linq;
using BranchMath.Math.Value;

namespace BranchMath.Math.Set {
    /// <summary>
    ///     The powerset operator
    /// </summary>
    /// <typeparam name="I">The value type of the contents of the original set</typeparam>
    public class Powerset<I> : MonoFunction<Set<I>, Set<Set<I>>> where I : ValueType {
        public static Set<Set<I>> compute(Set<I> set) {
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

        public override string ToLaTeX(Set<I> set) {
            return "P(" + set.ToLaTeX() + ")";
        }

        public override string ToLaTeX() {
            return "\\mathcal{P}";
        }

        public override Set<Set<I>> evaluate(Set<I> input) {
            return compute(input);
        }

        public override string ClassLaTeX() {
            return "\\mathrm\\{Set\\} \\to \\mathrm\\{Set\\}";
        }
    }
}