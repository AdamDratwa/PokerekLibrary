using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using PokerekLibrary.Domain;
using PokerekLibrary.Domain.Rules;

namespace PokerekLibrary.Test.Domain.Rules
{
    [TestFixture]
    public class FlushRuleTests
    {
        [TestCaseSource("FlushTestCases")]
        public void IsTrue_ShouldCheckRule(List<Card> cards, bool isTrue)
        {
            var flushRule = new FlushRule();
            var isRuleTrue = flushRule.IsTrue(cards);
            Assert.That(isRuleTrue, Is.EqualTo(isTrue));
        }

        private IEnumerable FlushTestCases()
        {
            yield return new TestCaseData(ValidFlush1(), true);
            yield return new TestCaseData(ValidFlush2(), true);
            yield return new TestCaseData(InvalidFlush1(), false);
            yield return new TestCaseData(InvalidFlush2(), false);
        }

        private List<Card> ValidFlush2()
        {
            return new List<Card>
            {
                new Card(2, Colors.KARO),
                new Card(3, Colors.KARO),
                new Card(4, Colors.KARO),
                new Card(5, Colors.KARO),
                new Card(7, Colors.KARO),
                new Card(10, Colors.PIK),
                new Card(11, Colors.TREFL)
            };
        }

        private List<Card> ValidFlush1()
        {
            return new List<Card>
            {
                new Card(2, Colors.TREFL),
                new Card(3, Colors.TREFL),
                new Card(4, Colors.TREFL),
                new Card(5, Colors.TREFL),
                new Card(6, Colors.KARO),
                new Card(10, Colors.PIK),
                new Card(11, Colors.TREFL)
            };
        }

        private object InvalidFlush2()
        {
            return new List<Card>
            {
                new Card(2, Colors.PIK),
                new Card(3, Colors.TREFL),
                new Card(4, Colors.TREFL),
                new Card(5, Colors.TREFL),
                new Card(6, Colors.KARO),
                new Card(10, Colors.PIK),
                new Card(11, Colors.TREFL)
            };
        }

        private object InvalidFlush1()
        {
            return new List<Card>
            {
                new Card(2, Colors.PIK),
                new Card(3, Colors.TREFL),
                new Card(4, Colors.TREFL),
                new Card(5, Colors.TREFL),
                new Card(6, Colors.KARO),
                new Card(10, Colors.PIK),
                new Card(7, Colors.PIK)
            };
        }
    }
}
