using System.Collections.Generic;

namespace PokerekLibrary.Domain.Rules
{
    public class PokerRule : IRule
    {
        public bool IsTrue(List<Card> cards)
        {
            for (int i = 0; i < cards.Count - 1; i++)
            {
                if (!(RulePredicates.CardsInOrder(cards, i) && (RulePredicates.CardsInColor(cards, i))))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
