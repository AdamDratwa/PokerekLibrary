using System.Collections.Generic;
using System.Linq;
using PokerekLibrary.Domain;
using PokerekLibrary.Domain.Dictionaries;

namespace PokerekLibrary.Services
{
    public class RuleService : IRulesService
    {
        public List<Player> GetWinners(List<Player> players, List<Card> cardsOnTable)
        {
            var result = players.Select(x => new
            {
                Player = x,
                Value = GetHighestActivatedRuleValue(x.Hand, cardsOnTable)
            }).ToList();
            var bestScore = result.Min(x => x.Value);
            var playersWithBestScore = result.Where(x => x.Value == bestScore).Select(x => x.Player).ToList();
            if (playersWithBestScore.Count() > 1)
            {
                var winners = SelectWinnersFromPlayersWithTheSameHand(playersWithBestScore, cardsOnTable);
                return winners;
            }
            return playersWithBestScore;
        }

        internal List<Player> SelectWinnersFromPlayersWithTheSameHand(List<Player> playersWithBestScore, List<Card> cardsOnTable)
        {
            throw new System.NotImplementedException();
        }

        internal int GetHighestActivatedRuleValue(List<Card> playerHand, List<Card> cardsOnTable)
        {
            var rules = RulesList.Get();
            playerHand.AddRange(cardsOnTable);
            var activatedRules = rules.Where(x => x.IsTrue(playerHand)).Select(x => x.Order);
            return activatedRules.Min();
        }
    }
}
