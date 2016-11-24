using System.Collections.Generic;
using System.Linq;
using PokerekLibrary.Domain;
using PokerekLibrary.Domain.Dictionaries;
using PokerekLibrary.Domain.Rules;

namespace PokerekLibrary.Services
{
    public class RuleService : IRulesService
    {
        public List<Player> GetWinners(List<Player> players, CardList cardsOnTable)
        {
            var activatedRules = players.Select(x => new
            {
                Player = x,
                BestRule = GetBestActivatedRule(x.Hand, cardsOnTable)
            }).ToList();

            var bestActivatedRuleAmongPlayers = activatedRules.Min(x => x.BestRule);
            var playersWithBestScore = activatedRules.Where(x => x.BestRule == bestActivatedRuleAmongPlayers).Select(x => x.Player).ToList();
            if (playersWithBestScore.Count > 1)
            {
                var winners = SelectWinnersFromPlayersWithTheSameHand(playersWithBestScore, cardsOnTable, bestActivatedRuleAmongPlayers);
                return winners;
            }

            return playersWithBestScore;
        }

        internal List<Player> SelectWinnersFromPlayersWithTheSameHand(List<Player> playersWithBestScore, CardList cardsOnTable, IRule rule)
        {
            var listOfOrderedCards = playersWithBestScore.Select(x => rule.GetCardsInStrongOrder(x.Hand + cardsOnTable)).ToList();
            for (int i = 0; i < 6; i++)
            {
                var cards = listOfOrderedCards.Select(x => x.Skip(i).Take(1));
            }
        }

        internal IRule GetBestActivatedRule(CardList playersHand, CardList cardsOnTable)
        {
            var rules = RulesList.Get();
            var playersSet = playersHand + cardsOnTable;
            var activatedRules = rules.Where(x => x.IsTrue(playersSet)).ToList();

            return activatedRules.OrderByDescending(x => x.Power).First();
        }
    }
}
