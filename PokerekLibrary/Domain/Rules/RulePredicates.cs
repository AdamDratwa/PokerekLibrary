using System.Collections.Generic;
using System.Linq;

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

        public static bool HaveDuplicates(List<Card> cards, int numberOfCards, int numberOfGroups)
        {
            var groupedByValue = cards.GroupBy(x => x.Value, (key, g) => new
            {
                Value = key,
                Pair = g.Count()
            });
            return groupedByValue.Count(x => x.Pair >= numberOfCards) == numberOfCards;
        }
    }
}
