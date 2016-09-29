using System.Collections.Generic;
using System.Linq;

namespace PokerekLibrary.Domain.Rules
{

    public class PokerRule : Rule
    {
        public override bool IsTrue(List<Card> cards)
        {
            cards = cards.OrderBy(x => x.Value).ToList();
            var isTrue = CheckRule(cards);
            if (!isTrue && cards.Any(x => x.Value == (int)Figures.AS))
            {
                var ases = cards.Where(x => x.Value == (int) Figures.AS).ToList();
                ases.ForEach(x => x.Value = 1);
                cards = cards.OrderBy(x => x.Value).ToList();
                isTrue = CheckRule(cards);
            }
            return isTrue;
        }

        private static bool CheckRule(List<Card> cards)
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

        public override int Order
        {
            get { return 1; }
        }
    }
}
