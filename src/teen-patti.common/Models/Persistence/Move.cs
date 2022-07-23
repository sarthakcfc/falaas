using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teen_patti.common.Models.Persistence
{
    public class Move
    {
        public Guid? Id { get; set; }
        public string MoveType { get; set; }
    }
    public static class MoveExtensions
    {
        public static Move MapToPersistence(this Engine.Move move) => new Move()
        {
            Id = move.Id,
            MoveType = move.GetType().Name
        };
    }
}
