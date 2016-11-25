using System.Collections.Generic;
using System.Linq;

namespace PokerekLibrary.Domain.Rules
{
    public class FourOfKindRule : IRule
    {
        public bool IsTrue(List<Card> cards)
        {
            return RulePredicates.HaveDuplicates(cards, 4, 1);
        }

        public int Power
        {
            get { return 2; }
        }

        public List<Card> GetCardsInStrongOrder(CardList playersSet)
        {
            return playersSet.OrderByDescending(x => IsPartOfRule(x, playersSet) ? 1 : 0).ThenByDescending(x => x.Value).ToList();
        }

        private bool IsPartOfRule(Card card, CardList playersSet)
        {
            return RulePredicates.HasDuplicates(card, playersSet, 4);
        }
    }
}
