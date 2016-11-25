using System.Collections.Generic;
using System.Linq;

namespace PokerekLibrary.Domain.Rules
{
    public class TwoPairsRule : Rule
    {
        public override bool IsTrue(List<Card> cards)
        {
            return RulePredicates.HaveDuplicates(cards, 2, 2);
        }

        public override int Power
        {
            get { return 7; }
        }

        public override bool IsPartOfRule(Card card, CardList playersSet)
        {
            return RulePredicates.HasDuplicates(card, playersSet, 2);
        }
    }
}
