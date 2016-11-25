using System.Collections.Generic;
using System.Linq;

namespace PokerekLibrary.Domain.Rules
{
    public abstract class Rule : IRule
    {
        public abstract bool IsTrue(List<Card> cards);

        public abstract int Power { get; }

        public abstract bool IsPartOfRule(Card card, CardList playersSet);

        public List<Card> GetCardsInStrongOrder(CardList playersSet)
        {
            return playersSet.OrderByDescending(x => IsPartOfRule(x, playersSet) ? 1 : 0).ThenByDescending(x => x.Value).ToList();
        }
    }
}
