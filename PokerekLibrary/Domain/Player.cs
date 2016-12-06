using System.Collections.Generic;
using System.Linq;
using PokerekLibrary.Services;

namespace PokerekLibrary.Domain
{
    public class Player
    {
        private readonly IGameService _gameService;

        public int Id { get; set; }
        public string Name { get; set; }
        public CardList Hand { get; set; }
        public int Chips { get; set; }
        public int ChipsInGame { get; set; }
        public bool IsAllIn { get; set; }
        public bool IsActive { get; set; }

        public IEnumerable<int> RaiseRange => PlayersRaiseRange();
         
        private IEnumerable<int> PlayersRaiseRange()
        {
            var currentStack = _gameService.GetCurrentStack();
            if (currentStack * 2 <= Chips + ChipsInGame)
            {
                return Enumerable.Range(currentStack * 2, Chips + ChipsInGame);
            }
            return Enumerable.Range(0, 0);
        }

        public Player(IGameService gameService)
        {
            _gameService = gameService;
            Hand = new CardList(2);
        }

        public void Check(int amount)
        {
            if (Chips >= 0)
            {
                Chips -= amount;
                ChipsInGame += amount;
            }
            else
            {
                IsAllIn = true;
            } 
        }

        public void Raise()
        {
            if (CanRaise)
            {
                
            }
        }
    }
}
