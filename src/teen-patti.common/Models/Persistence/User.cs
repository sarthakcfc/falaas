using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teen_patti.common.Models.Persistence
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public long CurrencyAmount { get; set; }
        public DateTime CreateDateUTC { get; set; }
    }
    public static class UserExtensions
    {
        public static Engine.Player MapToPlayer(this User persistence, int ordinal) => new Engine.Player(persistence, ordinal);

    }
}
