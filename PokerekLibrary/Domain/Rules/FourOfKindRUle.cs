using System.Collections.Generic;

namespace PokerekLibrary.Domain.Rules
{
    public class FourOfKindRule : Rule
    {
        public override bool IsTrue(List<Card> cards)
        {
            return RulePredicates.HaveDuplicates(cards, 4, 1);
        }

        public override int Power
        {
            get { return 2; }
        }

        public override bool IsPartOfRule(Card card, CardList playersSet)
        {
            return RulePredicates.HasDuplicates(card, playersSet, 4);
        }
    }
}
