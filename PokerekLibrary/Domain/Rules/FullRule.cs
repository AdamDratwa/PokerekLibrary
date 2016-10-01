using System.Collections.Generic;

namespace PokerekLibrary.Domain.Rules
{
    public class FullRule : IRule
    {
        public bool IsTrue(List<Card> cards)
        {
            return RulePredicates.HaveDuplicates(cards, 2, 1);
        }

        public int Order
        {
            get { return 3; }
        }
    }
}
