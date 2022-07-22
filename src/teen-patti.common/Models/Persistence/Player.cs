using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teen_patti.common.Models.Persistence
{
    public class Player
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public long CurrencyAmount { get; set; }
        public DateTime CreateDateUTC { get; set; }
    }
    public static class PlayerExtensions
    {
        public static Engine.Player MapToPlayer(this Player persistence, int ordinal) => new Engine.Player(persistence, ordinal);

    }
}
