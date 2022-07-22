using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teen_patti.common.Models.Persistence
{
    public class Card
    {
        public CardRank Rank { get; set; }
        public CardSuit Suit { get; set; }
        public bool IsVisible { get; set; }
    }
    public static class CardViewExtensions
    {
        public static Card MapToPersistence(this Engine.Card card) => new Card()
        {
            Rank = card.Rank,
            Suit = card.Suit,
            IsVisible = card.IsVisible,
        };
    }
}
