using System.Collections.Generic;
using System.Linq;

namespace PokerekLibrary.Domain.Rules
{
    public class FlushRule : IRule
    {
        public bool IsTrue(List<Card> cards)
        {
            cards = cards.OrderBy(x => x.Color == Colors.KARO).ToList();
            return RulePredicates.CardsInColor(cards);
        }

        public int Power
        {
            get { return 4; }
        }
    }
}
