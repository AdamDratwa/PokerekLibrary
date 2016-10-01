using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerekLibrary.Domain.Rules
{
    public class FullRule : IRule
    {
        public bool IsTrue(List<Card> cards)
        {
            return RulePredicates.HaveDuplicates(cards, 2, 1) ;
        }
    }
}
