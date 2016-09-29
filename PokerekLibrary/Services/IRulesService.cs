using System.Collections.Generic;
using PokerekLibrary.Domain;

namespace PokerekLibrary.Services
{
    public interface IRulesService
    {
        int GetHighestActivatedRuleValue(List<Card> playersCard, List<Card> cardOnTable);
    }
}
