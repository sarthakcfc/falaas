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
        public List<Player> Players { get; set; }
        public List<Card> Deck { get; set; }
        public Move? TransitionMove { get; set; }
        public DateTime CreatedDateUTC { get; set; }
    }
    public class Player
    {
        public Guid Id { get; set; }
        public int Ordinal { get; set; }
        public List<Card> Hand { get; set; }
    }

    public class Card
    {
        public CardRank Rank { get; set; }
        public CardSuit Suit { get; set; }
        public bool IsVisible { get; set; }
    }
    public static class GameStateExtensions
    {
        public static GameState MapToPersistence(this Engine.GameState state, Game game) => new GameState()
        {
            Id = state.Id,
            GameId = game.Id,
            CurrentPlayerId = state.CurrentPlayer.Id,
            Deck = state.Deck.Select(x => x.MapToPersistence()).ToList(),
            Players = state.Players.Select(x => new Player()
            {
                Id = x.Id,
                Hand = x.Hand.Select(x => x.MapToPersistence()).ToList()
            }).ToList(),
            TransitionMove = state.TransitionMove?.MapToPersistence() ?? null,
            CreatedDateUTC = DateTime.UtcNow
        };

        public static Card MapToPersistence(this Engine.Card card) => new Card()
        {
            Rank = card.Rank,
            Suit = card.Suit,
            IsVisible = card.IsVisible,
        };
        public static Engine.Card MapToCard(this Card card) => new Engine.Card(card);

        public static Engine.Player MapToPlayer(this Player player) => new Engine.Player(player);
    }
}
