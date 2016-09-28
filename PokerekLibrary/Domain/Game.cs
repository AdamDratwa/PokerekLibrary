using System;
using System.Collections.Generic;
using System.Linq;
using PokerekLibrary.Domain.Extensions;

namespace PokerekLibrary.Domain
{
    public class Game
    {
        private readonly List<Player> _players;
        public int Stack { get; set; }
        public List<Card> CardsOnTable { get; set; }
        public List<Card> Cards { get; set; }

        public Game(List<Player> players)
        {
            _players = players;
            GetDeck();
        }

        private void GetDeck()
        {
            for (var i = 2; i <= 13; i++)
            {
                Cards.Add(new Card(i, Colors.KARO));
                Cards.Add(new Card(i, Colors.KIER));
                Cards.Add(new Card(i, Colors.PIK));
                Cards.Add(new Card(i, Colors.TREFL));
            }
        }

        public void RemovePlayer(Player player)
        {
            _players.Remove(player);
        }

        public void PutCards(int cardsCount)
        {
            var random = new Random();
            for (int i = 1; i <= cardsCount; i++)
            {
                var index = random.Next(Cards.Count);
                var card = Cards.Pop(index);
                CardsOnTable.Add(card);
            }
        }
    }
}
