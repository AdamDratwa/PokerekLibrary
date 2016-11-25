using System.Collections.Generic;

namespace PokerekLibrary.Domain.Rules
{
    public class FullRule : Rule
    {
        public override bool IsTrue(List<Card> cards)
        {
            return RulePredicates.HaveDuplicates(cards, 2, 2) && RulePredicates.HaveDuplicates(cards, 3, 1);
        }

        public override int Power
        {
            get { return 3; }
        }

        public override bool IsPartOfRule(Card card, CardList playersSet)
        {
            return RulePredicates.HasDuplicates(card, playersSet, 2) ||
                   RulePredicates.HasDuplicates(card, playersSet, 3);
        }
    }
}
