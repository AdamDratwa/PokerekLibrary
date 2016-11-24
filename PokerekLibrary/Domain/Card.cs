using System;

namespace PokerekLibrary.Domain
{
    public class Card
    {
        public uint Value
        {
            get { return Value; }
            set
            {
                if (value <= 0 || value > 14) throw new ArgumentOutOfRangeException(nameof(value));
                Value = value;
            }
        }

        public Colors Color { get; set; }

        public Card(uint value, Colors color)
        {
            Value = value;
            Color = color;
        }
    }
}
