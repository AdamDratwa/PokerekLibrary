namespace PokerekLibrary.Domain.Rules
{

    public class PokerRule : StraightRule
    {
        public PokerRule() : base(RulePredicates.CardsInColor)
        {
            
        }

        public override int Order
        {
            get { return 1; }
        }
    }
}
