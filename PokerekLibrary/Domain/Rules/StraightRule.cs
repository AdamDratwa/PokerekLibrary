using System;
using System.Collections.Generic;
using System.Linq;
using Predicates = System.Collections.Generic.List<System.Func<System.Collections.Generic.List<PokerekLibrary.Domain.Card>, bool>>;

namespace PokerekLibrary.Domain.Rules
{
    public class StraightRule : Rule
    {
        private readonly Predicates _predicates;
        public StraightRule(Func<List<Card>, bool> predicate = null)
        {
            _predicates = new Predicates {RulePredicates.CardsInOrder};
            if (predicate != null)
            {
                _predicates.Add(predicate);
            }
        }
        public override bool IsTrue(List<Card> set)
        {
            set = set.OrderBy(x => x.Value).ToList();
            var isTrue = CheckRule(set, _predicates);
            if (!isTrue && set.Any(x => x.Value == (int)Figures.AS))
            {
                var cards = GetCardsToCheckRuleWithAses(set);
                isTrue = CheckRule(cards, _predicates);
            }
            return isTrue;
        }

        private List<Card> GetCardsToCheckRuleWithAses(List<Card> set)
        {
            var cards = set.Select(x => new Card
            {
                Value = x.Value == (int)Figures.AS? 1 : x.Value,
                Color = x.Color
            });
            return cards.OrderBy(x => x.Value).ToList();
        }

        private bool CheckRule(List<Card> cards, Predicates predicates)
        {
            var allTrue = predicates.Select(x => new
            {
                IsTrue = x.Invoke(cards)                
            });

            return allTrue.All(x => x.IsTrue);
        }

        public override int Power
        {
            get { return 5; }
        }

        public override bool IsPartOfRule(Card card, CardList playersSet)
        {
            return true;
        }
    }
}
