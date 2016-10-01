using System.Collections.Generic;
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
    }
}
