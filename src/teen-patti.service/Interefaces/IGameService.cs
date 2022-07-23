using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teen_patti.service.Interefaces
{
    public interface IGameService
    {
        Task<Guid> InitializeGame(ICollection<common.Models.ViewModel.CardView> deck, Guid playerId);
        Task<Guid> AddPlayer(Guid gameId, Guid playerId);
        Task<Guid> Deal(Guid gameId, int handSize);
        Task<ICollection<common.Models.ViewModel.CardView>> GetHand(Guid gameId, Guid playerId);
    }
}
