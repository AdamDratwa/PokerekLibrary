using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using PokerekLibrary.Domain;

namespace PokerekLibrary.Test
{
    [TestFixture]
    public class GameTests
    {
        [Test]
        public void Game_ShouldGiveCardsToPlayers()
        {
            var players = new List<Player>
            {
                new Player
                {
                    Id = 1,
                    Chips = 500
                },
                new Player
                {
                    Id = 2,
                    Chips = 600
                }
            };

            var game = new Game(players);
            Assert.That(players.All(x => x.Hand.Count > 0));
            Assert.That(game.Cards.Count, Is.EqualTo(52 - players.Count * 2));
        }
    }
}
