using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teen_patti.common.Models.Persistence
{
    public class GameState
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }
        public Guid CurrentPlayerId { get; set; }
        public ICollection<Guid> Players { get; set; }
        public ICollection<Card> Deck { get; set; }
        public Move? TransitionMove { get; set; }
        public DateTime CreatedDateUTC { get; set; }
    }
    public static class GameStateExtensions
    {
        public static GameState MapToPersistence(this Engine.GameState state, Game game) => new GameState()
        {
            Id = state.Id,
            GameId = game.Id,
            CurrentPlayerId = state.CurrentPlayer.Id,
            Deck = state.Deck.Select(x => x.MapToPersistence()).ToList(),
            Players = state.Players.Select(x => x.Id).ToList(),
            TransitionMove = state.TransitionMove?.MapToPersistence() ?? null,
            CreatedDateUTC = DateTime.UtcNow
        };
    }
}
