using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using PokerekLibrary.Domain;
using PokerekLibrary.Domain.Rules;

namespace PokerekLibrary.Test.Domain.Rules
{
    [TestFixture]
    public class PokerRuleTests
    {
        [TestCaseSource("PokerTestCases")]
        public void IsTrue_ShouldCheckRule(List<Card> cards, bool isTrue)
        {
            IRule rule = new PokerRule();
            var isRuleTrue = rule.IsTrue(cards);
            Assert.That(isRuleTrue, Is.EqualTo(isTrue));
        }

        public IEnumerable PokerTestCases()
        {
            yield return new TestCaseData(ValidPoker1(), true);
        }

        private static List<Card> ValidPoker1()
        {
            return new List<Card>
            {
                new Card(2,Colors.KARO),
                new Card(3,Colors.KARO),
                new Card(4,Colors.KARO),
                new Card(5,Colors.KARO),
                new Card(6,Colors.KARO),
            };
        }
    }
}
