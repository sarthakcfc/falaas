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
        public long CurrentBetAmount { get; set; }
        public long PotAmount { get; set; }
        public Player CurrentPlayer { get; set; }
        public List<Player> Players { get; set; }
        public List<Card> Deck { get; set; }
        public Move TransitionMove { get; set; }
        public DateTime CreatedDateUTC { get; set; }
        public GameState()
        {
            Players = new List<Player>();
            Deck = new List<Card>();
            TransitionMove = new Move();
            CurrentPlayer = new Player();
        }
    }
    public class Player
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Ordinal { get; set; }
        public List<Card> Hand { get; set; }
        public Player()
        {
            Hand = new List<Card>();
        }
    }

    public class Card
    {
        public Guid Id { get; set; }
        public CardRank Rank { get; set; }
        public CardSuit Suit { get; set; }
        public bool IsVisible { get; set; }
    }
    public static class GameStateExtensions
    {
        public static Engine.Card MapToCard(this Card card) => new Engine.Card(card);
        public static Engine.Player MapToPlayer(this Player player) => new Engine.Player(player);


        public static GameState MapToPersistence(this Engine.GameState state, Game game) => new GameState()
        {
            Id = state.Id,
            GameId = game.Id,
            CurrentPlayer = state.CurrentPlayer.MapToPersistence(),
            Deck = state.Deck.Select(x => x.MapToPersistence()).ToList(),
            CurrentBetAmount = state.CurrentBetAmount,
            PotAmount = state.PotAmount,
            Players = state.Players.Select(x => new Player()
            {
                Id = x.Id,
                Name = x.Name,
                Hand = x.Hand.Select(x => x.MapToPersistence()).ToList(),
                Ordinal = x.Ordinal
            }).ToList(),
            TransitionMove = (state.TransitionMove ?? new Engine.NullMove(state)).MapToPersistence(),
            CreatedDateUTC = DateTime.UtcNow
        };
        public static Card MapToPersistence(this Engine.Card card) => new Card()
        {
            Id = card.Id,
            Rank = card.Rank,
            Suit = card.Suit,
            IsVisible = card.IsVisible,
        };
        public static Player MapToPersistence(this Engine.Player player) => new Player()
        {
            Id = player.Id,
            Name = player.Name,
            Ordinal = player.Ordinal,
            Hand = player.Hand.Select(x => x.MapToPersistence()).ToList()
        };
        
    }
}
