using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using PokerekLibrary.Domain;
using PokerekLibrary.Domain.Rules;
using PokerekLibrary.Services;

namespace PokerekLibrary.Test.Services
{
    [TestFixture]
    public class RuleServiceTests
    {
        [TestCaseSource("WinnersFromPlayersWithTheSameActivatedRule")]
        public void GetHighestActivatedRuleValue_ShouldSelectHighestHand(List<Player> players, CardList cardsOnTable, IRule rule, List<Player> playersWon)
        {
            var ruleService = new RuleService();
            var winners = ruleService.SelectWinnersFromPlayersWithTheSameActivatedRule(players, cardsOnTable, rule);
            Assert.That(winners.Count, Is.EqualTo(1));
        }

        private IEnumerable WinnersFromPlayersWithTheSameActivatedRule()
        {
            yield return new TestCaseData();
        }
    }
}
