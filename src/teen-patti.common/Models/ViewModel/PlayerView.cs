using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teen_patti.common.Models.Engine;

namespace teen_patti.common.Models.ViewModel
{
    public class PlayerView
    {
        public Guid Id { get; set; }
        public ICollection<CardView> Hand { get; private set; }
        
        public PlayerView()
        {
            Hand = new List<CardView>();
        }
        public PlayerView(Engine.Player player)
        {
            Id = player.Id;
            Hand = player.Hand.Select(x => x.MapToView()).ToList();
        }

    }
    public static class PlayerViewExtensions
    {
        public static PlayerView MapToView(this Player player) => new PlayerView(player);
    }
}
