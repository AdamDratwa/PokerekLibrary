using System;
using System.Collections.Generic;
using System.Linq;
using Predicates = System.Collections.Generic.List<System.Func<System.Collections.Generic.List<PokerekLibrary.Domain.Card>, bool>>;

namespace PokerekLibrary.Domain.Rules
{
    public class StraightRule : IRule
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
        public bool IsTrue(List<Card> cards)
        {
            cards = cards.OrderBy(x => x.Value).ToList();
            var isTrue = CheckRule(cards, _predicates);
            if (!isTrue && cards.Any(x => x.Value == (int)Figures.AS))
            {
                var ases = cards.Where(x => x.Value == (int)Figures.AS).ToList();
                ases.ForEach(x => x.Value = 1);
                cards = cards.OrderBy(x => x.Value).ToList();
                isTrue = CheckRule(cards, _predicates);
            }
            return isTrue;
        }

        private bool CheckRule(List<Card> cards, Predicates predicates)
        {
            var allTrue = predicates.Select(x => new
            {
                IsTrue = x.Invoke(cards)                
            });

            return allTrue.All(x => x.IsTrue);
        }

        public virtual int Power
        {
            get { return 5; }
        }

        public List<Card> GetCardsInStrongOrder(CardList playersSet)
        {
            throw new NotImplementedException();
        }
    }
}
