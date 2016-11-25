using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using PokerekLibrary.Domain;
using PokerekLibrary.Domain.Rules;

namespace PokerekLibrary.Test.Domain.Rules
{
    [TestFixture]
    public class FullRuleTests
    {
        [TestCaseSource("FullTestCases")]
        public void IsTrue_ShouldCheckRule(List<Card> cards, bool isTrue)
        {
            var fullRule = new FullRule();
            var isRuleTrue = fullRule.IsTrue(cards);
            Assert.That(isRuleTrue, Is.EqualTo(isTrue));
        }
        
        private IEnumerable FullTestCases()
        {
            yield return new TestCaseData(ValidFull1(), true);
            yield return new TestCaseData(ValidFull2(), true);
            yield return new TestCaseData(InvalidFull1(), false);
            yield return new TestCaseData(InvalidFull2(), false);
            yield return new TestCaseData(InvalidFull3(), false);
        }

        private List<Card> ValidFull1()
        {
            return new List<Card>
            {
                new Card(2, Colors.KARO),
                new Card(2, Colors.KIER),
                new Card(2, Colors.TREFL),
                new Card(3, Colors.PIK),
                new Card(3, Colors.KARO)
            };
        }

        private List<Card> ValidFull2()
        {
            return new List<Card>
            {
                new Card(13, Colors.KARO),
                new Card(13, Colors.KIER),
                new Card(13, Colors.TREFL),
                new Card(3, Colors.PIK),
                new Card(3, Colors.KARO)
            };
        }

        private List<Card> InvalidFull1()
        {
            return new List<Card>
            {
                new Card(13, Colors.KARO),
                new Card(13, Colors.KIER),
                new Card(13, Colors.TREFL),
                new Card(3, Colors.PIK),
                new Card(1, Colors.KARO)
            };
        }

        private List<Card> InvalidFull2()
        {
            return new List<Card>
            {
                new Card(13, Colors.KARO),
                new Card(13, Colors.KIER),
                new Card(3, Colors.TREFL),
                new Card(3, Colors.PIK),
                new Card(1, Colors.KARO)
            };
        }

        private List<Card> InvalidFull3()
        {
            return new List<Card>
            {
                new Card(3, Colors.KARO),
                new Card(3, Colors.KIER),
                new Card(3, Colors.TREFL),
                new Card(3, Colors.PIK),
                new Card(1, Colors.KARO)
            };
        }
    }
}
