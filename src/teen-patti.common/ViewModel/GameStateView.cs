using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace teen_patti.common
{
    public class GameStateView
    {
        public ICollection<Card> Deck { get; set; }
        public ICollection<PlayerView> Players { get; set; }
        public MoveView TransitionMove { get; set; }
        public PlayerView CurrentPlayer { get; set; }
        
        public GameStateView()
        {
        }
    }
    public static class GameStateViewExtensions
    {
        public static GameStateView MapToView(this GameState state) => new GameStateView()
        {
            Deck = state.Deck,
            Players = state.Players.Select(x => x.MapToView()).ToList(),
            TransitionMove = state.TransitionMove,
            CurrentPlayer = state.CurrentPlayer
        };
    }
}
