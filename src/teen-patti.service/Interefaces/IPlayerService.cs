using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teen_patti.common.Models.ViewModel;

namespace teen_patti.service.Interefaces
{
    public interface IPlayerService
    {
        Task<ICollection<PlayerView>> GetPlayers();
    }
}
