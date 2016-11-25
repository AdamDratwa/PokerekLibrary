using System.Collections.Generic;

namespace PokerekLibrary.Domain.Rules
{
    public interface IRule
    {
        bool IsTrue(List<Card> cards);
        int Power { get; }
        List<Card> GetCardsInStrongOrder(CardList playersSet);
    }
}
