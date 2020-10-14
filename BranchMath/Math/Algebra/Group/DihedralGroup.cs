using System.Numerics;
using BranchMath.Math.Logic;
using BranchMath.Math.Set;

namespace BranchMath.Math.Algebra.Group {
    /// <summary>
    ///     An Implementation of the Dihedral group
    /// </summary>
    public class DihedralGroup : FiniteGroup<BigInteger[]> {
        /// <summary>
        ///     Create a new Dihedral group
        /// </summary>
        /// <param name="order">The order of the dihedral group</param>
        /// <exception cref="InvalidGroupException">If the order is not even or not positive</exception>
        public DihedralGroup(BigInteger order) {
            if (order % 2 != 0 || order <= 0) throw new InvalidGroupException("No Dihedral group of odd order");

            Elements = new ExplicitSet<GroupElement<BigInteger[]>>();
            for (BigInteger i = 0; i < order / 2; ++i) {
                Elements.Elements.Add(new GroupElement<BigInteger[]>(new[] {0, i}, this));
                Elements.Elements.Add(new GroupElement<BigInteger[]>(new[] {1, i}, this));
            }
        }

        public override GroupElement<BigInteger[]> MultiplyElements(GroupElement<BigInteger[]> g,
            GroupElement<BigInteger[]> h) {
            try {
                var ideng = g.Identifier;
                var idenh = h.Identifier;
                var ord = ((BigInteger?) order().evaluate()).Value;
                if (ideng[0] % 2 == 0 && idenh[0] % 2 == 0)
                    return new GroupElement<BigInteger[]>(new[] {0, (ideng[1] + idenh[1]) % (ord / 2)}, this);

                if (ideng[0] % 2 == 1 && idenh[0] % 2 == 0)
                    return new GroupElement<BigInteger[]>(new[] {1, (ideng[1] + idenh[1]) % (ord / 2)}, this);

                if (ideng[0] % 2 == 0 && idenh[0] % 2 == 1)
                    return new GroupElement<BigInteger[]>(new[] {1, (ord / 2 - ideng[1] + idenh[1]) % (ord / 2)}, this);

                if (ideng[0] % 2 == 1 && idenh[0] % 2 == 1)
                    return new GroupElement<BigInteger[]>(new[] {0, (ord / 2 - ideng[1] + idenh[1]) % (ord / 2)}, this);
            }
            catch {
                throw new InvalidElementException("Element not in group");
            }

            throw new InvalidElementException("Element not in group");
        }

        public override GroupElement<BigInteger[]> GetInverse(GroupElement<BigInteger[]> g) {
            var ord = ((BigInteger?) order().evaluate()).Value;
            return g.Identifier[0] == 0
                ? new GroupElement<BigInteger[]>(new[] {0, ord / 2 - g.Identifier[1] % (ord / 2)}, this)
                : g;
        }

        public override GroupElement<BigInteger[]> GetIdentity() {
            return new GroupElement<BigInteger[]>(new BigInteger[] {0, 0}, this);
        }

        public override string DisplayElement(AlgebraicElement<BigInteger[]> g) {
            var iden = g.Identifier;
            var str = "";
            if (iden[0] == 0 && iden[1] == 0) return "e";

            if (iden[0] == 1) str += "s";

            if (iden[1] == 0) return str;
            if (iden[1] == 1) return str + "r";

            return str + "r^{" + iden[1] + "}";
        }

        public override string ToLaTeX() {
            return "D" + order().ToLaTeX();
        }

        public override Boolean compare(AlgebraicElement<BigInteger[]> g, AlgebraicElement<BigInteger[]> h) {
            return g.Identifier[0] == h.Identifier[0] && g.Identifier[1] == h.Identifier[1];
        }
    }
}