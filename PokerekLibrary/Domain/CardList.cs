using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerekLibrary.Domain
{
    public class CardList : List<Card>
    {
        public CardList()
        {
            Validate();
        }

        public CardList(int size) : base(size)
        {
            Validate();
        }

        public static CardList operator +(CardList playersCard, CardList cardsOnTable)
        {
            var cardList = new CardList();
            playersCard.ForEach(x => cardList.Add(x));
            cardsOnTable.ForEach(x => cardList.Add(x));
            return cardList;
        }

        private void Validate()
        {
            var groupedByValue = this.GroupBy(x => x.Value).Select((key, value) => new
            {
                Value = value,
                DuplicatesCount = key.Count()
            });

            var cardsWithDuplicatedValue = groupedByValue.Where(x => x.DuplicatesCount > 1);
            foreach (var duplicates in cardsWithDuplicatedValue)
            {
                var cardsForValue = this.Where(x => x.Value == duplicates.Value).ToList();
                if (cardsForValue.Distinct().Count() != cardsForValue.Count)
                {
                    throw new Exception("There are duplicates!");
                }
            }
        }
    }
}
