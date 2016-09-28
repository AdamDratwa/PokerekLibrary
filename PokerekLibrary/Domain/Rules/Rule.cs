using System.Collections.Generic;

namespace PokerekLibrary.Domain.Rules
{
    public abstract class Rule : IRule
    {
        public abstract bool IsTrue(List<Card> cards);
        public abstract int Order { get; }
    }
}
