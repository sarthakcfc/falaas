using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teen_patti.service.Interefaces
{
    public interface IGameService
    {
        Task<common.Models.ViewModel.GameStateView> InitializeGame(ICollection<common.Models.ViewModel.CardView> deck, Guid playerId);
        Task<common.Models.ViewModel.GameStateView> AddPlayer(Guid gameId, Guid playerId);
        Task<common.Models.ViewModel.GameStateView> Deal(Guid gameId, int handSize);
        Task<common.Models.ViewModel.GameStateView> GetState(Guid gameId, Guid playerId);
        Task<common.Models.ViewModel.GameStateView> SeeHand(Guid gameId, Guid playerId);
        Task<common.Models.ViewModel.GameStateView> Bet(Guid gameId, Guid playerId, long betAmount);
    }
}
