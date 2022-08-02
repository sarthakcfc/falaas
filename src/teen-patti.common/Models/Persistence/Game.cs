using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teen_patti.common.Models.Persistence
{
    public class Game
    {
        public Guid Id { get; set; }
        public DateTime CreateDateUTC { get; set; }
        public ICollection<GameState> States { get; set; }
    }
}
