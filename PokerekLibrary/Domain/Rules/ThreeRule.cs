using System.Collections.Generic;

namespace PokerekLibrary.Domain.Rules
{
    public class ThreeRule : IRule
    {
        public bool IsTrue(List<Card> cards)
        {
            return RulePredicates.HaveDuplicates(cards, 3, 1);
        }
    }
}
