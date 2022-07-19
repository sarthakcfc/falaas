using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teen_patti.common
{
    public class CardView
    {
        public CardRank Rank { get; set; }
        public CardSuit Suit { get; set; }
        public bool IsVisible { get; set; }
    }
}
