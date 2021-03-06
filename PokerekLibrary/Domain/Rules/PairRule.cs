﻿using System.Collections.Generic;

namespace PokerekLibrary.Domain.Rules
{
    public class PairRule : Rule
    {
        public override bool IsTrue(List<Card> cards)
        {
            return RulePredicates.HaveDuplicates(cards, 2, 1);
        }

        public override int Power
        {
            get { return 8; }
        }

        public override bool IsPartOfRule(Card card, CardList playersSet)
        {
            return RulePredicates.HasDuplicates(card, playersSet, 2);
        }
    }
}
