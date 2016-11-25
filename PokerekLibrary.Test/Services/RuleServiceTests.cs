using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            Assert.That(winners.First().Id, Is.EqualTo(playersWon.First().Id));
        }

        private IEnumerable WinnersFromPlayersWithTheSameActivatedRule()
        {
            yield return new TestCaseData(PlayerList1(), CardList1(), new TwoPairsRule(), Winners1());
            yield return new TestCaseData(PlayerList2(), CardList2(), new FourOfKindRule(), Winners2());
        }

        #region TestCases

        #region TestCase1 TwoPairRule

        private List<Player> Winners1()
        {
            return new List<Player> {PlayerList1()[1]};
        }

        private CardList CardList1()
        {
            return new CardList
            {
                new Card(9, Colors.KIER),
                new Card(10, Colors.PIK),
                new Card(13, Colors.PIK),
                new Card(8, Colors.TREFL),
                new Card(2, Colors.KARO)
            };
        }

        private List<Player> PlayerList1()
        {
            return new List<Player>
            {
                new Player
                {
                    Id = 1,
                    Hand = new CardList
                    {
                        new Card(9, Colors.KARO),
                        new Card(10, Colors.KIER)
                    }
                },
                new Player
                {
                    Id = 2,
                    Hand = new CardList
                    {
                        new Card(13, Colors.KARO),
                        new Card(8, Colors.KARO)
                    }
                }
            };
        }

        #endregion

        #region TestCase2 FourOfKindRule

        private List<Player> Winners2()
        {
            return new List<Player> { PlayerList2()[1] };
        }

        private CardList CardList2()
        {
            return new CardList
            {
                new Card(9, Colors.KIER),
                new Card(10, Colors.PIK),
                new Card(13, Colors.PIK),
                new Card(8, Colors.TREFL),
                new Card(2, Colors.KARO)
            };
        }

        private List<Player> PlayerList2()
        {
            return new List<Player>
            {
                new Player
                {
                    Id = 1,
                    Hand = new CardList
                    {
                        new Card(9, Colors.KARO),
                        new Card(10, Colors.KIER)
                    }
                },
                new Player
                {
                    Id = 2,
                    Hand = new CardList
                    {
                        new Card(13, Colors.KARO),
                        new Card(8, Colors.KARO)
                    }
                }
            };
        }

        #endregion

        #endregion
    }
}
