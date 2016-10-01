using System.Collections.Generic;

namespace PokerekLibrary.Domain.Rules
{
    public class FlushRule : IRule
    {
        public bool IsTrue(List<Card> cards)
        {
            for (int i = 0; i < cards.Count - 1; i++)
            {
                if (!(RulePredicates.CardsInColor(cards, i)))
                {
                    return false;
                }
            }
            return true;
        }

        public int Order
        {
            get { return 4; }
        }
    }
}
