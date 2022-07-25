using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teen_patti.common.Models.Engine;

namespace teen_patti.common.Models.ViewModel
{
    public class CardView
    {
        public string Rank { get; set; }
        public string Suit { get; set; }
    }
    public static class CardViewExtensions
    {
        public static CardView MapToView(this Card card) => new CardView()
        {
            Rank = card.Rank.ToString(),
            Suit = card.Suit.ToString(),
        };
        public static Card MapToCard(this CardView view) => new Card(view);
    }
}
