using System.Collections.Generic;

namespace PokerekLibrary.Domain
{
    public class Player
    {
        public int Id { get; set; }
        public IList<Card> Hand { get; set; }
        public int Chips { get; set; }
        public int ChipsInGame { get; set; }
    }
}
