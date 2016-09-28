using System.Collections.Generic;
using System.Linq;

namespace PokerekLibrary.Domain
{
    public class Game
    {
        public List<Player> PlayersInGame { get; set; }
        public int Stack { get; set; }
        public List<Card> CardsOnTable { get; set; }
        public List<Card> Cards { get; set; }

        public Game(List<Player> players)
	    {
            PlayersInGame = players;
	    }

        public void PutCards(int cardsCount)
        {
            var cardsToPut = Cards.Take(cardsCount);
            CardsOnTable.AddRange(cardsToPut);
        }
    }
}
