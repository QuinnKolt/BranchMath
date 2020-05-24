using System;
using BranchMath.Algebra.Group;

namespace BranchMath.Algebra.Ring {
    public abstract class Ring<I> : AlgebraicStructure<I> {
        public abstract string DisplayElement(AlgebraicElement<I> g);
        public abstract string ToLaTeX();
        
        public readonly Group<I> additive_group;

        public Ring() {
            additive_group = getAdditiveGroup();
        }

        public virtual string ClassLaTeX() {
            return "\\mathrm{Ring}";
        }

        /// <summary>
        ///     Find the product of two elements in the group.
        /// </summary>
        /// <param name="g">The first element to multiply.</param>
        /// <param name="h">The second element to multiply.</param>
        /// <returns>The element gh.</returns>
        public abstract RingElement<I> MultiplyElements(RingElement<I> g, RingElement<I> h);

        /// <summary>
        ///     Find the sum of two elements in the group.
        /// </summary>
        /// <param name="g">The first element to add.</param>
        /// <param name="h">The second element to add.</param>
        /// <returns>The element g+h.</returns>
        public abstract RingElement<I> AddElements(RingElement<I> g, RingElement<I> h);

        /// <summary>
        ///     Find the additive inverse of the given element in the ring.
        /// </summary>
        /// <param name="g">The element to find the inverse of</param>
        /// <returns>The element -g</returns>
        public abstract RingElement<I> GetAdditiveInverse(RingElement<I> g);

        /// <summary>
        ///     Find the multiplicative inverse of the given element in the ring.
        /// </summary>
        /// <param name="g">The element to find the inverse of</param>
        /// <returns>The element g^-1</returns>
        /// <exception> If element has no inverse </exception>
        public abstract RingElement<I> GetMultiplicativeInverse(RingElement<I> g);

        /// <summary>
        ///     Find the multiplicative identity.
        /// </summary>
        /// <returns>The multiplicative unit of the ring</returns>
        public abstract RingElement<I> getOne();

        /// <summary>
        ///     Find the additive identity.
        /// </summary>
        /// <returns>The multiplicative absorbing element of the ring</returns>
        public abstract RingElement<I> getZero();
        
        public virtual bool compare(AlgebraicElement<I> g, AlgebraicElement<I> h) {
            return g.evaluate().Equals(h.evaluate());
        }

        /// <summary>
        /// Gets the additive group corresponding to this ring
        /// </summary>
        /// <returns>The abelian group under addition corresponding to this ring</returns>
        private AdditiveGroup getAdditiveGroup() => new AdditiveGroup(this);

        private class AdditiveGroup : Group<I> {
            Ring<I> ring;
            internal AdditiveGroup(Ring<I> ring) {
                this.ring = ring;
            }
            
            public override string DisplayElement(AlgebraicElement<I> g) {
                return ring.DisplayElement(g);
            }

            public override string ToLaTeX() {
                return ring.ToLaTeX();
            }

            public override GroupElement<I> MultiplyElements(GroupElement<I> g, GroupElement<I> h) {
                var r = ring.AddElements(new RingElement<I>(g.Identifier, ring), new RingElement<I>(h.Identifier, ring));
                return new GroupElement<I>(r.Identifier, this);
            }

            public override GroupElement<I> GetInverse(GroupElement<I> g) {
                var r = ring.GetAdditiveInverse(new RingElement<I>(g.Identifier, ring));
                return new GroupElement<I>(r.Identifier, this);
            }

            public override GroupElement<I> GetIdentity() {
                return new GroupElement<I>(ring.getZero().Identifier, this);
            }
        }
    }
}