using System.Collections.Generic;
using System.Linq;
using PokerekLibrary.Domain.Rules;

namespace PokerekLibrary.Domain.Dictionaries
{
    public static class RulesList
    {
        public static List<IRule> Get()
        {
            return new List<IRule>
            {
                new PairRule(),
                new TwoPairsRule(),
                new ThreeOfKindRule(),
                new StraightRule(),
                new FlushRule(),
                new FullRule(),
                new FourOfKindRule(),
                new PokerRule()
            };
        }

        public static IRule GetRuleByPower(int power)
        {
            return Get().Single(x => x.Power == power);
        }
    }
}
