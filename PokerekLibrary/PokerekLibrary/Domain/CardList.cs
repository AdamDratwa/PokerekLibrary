using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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
            playersCard.AddRange(cardsOnTable);
            return playersCard;
        }

        private void Validate()
        {
            //TODO: check if set of cards doesn't contain duplicates
            //var groupedByValue = this.GroupBy(x => x.Value).Select((key, value) => new 
            //{
            //    Value = value,
            //    DuplicatesCount = key.Count(),
            //    Card = key
            //});

            //var colorDuplicates = groupedByValue.GroupBy(x => x.Card.)
        }
    }
}
