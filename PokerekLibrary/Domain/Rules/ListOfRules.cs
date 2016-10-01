using System.Collections.Generic;

namespace PokerekLibrary.Domain.Rules
{
    public static class ListOfRules
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
