using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teen_patti.common.Models.ViewModel
{
    public class PlayerView
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<CardView> Hand { get; set; }
        public bool IsCurrentPlayer { get; set; }

        public PlayerView()
        {
            Hand = new List<CardView>();
        }
        public PlayerView(Engine.Player player)
        {
            Id = player.Id;
            Name = player.Name;
            Hand = player.Hand.Select(x => x.MapToView()).ToList();
        }
        public PlayerView(Persistence.User player)
        {
            Id = player.Id;
            Name = player.UserName;
            Hand = new List<CardView>();
        }

    }
    public static class PlayerViewExtensions
    {
        public static PlayerView MapToView(this Engine.Player player) => new PlayerView(player);
        public static PlayerView MapToPlayerView(this Persistence.User player) => new PlayerView(player);
    }
}
