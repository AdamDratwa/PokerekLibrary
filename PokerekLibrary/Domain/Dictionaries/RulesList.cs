using System.Collections.Generic;
using System.Linq;
using System.Threading;
using PokerekLibrary.Domain.Rules;

namespace PokerekLibrary.Domain.Dictionaries
{
    public static class RulesList
    {
        private static readonly List<IRule> _rules;

        static RulesList()
        {
            _rules = new List<IRule>
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

        public static List<IRule> Get()
        {
            return _rules;
        }

        public static IRule GetRuleByPower(int power)
        {
            return Get().Single(x => x.Power == power);
        }
    }
}
