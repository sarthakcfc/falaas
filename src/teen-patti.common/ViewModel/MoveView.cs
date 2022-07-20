using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace teen_patti.common
{
    public class MoveView
    {
        public string MoveType { get; set; }
    }
    public static class MoveViewExtensions
    {
        public static MoveView MapToView(this Move move) => new MoveView()
        {
            MoveType = move.GetType().Name
        };
        public static Move MapToMove(this MoveView view, GameState state) => view.MoveType switch
        {
            nameof(Deal) => new Deal(state),
            nameof(BlindBet) => new BlindBet(state),
            nameof(SeenBet) => new SeenBet(state),
            nameof(SeeCards) => new SeeCards(state),
            _ => new NullMove(state)
        };
    }
}
