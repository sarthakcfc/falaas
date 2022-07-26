﻿namespace teen_patti.common
{
    public enum CardRank
    {
        Ace = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13
    }

    public static class CardRankExtensions
    {
        public static string ToFaceDownString(this CardRank rank) => rank switch
        {
            CardRank.Ace => "*",
            CardRank.Two => "*",
            CardRank.Three => "*",
            CardRank.Four => "*",
            CardRank.Five => "*",
            CardRank.Six => "*",
            CardRank.Seven => "*",
            CardRank.Eight => "*",
            CardRank.Nine => "*",
            CardRank.Ten => "*",
            CardRank.Jack => "*",
            CardRank.Queen => "*",
            CardRank.King => "*",
            _ => throw new Exception("Invalid Rank")
        };
    }
}