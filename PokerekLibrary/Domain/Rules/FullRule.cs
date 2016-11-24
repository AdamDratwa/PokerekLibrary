using System.Collections.Generic;

namespace PokerekLibrary.Domain.Rules
{
    public class FullRule : IRule
    {
        public bool IsTrue(List<Card> cards)
        {
            return RulePredicates.HaveDuplicates(cards, 2, 2) && RulePredicates.HaveDuplicates(cards, 3, 1);
        }

        public int Power
        {
            get { return 3; }
        }

        public CardList GetCardsInStrongOrder(CardList playersSet)
        {
            throw new System.NotImplementedException();
        }
    }
}
