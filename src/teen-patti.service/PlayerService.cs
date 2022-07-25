using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teen_patti.common.Models.ViewModel;
using teen_patti.data.postgres;
using teen_patti.service.Interefaces;

namespace teen_patti.service
{
    public class PlayerService : IPlayerService
    {
        private readonly TeenPattiDbContext _dbContext;
        public PlayerService(TeenPattiDbContext dbContext) => _dbContext = dbContext;

        /// <summary>
        /// TODO add filters to this later
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<PlayerView>> GetPlayers() => await _dbContext.Users.Select(x => x.MapToPlayerView()).ToListAsync(); 
    }
}
