using System.Collections.Generic;

namespace PokerekLibrary.Domain.Rules
{
    public class ThreeOfKindRule : IRule
    {
        public bool IsTrue(List<Card> cards)
        {
            return RulePredicates.HaveDuplicates(cards, 3, 1);
        }

        public int Order
        {
            get { return 6; }
        }
    }
}
