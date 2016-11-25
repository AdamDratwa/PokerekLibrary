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
        [TestCaseSource("TheSameActivatedRuleCases")]
        public void SelectWinnersFromPlayersWithTheSameHand_ShouldSelectWinner(List<Player> players, CardList cardsOnTable, IRule activatedRule, List<Player> winners)
        {
            var ruleService = new RuleService();
            var playersWhoWon = ruleService.SelectWinnersFromPlayersWithTheSameActivatedRule(players, cardsOnTable, activatedRule);
            Assert.That(playersWhoWon.Count, Is.EqualTo(1));
            Assert.That(playersWhoWon.First().Id, Is.EqualTo(winners.First().Id));
        }

        [TestCaseSource("BestActivatedRuleCases")]
        public void GetBestActivatedRule_ShouldGetBestActivatedRule()
        {
            
        }

        private IEnumerable TheSameActivatedRuleCases()
        {
            yield return new TestCaseData(ListOfPlayers1(),CardsOnTable1(), new FourOfKindRule(), WinnersList1());
            yield return new TestCaseData(ListOfPlayers2(), CardsOnTable2(), new TwoPairsRule(), WinnersList2());
            yield return new TestCaseData(ListOfPlayers3(), CardsOnTable3(), new FlushRule(), WinnersList3());
            yield return new TestCaseData(ListOfPlayers4(), CardsOnTable4(), null, WinnersList4());
        }

        private IEnumerable BestActivatedRuleCases()
        {
            yield return new TestCaseData();
        }

        #region TestCases

        #region TestCase1 FourOfKindRule

        private List<Player> WinnersList1()
        {
            return new List<Player> {ListOfPlayers1()[1]};
        }

        private CardList CardsOnTable1()
        {
            return new CardList
            {
                new Card(10, Colors.KIER),
                new Card(10, Colors.PIK),
                new Card(9, Colors.KARO),
                new Card(9, Colors.PIK),
                new Card(13, Colors.KARO)
            };
        }

        private List<Player> ListOfPlayers1()
        {
            return new List<Player>
            {
                new Player
                {   
                    Id = 1,
                    Hand = new CardList
                    {
                        new Card(9, Colors.KARO),
                        new Card(9, Colors.TREFL)
                    }
                },
                new Player
                {
                    Id = 2,
                    Hand = new CardList
                    {
                        new Card(10, Colors.KARO),
                        new Card(10, Colors.TREFL)
                    }
                }
            };
        }

        #endregion 

        #region TestCase2 TwoPairsRule

        private List<Player> WinnersList2()
        {
            return new List<Player> { ListOfPlayers2()[1] };
        }

        private CardList CardsOnTable2()
        {
            return new CardList
            {
                new Card(10, Colors.KIER),
                new Card(11, Colors.PIK),
                new Card(9, Colors.KARO),
                new Card(8, Colors.PIK),
                new Card(13, Colors.KARO)
            };
        }

        private List<Player> ListOfPlayers2()
        {
            return new List<Player>
            {
                new Player
                {
                    Id = 1,
                    Hand = new CardList
                    {
                        new Card(13, Colors.KARO),
                        new Card(8, Colors.TREFL)
                    }
                },
                new Player
                {
                    Id = 2,
                    Hand = new CardList
                    {
                        new Card(13, Colors.KARO),
                        new Card(9, Colors.TREFL)
                    }
                }
            };
        }

        #endregion TwoPairsRule

        #region TestCase3 FlushRule

        private List<Player> WinnersList3()
        {
            return new List<Player> { ListOfPlayers3()[1] };
        }

        private CardList CardsOnTable3()
        {
            return new CardList
            {
                new Card(10, Colors.KIER),
                new Card(11, Colors.PIK),
                new Card(9, Colors.KARO),
                new Card(12, Colors.PIK),
                new Card(13, Colors.KARO)
            };
        }

        private List<Player> ListOfPlayers3()
        {
            return new List<Player>
            {
                new Player
                {
                    Id = 1,
                    Hand = new CardList
                    {
                        new Card(7, Colors.KARO),
                        new Card(8, Colors.TREFL)
                    }
                },
                new Player
                {
                    Id = 2,
                    Hand = new CardList
                    {
                        new Card(8, Colors.KARO),
                        new Card(14, Colors.TREFL)
                    }
                }
            };
        }

        #endregion

        #region TestCase4 NoRule

        private List<Player> WinnersList4()
        {
            return new List<Player> { ListOfPlayers4()[1] };
        }

        private CardList CardsOnTable4()
        {
            return new CardList
            {
                new Card(10, Colors.KIER),
                new Card(11, Colors.PIK),
                new Card(9, Colors.KARO),
                new Card(12, Colors.PIK),
                new Card(13, Colors.KARO)
            };
        }

        private List<Player> ListOfPlayers4()
        {
            return new List<Player>
            {
                new Player
                {
                    Id = 1,
                    Hand = new CardList
                    {
                        new Card(7, Colors.KARO),
                        new Card(8, Colors.TREFL)
                    }
                },
                new Player
                {
                    Id = 2,
                    Hand = new CardList
                    {
                        new Card(8, Colors.KARO),
                        new Card(14, Colors.TREFL)
                    }
                }
            };
        }

        #endregion

        #endregion
    }
}
