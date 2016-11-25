using System.Collections.Generic;
using System.Linq;

namespace PokerekLibrary.Domain.Rules
{
    public class FlushRule : Rule
    {
        public override bool IsTrue(List<Card> cards)
        {
            cards = cards.OrderBy(x => x.Color == Colors.KARO).ToList();
            return RulePredicates.CardsInColor(cards);
        }

        public override int Power
        {
            get { return 4; }
        }

        public override bool IsPartOfRule(Card card, CardList playersSet)
        {
            return true;
        }
    }
}
