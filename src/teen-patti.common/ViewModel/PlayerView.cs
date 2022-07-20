using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teen_patti.common
{
    public class PlayerView
    {
        public Guid Id { get; set; }
        public int Ordinal { get; set; }
        public ICollection<CardView> Hand { get; set; }
        
        public PlayerView()
        {
            Hand = new List<CardView>();
        }

    }
    public static class PlayerViewExtensions
    {
        public static PlayerView MapToView(this Player player) => new PlayerView()
        {
            Id = player.Id,
            Ordinal = player.Ordinal,
            Hand = player.Hand.Select(x => x.MapToView()).ToList(),
        };
        public static Player MapToPlayer(this PlayerView view) => new Player(view);
    }
}
