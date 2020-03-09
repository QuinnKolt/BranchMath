using System.Threading.Tasks;
using BranchMath.Tree;

namespace BranchMath.Algebra.Groups {
    /// <summary>
    ///     An Implementation of the Dihedral group
    /// </summary>
    public class DihedralGroup : Group<int[]> {
        /// <summary>
        ///     Create a new Dihedral group
        /// </summary>
        /// <param name="order">The order of the dihedral group</param>
        /// <exception cref="InvalidGroupException">If the order is not even or not positive</exception>
        public DihedralGroup(int order) {
            if (order % 2 != 0 || order <= 0) throw new InvalidGroupException("No Dihedral group of odd order");

            Elements = new ExplicitSet<AlgebraicElement<int[]>>();
            Parallel.For(0, order / 2, i => {
                ((ExplicitSet<AlgebraicElement<int[]>>) Elements).Elements.Add(new AlgebraicElement<int[]>(new[] {0, i}));
                ((ExplicitSet<AlgebraicElement<int[]>>) Elements).Elements.Add(new AlgebraicElement<int[]>(new[] {1, i}));
            });
        }

        public override AlgebraicElement<int[]> MultiplyElements(AlgebraicElement<int[]> g, AlgebraicElement<int[]> h) {
            try {
                var ideng = g.Identifier;
                var idenh = h.Identifier;
                if (ideng[0] % 2 == 0 && idenh[0] % 2 == 0)
                    return new AlgebraicElement<int[]>(new[] {0, (ideng[1] + idenh[1]) % (order() / 2)});

                if (ideng[0] % 2 == 1 && idenh[0] % 2 == 0)
                    return new AlgebraicElement<int[]>(new[] {1, (ideng[1] + idenh[1]) % (order() / 2)});

                if (ideng[0] % 2 == 0 && idenh[0] % 2 == 1)
                    return new AlgebraicElement<int[]>(new[] {1, (order() / 2 - ideng[1] + idenh[1]) % (order() / 2)});

                if (ideng[0] % 2 == 1 && idenh[0] % 2 == 1)
                    return new AlgebraicElement<int[]>(new[] {0, (order() / 2 - ideng[1] + idenh[1]) % (order() / 2)});
            }
            catch {
                throw new InvalidElementException("Element not in group");
            }

            throw new InvalidElementException("Element not in group");
        }

        public override AlgebraicElement<int[]> GetInverse(AlgebraicElement<int[]> g) {
            return g.Identifier[0] == 0
                ? new AlgebraicElement<int[]>(new[] {0, order() / 2 - g.Identifier[1] % (order() / 2)})
                : g;
        }

        public override string DisplayElement(AlgebraicElement<int[]> g) {
            var iden = g.Identifier;
            var str = "";
            if (iden[0] == 0 && iden[1] == 0) return "e";

            if (iden[0] == 1) str += "s";

            if (iden[1] == 0) return str;
            if (iden[1] == 1) return str + "r";

            return str + "r^{" + iden[1] + "}";
        }
    }
}