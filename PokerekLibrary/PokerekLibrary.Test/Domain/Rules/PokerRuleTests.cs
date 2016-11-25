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
            yield return new TestCaseData(ValidPoker2(), true);
            yield return new TestCaseData(ValidPoker3(), true);
            yield return new TestCaseData(InvalidPoker1(), false);
            yield return new TestCaseData(InvalidPoker2(), false);
            yield return new TestCaseData(InvalidPoker3(), false);
        }
        #region TestCases
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

        private static List<Card> ValidPoker2()
        {
            return new List<Card>
            {
                new Card(5,Colors.TREFL),
                new Card(6,Colors.TREFL),
                new Card(7,Colors.TREFL),
                new Card(8,Colors.TREFL),
                new Card(9,Colors.TREFL)
            };
        }

        private static List<Card> ValidPoker3()
        {
            return new List<Card>
            {
                new Card(2,Colors.KARO),
                new Card(3,Colors.KARO),
                new Card(4,Colors.KARO),
                new Card(5,Colors.KARO),
                new Card(14,Colors.KARO),
            };
        }
        private static List<Card> InvalidPoker1()
        {
            return new List<Card>
            {
                new Card(2,Colors.KARO),
                new Card(3,Colors.KARO),
                new Card(4,Colors.KARO),
                new Card(5,Colors.KARO),
                new Card(6,Colors.KIER),
            };
        }

        private static List<Card> InvalidPoker2()
        {
            return new List<Card>
            {
                new Card(2,Colors.KARO),
                new Card(3,Colors.KARO),
                new Card(4,Colors.KARO),
                new Card(5,Colors.KARO),
                new Card(13,Colors.KARO),
            };
        }
        private static List<Card> InvalidPoker3()
        {
            return new List<Card>
            {
                new Card(1,Colors.KARO),
                new Card(3,Colors.KARO),
                new Card(4,Colors.KARO),
                new Card(5,Colors.KARO),
                new Card(6,Colors.KARO),
            };
        }
#endregion
    }
}
