﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teen_patti.engine
{
    public class Card
    {
        private readonly CardRank _rank;
        private readonly CardSuit _suit;
        private bool _isVisible;
        public CardRank Rank { get => _rank; }
        public CardSuit Suit { get => _suit; }
        public bool IsVisible { get => _isVisible; set => _isVisible = value; }
        public Card(CardRank cardRank, CardSuit cardSuit)
        {
            _rank = cardRank;
            _suit = cardSuit;
            _isVisible = false;
        }

        public static ICollection<Card> NewTeenPattiDeck()
        {
            var cards = new List<Card>();
            foreach (CardRank cardRank in Enum.GetValues(typeof(CardRank)))
                foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
                    cards.Add(new Card(cardRank, suit));

            return cards.Shuffle();
        }

        public override string ToString() => IsVisible ? _rank.ToFriendlyString() + " " + Suit.ToFriendlyString() : "*";
    }
    public static class CardExtensions
    {
        private static Random rng = new Random();
        public static ICollection<T> Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }
    }
}