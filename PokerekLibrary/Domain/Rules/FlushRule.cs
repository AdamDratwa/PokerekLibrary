using System.Collections.Generic;
using System.Linq;

namespace PokerekLibrary.Domain.Rules
{
    public class FlushRule : IRule
    {
        public bool IsTrue(List<Card> cards)
        {
            cards = cards.OrderBy(x => x.Color == Colors.KARO).ToList();
            for (int i = 0; i < cards.Count - 1; i++)
            {
                if (!(RulePredicates.CardsInColor(cards)))
                {
                    return false;
                }
            }
            return true;
        }

        public int Order
        {
            get { return 4; }
        }
    }
}
