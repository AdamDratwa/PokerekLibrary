using System.Collections.Generic;
using PokerekLibrary.Domain;

namespace PokerekLibrary.Services
{
    public class GameService : IGameService
    {
        public Game Game { get; set; }
        public List<Player> Players { get; set; }

        public GameService()
        {
            Players = new List<Player>();
        }

        public void StartNewGame()
        {
            Game = new Game(Players);
        }
    }
}
