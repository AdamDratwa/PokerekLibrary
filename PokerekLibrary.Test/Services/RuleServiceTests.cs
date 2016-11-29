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

        [TestCaseSource("ActivatedRulesTestCases")]
        public void GetBestActivatedRule_ShouldGetBestRule(CardList playersSet, CardList cardsOnTable, IRule rule)
        {
            var ruleService = new RuleService();
            var bestActivatedRule = ruleService.GetBestActivatedRule(playersSet, cardsOnTable);
            if (rule == null)
            {
                Assert.Null(bestActivatedRule);
            }
            else
            {
                Assert.That(bestActivatedRule.GetType(), Is.EqualTo(rule.GetType()));
            }
        }

        [TestCaseSource("GetWinnersTestCases")]
        public void GetWinners_ShouldGetWinners(List<Player> players, CardList cardsOnTable, IEnumerable<Player> winners)
        {
            var ruleService = new RuleService();
            var bestPlayers = ruleService.GetWinners(players, cardsOnTable);
            Assert.That(bestPlayers.First().Id, Is.EqualTo(winners.First().Id));
        }

        private IEnumerable GetWinnersTestCases()
        {
            yield return new TestCaseData(Players1(), OnTable1(), Winner1());
            yield return new TestCaseData(Players2(), OnTable2(), Winner2());
            yield return new TestCaseData(Players3(), OnTable3(), Winner3());
            yield return new TestCaseData(Players4(), OnTable4(), Winner4());
            yield return new TestCaseData(Players5(), OnTable5(), Winner5());
            yield return new TestCaseData(Players6(), OnTable6(), Winner6());
        }   

        private IEnumerable WinnersFromPlayersWithTheSameActivatedRule()
        {
            yield return new TestCaseData(PlayerList1(), CardList1(), new TwoPairsRule(), Winners1());
            yield return new TestCaseData(PlayerList2(), CardList2(), new FourOfKindRule(), Winners2());
            yield return new TestCaseData(PlayerList3(), CardList3(), new FullRule(), Winners3());
        }

        private IEnumerable ActivatedRulesTestCases()
        {
            yield return new TestCaseData(PlayersHand1(), CardsOnTable1(), new TwoPairsRule());
            yield return new TestCaseData(PlayersHand2(), CardsOnTable2(), new PairRule());
            yield return new TestCaseData(PlayersHand3(), CardsOnTable3(), null);
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
                new Card(9, Colors.PIK),
                new Card(13, Colors.PIK),
                new Card(13, Colors.TREFL),
                new Card(13, Colors.KARO)
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
                        new Card(9, Colors.KIER)
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

        #region TestCase3 FullRule

        private List<Player> Winners3()
        {
            return new List<Player> { PlayerList3()[1] };
        }

        private CardList CardList3()
        {
            return new CardList
            {
                new Card(9, Colors.KIER),
                new Card(6, Colors.PIK),
                new Card(13, Colors.PIK),
                new Card(13, Colors.TREFL),
                new Card(13, Colors.KARO)
            };
        }

        private List<Player> PlayerList3()
        {
            return new List<Player>
            {
                new Player
                {
                    Id = 1,
                    Hand = new CardList
                    {
                        new Card(6, Colors.KARO),
                        new Card(7, Colors.KIER)
                    }
                },
                new Player
                {
                    Id = 2,
                    Hand = new CardList
                    {
                        new Card(7, Colors.KARO),
                        new Card(9, Colors.KARO)
                    }
                }
            };
        }

        #endregion

        #endregion

        #region ActivatedRulesTestCases

        #region TestCase1 TwoPairRule

        private CardList CardsOnTable1()
        {
            return new CardList
            {
                new Card(10, Colors.PIK),
                new Card(9, Colors.TREFL),
                new Card(11, Colors.KARO),
                new Card(2, Colors.KIER),
                new Card(4, Colors.KIER)
            };
        }

        private CardList PlayersHand1()
        {
            return new CardList
            {
                new Card(10, Colors.KARO),
                new Card(9, Colors.KIER)
            };
        }

        #endregion

        #region TestCase2 PairRule

        private CardList CardsOnTable2()
        {
            return new CardList
            {
                new Card(10, Colors.PIK),
                new Card(9, Colors.TREFL),
                new Card(11, Colors.KARO),
                new Card(2, Colors.KIER),
                new Card(4, Colors.KIER)
            };
        }

        private CardList PlayersHand2()
        {
            return new CardList
            {
                new Card(3, Colors.KARO),
                new Card(9, Colors.KIER)
            };
        }


        #endregion

        #region NoRuleActivated

        private CardList CardsOnTable3()
        {
            return new CardList
            {
                new Card(10, Colors.PIK),
                new Card(9, Colors.TREFL),
                new Card(11, Colors.KARO),
                new Card(2, Colors.KIER),
                new Card(4, Colors.KIER)
            };
        }

        private CardList PlayersHand3()
        {
            return new CardList
            {
                new Card(6, Colors.KARO),
                new Card(7, Colors.KIER)
            };
        }

        #endregion

        #endregion

        #region GetWinners

        #region TestCase1

        private IEnumerable<Player> Winner1()
        {
            yield return new Player { Id = 3 };
        }

        private CardList OnTable1()
        {
            return new CardList
            {
                new Card(14, Colors.KIER),
                new Card(13, Colors.PIK),
                new Card(8, Colors.KARO),
                new Card(7, Colors.TREFL),
                new Card(6, Colors.PIK),
            };
        }

        private List<Player> Players1()
        {
            return new List<Player>
            {
                new Player
                {
                    Id = 1,
                    Hand = new CardList
                    {
                        new Card(14, Colors.KARO),
                        new Card(13, Colors.KARO)
                    }
                },
                new Player
                {
                    Id = 2,
                    Hand = new CardList
                    {
                        new Card(14, Colors.KARO),
                        new Card(14, Colors.KARO)
                    }
                },
                new Player
                {
                    Id = 3,
                    Hand = new CardList
                    {
                        new Card(10, Colors.KARO),
                        new Card(9, Colors.KARO)
                    }
                }
            };
        }

        #endregion

        #region TestCase2

        private IEnumerable<Player> Winner2()
        {
            yield return new Player { Id = 3 };
        }

        private CardList OnTable2()
        {
            return new CardList
            {
                new Card(14, Colors.KIER),
                new Card(13, Colors.PIK),
                new Card(8, Colors.KARO),
                new Card(7, Colors.TREFL),
                new Card(6, Colors.PIK),
            };
        }

        private List<Player> Players2()
        {
            return new List<Player>
            {
                new Player
                {
                    Id = 1,
                    Hand = new CardList
                    {
                        new Card(14, Colors.KARO),
                        new Card(2, Colors.KARO)
                    }
                },
                new Player
                {
                    Id = 2,
                    Hand = new CardList
                    {
                        new Card(14, Colors.KARO),
                        new Card(3, Colors.KARO)
                    }
                },
                new Player
                {
                    Id = 3,
                    Hand = new CardList
                    {
                        new Card(14, Colors.KARO),
                        new Card(9, Colors.KARO)
                    }
                }
            };
        }

        #endregion

        #region TestCase3

        private IEnumerable<Player> Winner3()
        {
            yield return new Player { Id = 3 };
        }

        private CardList OnTable3()
        {
            return new CardList
            {
                new Card(14, Colors.KIER),
                new Card(13, Colors.PIK),
                new Card(8, Colors.KARO),
                new Card(7, Colors.TREFL),
                new Card(6, Colors.PIK),
            };
        }

        private List<Player> Players3()
        {
            return new List<Player>
            {
                new Player
                {
                    Id = 1,
                    Hand = new CardList
                    {
                        new Card(8, Colors.KARO),
                        new Card(8, Colors.KARO)
                    }
                },
                new Player
                {
                    Id = 2,
                    Hand = new CardList
                    {
                        new Card(8, Colors.KARO),
                        new Card(7, Colors.KARO)
                    }
                },
                new Player
                {
                    Id = 3,
                    Hand = new CardList
                    {
                        new Card(13, Colors.KARO),
                        new Card(13, Colors.KARO)
                    }
                }
            };
        }

        #endregion

        #region TestCase4 - Straight vs Poker

        private IEnumerable<Player> Winner4()
        {
            yield return new Player { Id = 3 };
        }

        private CardList OnTable4()
        {
            return new CardList
            {
                new Card(14, Colors.KIER),
                new Card(13, Colors.KIER),
                new Card(12, Colors.KIER),
                new Card(7, Colors.TREFL),
                new Card(6, Colors.PIK),
            };
        }

        private List<Player> Players4()
        {
            return new List<Player>
            {
                new Player
                {
                    Id = 1,
                    Hand = new CardList
                    {
                        new Card(11, Colors.KARO),
                        new Card(10, Colors.KIER)
                    }
                },
                new Player
                {
                    Id = 2,
                    Hand = new CardList
                    {
                        new Card(8, Colors.KARO),
                        new Card(7, Colors.KARO)
                    }
                },
                new Player
                {
                    Id = 3,
                    Hand = new CardList
                    {
                        new Card(11, Colors.KIER),
                        new Card(10, Colors.KIER)
                    }
                }
            };
        }

        #endregion

        #region ThreeOfKind vs Full vs FourOfKind

        private IEnumerable<Player> Winner5()
        {
            yield return new Player { Id = 3 };
        }

        private CardList OnTable5()
        {
            return new CardList
            {
                new Card(14, Colors.KIER),
                new Card(13, Colors.KIER),
                new Card(13, Colors.KIER),
                new Card(7, Colors.TREFL),
                new Card(6, Colors.PIK),
            };
        }

        private List<Player> Players5()
        {
            return new List<Player>
            {
                new Player
                {
                    Id = 1,
                    Hand = new CardList
                    {
                        new Card(14, Colors.KARO),
                        new Card(13, Colors.KIER)
                    }
                },
                new Player
                {
                    Id = 2,
                    Hand = new CardList
                    {
                        new Card(14, Colors.KARO),
                        new Card(14, Colors.KARO)
                    }
                },
                new Player
                {
                    Id = 3,
                    Hand = new CardList
                    {
                        new Card(13, Colors.KIER),
                        new Card(13, Colors.KIER)
                    }
                }
            };
        }

        #endregion

        #region BestCard

        private IEnumerable<Player> Winner6()
        {
            yield return new Player { Id = 3 };
        }

        private CardList OnTable6()
        {
            return new CardList
            {
                new Card(14, Colors.KIER),
                new Card(13, Colors.KIER),
                new Card(13, Colors.KIER),
                new Card(7, Colors.TREFL),
                new Card(6, Colors.PIK),
            };
        }

        private List<Player> Players6()
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
                        new Card(10, Colors.KARO),
                        new Card(11, Colors.KARO)
                    }
                },
                new Player
                {
                    Id = 3,
                    Hand = new CardList
                    {
                        new Card(11, Colors.KIER),
                        new Card(12, Colors.KIER)
                    }
                }
            };
        }

        #endregion

        #endregion
    }
}
