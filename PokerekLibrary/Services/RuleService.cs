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
                var winners = SelectWinnersFromPlayersWithTheSameActivatedRule(playersWithBestScore, cardsOnTable, bestActivatedRuleAmongPlayers);
                return winners;
            }

            return playersWithBestScore;
        }

        internal List<Player> SelectWinnersFromPlayersWithTheSameActivatedRule(List<Player> playersWithBestScore, CardList cardsOnTable, IRule rule)
        {
            var setOfPlayersWithOrderedHand = playersWithBestScore.Select(x => new {
                Player = x,
                OrderedHand = rule.GetCardsInStrongOrder(x.Hand + cardsOnTable)
            }).ToList();

            for (var i = 0; i < 4; i++)
            {
                var firstCards = setOfPlayersWithOrderedHand.Select(x => new
                {
                    Card = x.OrderedHand.Skip(i).First(),
                    x.Player
                }).ToList();

                var bestCard = firstCards.Max(x => x.Card.Value);
                var playersWithBestCard = firstCards.Where(x => x.Card.Value == bestCard).Select(x => x.Player).ToList();
                if (playersWithBestCard.Count == 1)
                {
                    return playersWithBestCard;
                }
            }

            return playersWithBestScore;
        }

        internal IRule GetBestActivatedRule(CardList playersHand, CardList cardsOnTable)
        {
            var rules = RulesList.Get();
            var playersSet = playersHand + cardsOnTable;
            var activatedRules = rules.Where(x => x.IsTrue(playersSet)).ToList();

            return activatedRules.OrderBy(x => x.Power).First();
        }
    }
}
