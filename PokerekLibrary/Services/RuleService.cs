using System.Collections.Generic;
using System.Linq;
using PokerekLibrary.Domain;
using PokerekLibrary.Domain.Dictionaries;

namespace PokerekLibrary.Services
{
    public class RuleService : IRulesService
    {
        public List<Player> GetWinners(List<Player> players, CardList cardsOnTable)
        {
            var playersWithHighScore = GetPlayersWithHighScore(players, cardsOnTable);        
            if (playersWithHighScore.Count > 1)
            {
                var winners = SelectWinnersFromPlayersWithTheSameHand(playersWithHighScore, cardsOnTable);
                return winners;
            }

            return playersWithHighScore;
        }

        private List<Player> GetPlayersWithHighScore(List<Player> players, CardList cardsOnTable)
        {
            var results = players.Select(x => new
            {
                Player = x,
                Value = GetHighestActivatedRuleValue(x.Hand, cardsOnTable)
            }).ToList();
            var bestScore = results.Min(x => x.Value);
            var playersWithBestScore = results.Where(x => x.Value == bestScore).Select(x => x.Player).ToList();

            return playersWithBestScore;
        }

        internal List<Player> SelectWinnersFromPlayersWithTheSameHand(List<Player> playersWithBestScore, CardList cardsOnTable)
        {
            throw new System.NotImplementedException();
        }

        internal int GetHighestActivatedRuleValue(CardList playersHand, CardList cardsOnTable)
        {
            var rules = RulesList.Get();
            var playersSet = playersHand + cardsOnTable;
            var activatedRules = rules.Where(x => x.IsTrue(playersSet)).Select(x => x.Power);

            return activatedRules.Min();
        }
    }
}
