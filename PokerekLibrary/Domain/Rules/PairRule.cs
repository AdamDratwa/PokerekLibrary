using System.Collections.Generic;

namespace PokerekLibrary.Domain.Rules
{
    public class PairRule : IRule
    {
        public bool IsTrue(List<Card> cards)
        {
            return RulePredicates.HaveDuplicates(cards, 2, 1);
        }    
    }
}
