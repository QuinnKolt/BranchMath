﻿using System.Numerics;
using System.Threading.Tasks;
using BranchMath.Tree;

namespace BranchMath.Algebra.Groups {
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

            Elements = new ExplicitSet<AlgebraicElement<BigInteger[]>>();
            for (BigInteger i = 0; i < order / 2; ++i) {
                ((ExplicitSet<AlgebraicElement<BigInteger[]>>) Elements).Elements.Add(new AlgebraicElement<BigInteger[]>(new[] {0, i}));
                ((ExplicitSet<AlgebraicElement<BigInteger[]>>) Elements).Elements.Add(new AlgebraicElement<BigInteger[]>(new[] {1, i}));
            }
        }

        public override AlgebraicElement<BigInteger[]> MultiplyElements(AlgebraicElement<BigInteger[]> g, AlgebraicElement<BigInteger[]> h) {
            try {
                var ideng = g.Identifier;
                var idenh = h.Identifier;
                var ord = order().evaluate().Value;
                if (ideng[0] % 2 == 0 && idenh[0] % 2 == 0)
                    return new AlgebraicElement<BigInteger[]>(new[] {0, (ideng[1] + idenh[1]) % (ord / 2)});

                if (ideng[0] % 2 == 1 && idenh[0] % 2 == 0)
                    return new AlgebraicElement<BigInteger[]>(new[] {1, (ideng[1] + idenh[1]) % (ord / 2)});

                if (ideng[0] % 2 == 0 && idenh[0] % 2 == 1)
                    return new AlgebraicElement<BigInteger[]>(new[] {1, (ord / 2 - ideng[1] + idenh[1]) % (ord / 2)});

                if (ideng[0] % 2 == 1 && idenh[0] % 2 == 1)
                    return new AlgebraicElement<BigInteger[]>(new[] {0, (ord / 2 - ideng[1] + idenh[1]) % (ord / 2)});
            }
            catch {
                throw new InvalidElementException("Element not in group");
            }

            throw new InvalidElementException("Element not in group");
        }

        public override AlgebraicElement<BigInteger[]> GetInverse(AlgebraicElement<BigInteger[]> g) {
            var ord = order().evaluate().Value;
            return g.Identifier[0] == 0
                ? new AlgebraicElement<BigInteger[]>(new[] {0, ord / 2 - g.Identifier[1] % (ord / 2)})
                : g;
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

        public override string ToString() {
            return "D" + order();
        }
    }
}