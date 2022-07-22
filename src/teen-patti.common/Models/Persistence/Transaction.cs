using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teen_patti.common.Models.Persistence
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public string SenderType { get; set; }
        public DateTime TimeStampUTC { get; set; }
        public long Amount { get; set; }
    }
}
