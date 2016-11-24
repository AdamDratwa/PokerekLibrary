using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using PokerekLibrary.Domain;
using PokerekLibrary.Domain.Rules;

namespace PokerekLibrary.Test.Domain.Rules
{
    [TestFixture]
    public class TwoPairsRuleTests
    {
        [TestCaseSource(nameof(TwoPairTestCases))]
        public void IsTrue_ShouldCheckRule(List<Card> cards, bool isTrue)
        {
            var twoPairsRule = new TwoPairsRule();
            var isRuleTrue = twoPairsRule.IsTrue(cards);
            Assert.That(isRuleTrue, Is.EqualTo(isTrue));
        }

        [Test]
        public void GetCardsInStrongOrder_ShouldOrderCardsProperly()
        {
            var cardList = ValidTwoPairs1();
            var twoPairsRule = new TwoPairsRule();
            var cardsInStrongOrder = twoPairsRule.GetCardsInStrongOrder(cardList);
        }

        public IEnumerable TwoPairTestCases()
        {
            yield return new TestCaseData(ValidTwoPairs1(), true);
        }

        private CardList ValidTwoPairs1()
        {
            return new CardList
            {
                new Card(10, Colors.KARO),
                new Card(10, Colors.KIER),
                new Card(13, Colors.KARO),
                new Card(13, Colors.TREFL),
                new Card(9, Colors.PIK)
            };
        }
    }
}
