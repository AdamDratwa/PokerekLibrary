using System.Collections.Generic;

namespace PokerekLibrary.Domain.Rules
{
    public class PairRule : IRule
    {
        public bool IsTrue(List<Card> cards)
        {
            return RulePredicates.HaveDuplicates(cards, 2, 1);
        }

        public int Power
        {
            get { return 8; }
        }

        public CardList GetCardsInStrongOrder(CardList playersSet)
        {
            throw new System.NotImplementedException();
        }
    }
}
