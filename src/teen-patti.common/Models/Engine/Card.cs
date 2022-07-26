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
        private readonly Guid _id;
        private readonly CardRank _rank;
        private readonly CardSuit _suit;
        private bool _isVisible;

        public CardRank Rank { get => _rank; }
        public CardSuit Suit { get => _suit; }
        public bool IsVisible { get => _isVisible; set => _isVisible = value; }
        public Guid Id { get => _id; }
        public Card(CardRank cardRank, CardSuit cardSuit)
        {
            _id = Guid.NewGuid();
            _rank = cardRank;
            _suit = cardSuit;
            _isVisible = false;
        }
        public Card(Persistence.Card persistence)
        {
            _id = persistence.Id;
            _rank = persistence.Rank;
            _suit = persistence.Suit;
            _isVisible = persistence.IsVisible;
        }
            
        public Card(CardView view)
        {
            _id = Guid.NewGuid();
            _rank = (CardRank)Enum.Parse(typeof(CardRank), view.Rank);
            _suit = (CardSuit)Enum.Parse(typeof(CardSuit), view.Suit);
            _isVisible = false;
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