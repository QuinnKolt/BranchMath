using System.Linq;
using BranchMath.Math.Logic;
using BranchMath.Math.Set;
using BranchMath.Math.Value;

namespace BranchMath.Math.Computing.FormalLanguage.Regular {
    public class DFA<Q, C> : Automaton<Q, C> where Q : ValueType where C : ValueType {
        public DFA(Set<Q> states, Set<C> alphabet, BiFunction<Q, C, Q> transition, Q start, Set<Q> accept) {
            States = states;
            Alphabet = alphabet;
            Transition = transition;
            Start = start;
            Accept = accept;
        }

        public Set<Q> States { get; }
        public Set<C> Alphabet { get; }
        public BiFunction<Q, C, Q> Transition { get; }
        public Q Start { get; }
        public Set<Q> Accept { get; }

        public Boolean contains(C[] str) {
            var state = str.Aggregate(Start, (current, c) => Transition.evaluate(current, c));

            return Accept.IsElement(state);
        }

        public string ToLaTeX() {
            return
                $"({States.ToLaTeX()}, {Alphabet.ToLaTeX()}, {Transition.ToLaTeX()}, " +
                $"{Start.ToLaTeX()}, {Accept.ToLaTeX()})";
        }

        public string ClassLaTeX() {
            return @"\mathrm{DFA}";
        }
    }
}