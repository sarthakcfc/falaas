using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teen_patti.common.Models.Persistence;

namespace teen_patti.common.Models.ViewModel
{
    public class GameStateView
    {
        public Guid GameId { get; set; }
        public PlayerView Player { get; set; }
        public ICollection<PlayerView> Opponents { get; set; }
    }
    public static class GameStateViewModelExtensions
    {
        public static GameStateView MapToShowView(this Engine.GameState state) => new GameStateView()
        {
            GameId = state.GameId,
            Player = state.CurrentPlayer.MapToView(),
            Opponents = state.Players.Where(x => x.Id != state.CurrentPlayer.Id).Select(x => x.MapToView()).ToList()
        };
        public static GameStateView MapToShowView(this Persistence.GameState state) => new GameStateView()
        {
            GameId = state.GameId,
            Player = state.CurrentPlayer.MapToView(),
            Opponents = state.Players.Where(x => x.Id != state.CurrentPlayer.Id).Select(x => x.MapToView()).ToList()
        };

        public static GameStateView MapToPlayerView(this Engine.GameState state) => new GameStateView()
        {
            GameId = state.GameId,
            Player = state.CurrentPlayer.MapToView(),
            Opponents = state.Players.Where(x => x.Id != state.CurrentPlayer.Id).Select(x => new PlayerView()
            {
                Id = x.Id,
                Hand = new List<CardView>()
            }).ToList()
        };
        public static GameStateView MapToPlayerView(this Persistence.GameState state) => new GameStateView()
        {
            GameId = state.GameId,
            Player = state.CurrentPlayer.MapToView(),
            Opponents = state.Players.Where(x => x.Id != state.CurrentPlayer.Id).Select(x => new PlayerView()
            {
                Id = x.Id,
                Hand = new List<CardView>()
            }).ToList()
        };
    }
}
