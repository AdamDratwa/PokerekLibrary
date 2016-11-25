using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using PokerekLibrary.Domain;
using PokerekLibrary.Domain.Rules;

namespace PokerekLibrary.Test.Domain.Rules
{
    [TestFixture]
    public class StraightRuleTests
    {
        [TestCaseSource("StraightTestCases")]
        public void IsTrue_ShouldCheckRule(List<Card> cards, bool isTrue)
        {
            IRule rule = new StraightRule();
            var isRuleTrue = rule.IsTrue(cards);
            Assert.That(isRuleTrue, Is.EqualTo(isTrue));
        }

        private IEnumerable StraightTestCases()
        {
            yield return new TestCaseData(ValidStraight1(), true);
            yield return new TestCaseData(ValidStraight2(), true);
            yield return new TestCaseData(ValidStraight3(), true);
            yield return new TestCaseData(InvalidStraight1(), false);
            yield return new TestCaseData(InvalidStraight2(), false);
            yield return new TestCaseData(InvalidStraight3(), false);
        }

        private List<Card> InvalidStraight3()
        {
            return new List<Card>
            {
                new Card(3, Colors.KARO),
                new Card(4, Colors.KIER),
                new Card(5, Colors.TREFL),
                new Card(6, Colors.PIK),
                new Card(8, Colors.KIER)
            };
        }

        private List<Card> InvalidStraight2()
        {
            return new List<Card>
            {
                new Card(3, Colors.KARO),
                new Card(4, Colors.KIER),
                new Card(5, Colors.TREFL),
                new Card(8, Colors.PIK),
                new Card(9, Colors.KIER)
            };
        }

        private List<Card> InvalidStraight1()
        {
            return new List<Card>
            {
                new Card(3, Colors.KARO),
                new Card(4, Colors.KIER),
                new Card(5, Colors.TREFL),
                new Card(6, Colors.PIK),
                new Card(14, Colors.KIER)
            };
        }

        private List<Card> ValidStraight3()
        {
            return new List<Card>
            {
                new Card(3, Colors.KARO),
                new Card(4, Colors.KIER),
                new Card(5, Colors.TREFL),
                new Card(6, Colors.PIK),
                new Card(7, Colors.KIER)
            };
        }

        private List<Card> ValidStraight2()
        {
            return new List<Card>
            {
                new Card(2, Colors.KARO),
                new Card(3, Colors.KIER),
                new Card(4, Colors.TREFL),
                new Card(5, Colors.PIK),
                new Card(14, Colors.KIER)
            };
        }

        private List<Card> ValidStraight1()
        {
            return new List<Card>
            {
                new Card(10, Colors.KARO),
                new Card(11, Colors.KIER),
                new Card(12, Colors.TREFL),
                new Card(13, Colors.PIK),
                new Card(14, Colors.KIER)
            };
        }
    }
}
