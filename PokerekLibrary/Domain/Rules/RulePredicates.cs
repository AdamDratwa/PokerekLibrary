using System.Collections.Generic;
using System.Linq;
using PokerekLibrary.Domain.Extensions;

namespace PokerekLibrary.Domain.Rules
{
    public static class RulePredicates
    {
        public static bool CardsInOrder(List<Card> cards)
        {
            var cardsInOrder = 0;
            cards = cards.OrderBy(x => x.Value).ToList();
            for (var i = 0; i <= cards.Count - 2; i++)
            {
                if (cards[i + 1].Value - cards[i].Value == 1)
                {
                    if (i == 0)
                    {
                        cardsInOrder += 2;
                    }
                    else
                    {
                        cardsInOrder += 1;
                    }
                }
            }
            return cardsInOrder >= 5;
        }

        public static bool CardsInColor(List<Card> cards)
        {
            var cardDuplicatesInColor = cards.GroupBy(x => x.Color,(key, g) => new
            {
                SameColor = g.Count()
            });
            return cardDuplicatesInColor.Any(x => x.SameColor >= 5);
        }

        public static bool HaveDuplicates(List<Card> cards, int numberOfCards, int numberOfGroups)
        {
            var groupedByValue = cards.GroupBy(x => x.Value, (key, g) => new
            {
                Value = key,
                Pair = g.Count()
            });
            return groupedByValue.Count(x => x.Pair >= numberOfCards) >= numberOfGroups;
        }

        public static bool HasDuplicates(Card card, CardList cardList, int numberOfCards)
        {
            return cardList.Count(x => x.Value == card.Value) == numberOfCards;
        }
    }
}
