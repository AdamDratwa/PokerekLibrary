using System.Collections.Generic;
using PokerekLibrary.Domain;

namespace PokerekLibrary.Services
{
    public interface IRulesService
    {
        List<Player> GetWinners(List<Player> players , CardList cardOnTable);
    }
}
