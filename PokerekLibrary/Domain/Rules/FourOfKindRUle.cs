using System.Collections.Generic;

namespace PokerekLibrary.Domain.Rules
{
    public class FourOfKindRule : IRule
    {
        public bool IsTrue(List<Card> cards)
        {
            return RulePredicates.HaveDuplicates(cards, 4, 1);
        }

        public int Power
        {
            get { return 2; }
        }

        public List<Card> GetCardsInStrongOrder(CardList playersSet)
        {
            throw new System.NotImplementedException();
        }
    }
}
