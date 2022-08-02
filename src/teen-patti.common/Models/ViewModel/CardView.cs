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
        public static CardView MapToSeenView(this Card card) => new CardView()
        {
            Rank = card.Rank.ToString(),
            Suit = card.Suit.ToString(),
        };
        public static CardView MapToUnseenView(this Card card) => new CardView()
        {
            Rank = card.Rank.ToFaceDownString(),
            Suit = card.Suit.ToFaceDownString(),
        };
        public static CardView MapToSeenView(this Persistence.Card card) => new CardView()
        {
            Rank = card.Rank.ToString(),
            Suit = card.Suit.ToString(),
        };
        public static CardView MapToUnseenView(this Persistence.Card card) => new CardView()
        {
            Rank = card.Rank.ToFaceDownString(),
            Suit = card.Suit.ToFaceDownString(),
        };
        public static Card MapToCard(this CardView view) => new Card(view);
    }
}
