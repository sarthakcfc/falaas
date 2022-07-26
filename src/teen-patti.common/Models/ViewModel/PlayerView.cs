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

        public PlayerView()
        {
            Hand = new List<CardView>();
        }
        public PlayerView(Persistence.Player player)
        {
            Id = player.Id;
            Name = player.Name;
            Hand = player.Hand.Select(x => x.IsVisible ? x.MapToSeenView() : x.MapToUnseenView()).ToList();
        }
        public PlayerView(Engine.Player player)
        {
            Id = player.Id;
            Name = player.Name;
            Hand = player.Hand.Select(x => x.IsVisible ? x.MapToSeenView() : x.MapToUnseenView()).ToList();
        }

    }
    public static class PlayerViewExtensions
    {
        public static PlayerView MapToView(this Engine.Player player) => new PlayerView(player);

        public static ViewModel.PlayerView MapToView(this Persistence.Player player) => new ViewModel.PlayerView(player);
    }
}
