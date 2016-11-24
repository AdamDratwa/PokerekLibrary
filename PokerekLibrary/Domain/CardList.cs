using System.Collections.Generic;

namespace PokerekLibrary.Domain
{
    public class CardList : List<Card>
    {
        public CardList(){}
        public CardList(int size) : base(size){}

        public static CardList operator +(CardList playersCard, CardList cardsOnTable)
        {
            playersCard.AddRange(cardsOnTable);
            return playersCard;
        }
    }
}
