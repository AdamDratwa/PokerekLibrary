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
            Players = new List<Player>();
        }

        public void StartNewGame()
        {
            Game = new Game(Players);
        }

        public void RemovePlayer(Player player)
        {
            Players.Remove(player);
        }

        public Player GetWinner()
        {
            var result = Players.Select(x => new {
               Player = x,
               Value = _rulesService.GetHighestActivatedRuleValue(x.Hand, Game.CardsOnTable)
            }).ToList();
            var bestScore = result.Min(x => x.Value);
            var playersWithBestScore = result.Where(x => x.Value == bestScore).Select(x => x.Player).ToList();
            if (playersWithBestScore.Count() > 1)
            {
                
            }
            return playersWithBestScore.FirstOrDefault();
        }
    }
}
