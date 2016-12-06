using System.Collections.Generic;
using System.Linq;
using PokerekLibrary.Domain;

namespace PokerekLibrary.Services
{
    public class GameService : IGameService
    {
        private readonly IRulesService _rulesService;
        
        public Game Game { get; set; }
        public List<Player> Players { get; set; }

        public GameService(IRulesService rulesService)
        {
            _rulesService = rulesService;
            Players = GetPlayers();
        }

        private List<Player> GetPlayers()
        {
            return new List<Player>
            {
                new Player(this)
            };
        }

        public void StartNewGame()
        {
            Game = new Game(Players);
        }

        public void NextRound()
        {
            switch (Game.Stage)
            {
                case Stage.FLOP:
                    Game.PutCards(3);
                    Game.Stage = Stage.RIVER;
                    break;
                case Stage.TURN:
                    Game.PutCards(1);
                    Game.Stage = Stage.RIVER;
                    break;
                case Stage.RIVER:
                    Game.PutCards(1);
                    break;
            }
        }

        public void NextPlayer()
        {
            
        }

        public void RemovePlayer()
        {
            
        }

        public void HandOutStack()
        {
           var winners = _rulesService.GetWinners(Players, Game.CardsOnTable);
           var price = Game.Stack/winners.Count;
           winners.ForEach(x=> x.Chips += price);
        }

        public int GetCurrentStack()
        {
            return Game.Stack;
        }
    }
}
