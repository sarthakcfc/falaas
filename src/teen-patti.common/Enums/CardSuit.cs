using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teen_patti.common
{
    public enum CardSuit
    {
        Daimond = 0,
        Clover = 1,
        Heart = 2,
        Spade = 3
    }
    public static class CardSuitExtensions
    {
        public static string ToFriendlyString(this CardSuit suit) => suit switch
        {
            CardSuit.Daimond => "♦",
            CardSuit.Clover => "♣",
            CardSuit.Heart => "♥",
            CardSuit.Spade => "♠",
            _ => throw new Exception("Invalid Suit")
        };
    }
}
