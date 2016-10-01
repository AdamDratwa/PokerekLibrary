using System.Collections.Generic;

namespace PokerekLibrary.Domain.Rules
{
    public class ThreeOfKindRule : Rule
    {
        public override bool IsTrue(List<Card> cards)
        {
            return RulePredicates.HaveDuplicates(cards, 3, 1);
        }

        public override int Order
        {
            get { return 6; }
        }
    }
}
