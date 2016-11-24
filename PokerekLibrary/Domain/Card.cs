namespace PokerekLibrary.Domain
{
    public class Card
    {
        public int Value { get; set; }
        public Colors Color { get; set; }

        public Card(int value, Colors color)
        {
            Value = value;
            Color = color;
        }
    }
}
