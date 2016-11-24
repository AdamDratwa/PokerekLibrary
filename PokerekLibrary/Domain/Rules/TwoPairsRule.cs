using System.Collections.Generic;
using System.Linq;

namespace PokerekLibrary.Domain.Rules
{
    public class TwoPairsRule : IRule
    {
        public bool IsTrue(List<Card> cards)
        {
            return RulePredicates.HaveDuplicates(cards, 2, 2);
        }

        public int Power
        {
            get { return 7; }
        }

        public CardList GetCardsInStrongOrder(CardList playersSet)
        {
            return (CardList)playersSet.OrderByDescending(x => IsPartOfRule(x, playersSet) ? 1 : 0).ThenByDescending(x => x.Value).ToList();
        }

        private static bool IsPartOfRule(Card card, CardList playersSet)
        {
            return RulePredicates.HasDuplicates(card, playersSet, 2);
        }
    }
}
