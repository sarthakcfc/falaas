using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using teen_patti.common.Models.ViewModel;

namespace teen_patti.common.Models.Engine
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
        public Card(CardView view)
        {
            _rank = view.Rank;
            _suit = view.Suit;
            _isVisible = view.IsVisible;
        }
        public static ICollection<Card> CreateDeck(int numberOfDecks)
        {
            var cards = new List<Card>();
            for(int i = 0; i < numberOfDecks; i++)
                foreach (CardRank cardRank in Enum.GetValues(typeof(CardRank)))
                    foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
                        cards.Add(new Card(cardRank, suit));

            return cards;
        }

        public override string ToString() => IsVisible ? _rank.ToFriendlyString() + " " + Suit.ToFriendlyString() : "*";
    }
}