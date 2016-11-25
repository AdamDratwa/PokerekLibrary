using System.Collections.Generic;

namespace PokerekLibrary.Domain.Rules
{
    public class ThreeOfKindRule : Rule
    {
        public override bool IsTrue(List<Card> cards)
        {
            return RulePredicates.HaveDuplicates(cards, 3, 1);
        }

        public override int Power
        {
            get { return 6; }
        }

        public override bool IsPartOfRule(Card card, CardList playersSet)
        {
            return RulePredicates.HasDuplicates(card, playersSet, 3);
        }
    }
}
