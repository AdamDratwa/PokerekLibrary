namespace PokerekLibrary.Domain.Rules
{

    public class PokerRule : StraightRule
    {
        public PokerRule() : base(RulePredicates.CardsInColor)
        {
            
        }

        public override int Power
        {
            get { return 1; }
        }
    }
}
