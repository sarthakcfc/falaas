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
        public Guid CurrentPlayerId { get; set; }
        public PlayerView Player { get; set; }
        public ICollection<PlayerView> Opponents { get; set; }
        public long CurrentBetAmount { get; set; }
        public long PotAmount { get; set; }
    }
    public static class GameStateViewModelExtensions
    {

        public static GameStateView MapToPlayerView(this Engine.GameState state, PlayerView requestedPlayer) => new GameStateView()
        {
            GameId = state.GameId,
            CurrentPlayerId = state.CurrentPlayer.Id,
            Player = requestedPlayer,
            PotAmount = state.PotAmount,
            CurrentBetAmount = state.CurrentBetAmount,
            Opponents = state.Players.Where(x => x.Id != requestedPlayer.Id).Select(x => new PlayerView(x)).ToList()
        };
        public static GameStateView MapToPlayerView(this Persistence.GameState state, PlayerView requestedPlayer) => new GameStateView()
        {
            GameId = state.GameId,
            CurrentPlayerId = state.CurrentPlayer.Id,
            Player = requestedPlayer,
            PotAmount = state.PotAmount,
            CurrentBetAmount = state.CurrentBetAmount,
            Opponents = state.Players.Where(x => x.Id != requestedPlayer.Id).Select(x => new PlayerView(x)).ToList()
        };
    }
}
