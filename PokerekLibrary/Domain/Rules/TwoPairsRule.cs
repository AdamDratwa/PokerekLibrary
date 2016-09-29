using System.Collections.Generic;

namespace PokerekLibrary.Domain.Rules
{
    public class TwoPairsRule : IRule
    {
        public bool IsTrue(List<Card> cards)
        {
            return RulePredicates.HaveDuplicates(cards, 2, 2);
        }
    }
}
