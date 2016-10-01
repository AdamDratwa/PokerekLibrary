using System.Collections.Generic;

namespace PokerekLibrary.Domain.Rules
{
    public class FullRule : Rule
    {
        public override bool IsTrue(List<Card> cards)
        {
            return RulePredicates.HaveDuplicates(cards, 2, 1);
        }

        public override int Order
        {
            get { return 3; }
        }
    }
}
