using System.Collections.Generic;

namespace PokerekLibrary.Domain
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CardList Hand { get; set; }
        public int Chips { get; set; }
        public int ChipsInGame { get; set; }
        public bool IsAllIn { get; set; }

        public Player()
        {
            Hand = new CardList(2);
        }
    }
}
