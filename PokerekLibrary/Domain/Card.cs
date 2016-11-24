using System;

namespace PokerekLibrary.Domain
{
    public class Card
    {
        private uint _value;
        public uint Value
        {
            get { return _value; }
            set
            {
                if (value <= 0 || value > 14) throw new ArgumentOutOfRangeException(nameof(value));
                _value = value;
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
