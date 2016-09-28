using System.Collections.Generic;

namespace PokerekLibrary.Domain.Rules
{
    public static class RulePredicates
    {
        public static bool CardsInOrder(List<Card> cards, int i)
        {
            return cards[i + 1].Value - cards[i].Value == 1;
        }

        public static bool CardsInColor(List<Card> cards, int i)
        {
            return cards[i + 1].Color == cards[i].Color;
        }
    }
}
