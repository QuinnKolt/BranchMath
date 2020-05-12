﻿using System;
using BranchMath.Value;

namespace BranchMath.Algebra.Groups {
    /// <summary>
    ///     Represents a group homomorphism between two groups
    /// </summary>
    /// <typeparam name="I">The identifier type of the domain group</typeparam>
    /// <typeparam name="J">The identifier type of the codomain group</typeparam>
    public abstract class Homomorphism<I, J> : Mapping<AlgebraicElement<I>, AlgebraicElement<J>> {
        public abstract Group<I> GetKernel();

        public abstract AlgebraicElement<J> evaluate(AlgebraicElement<I> el);
    }
}