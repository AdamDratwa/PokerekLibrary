using System;
using System.Collections.Generic;
using PokerekLibrary.Domain.Extensions;

namespace PokerekLibrary.Domain
{
    public class Game
    {
        private List<Player> Players { get; set; }
        public int Stack { get; set; }
        public CardList CardsOnTable { get; set; }
        public CardList Cards { get; set; }
        public Stage Stage { get; set; }

        public Game(List<Player> players)
        {
            Players = players;
            SetUpDeck();
            GiveCardsToPlayers();
        }

        private void GiveCardsToPlayers()
        {
            var random = new Random();
            for (var i = 0; i <= 1; i++)
            {
                foreach (var player in Players)
                {
                    var index = random.Next(Cards.Count);
                    var card = Cards.Pop(index);
                    player.Hand.Add(card);
                }              
            }
        }

        private void SetUpDeck()
        {
            Cards = new CardList(52);
            for (uint i = 2; i <= 13; i++)
            {
                Cards.Add(new Card(i, Colors.KARO));
                Cards.Add(new Card(i, Colors.KIER));
                Cards.Add(new Card(i, Colors.PIK));
                Cards.Add(new Card(i, Colors.TREFL));
            }
        }

        public void RemovePlayer(Player player)
        {
            Players.Remove(player);
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
