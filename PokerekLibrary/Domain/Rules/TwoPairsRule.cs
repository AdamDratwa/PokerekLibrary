﻿using System.Collections.Generic;

namespace PokerekLibrary.Domain.Rules
{
    public class TwoPairsRule : Rule
    {
        public override bool IsTrue(List<Card> cards)
        {
            return RulePredicates.HaveDuplicates(cards, 2, 2);
        }

        public override int Order
        {
            get { return 7; }
        }
    }
}
