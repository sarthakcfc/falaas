using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using teen_patti.common.Models.ViewModel;

namespace teen_patti.common.Models.Engine
{
    public class Player
    {
        private readonly Guid _id;
        private readonly int _ordinal;
        private ICollection<Card> _hand;
        private const int MAX_PLAYERS = 4;

        public ICollection<Card> Hand { get => _hand; }
        public Guid Id { get => _id; }
        public int Ordinal { get => _ordinal; }
        public static ICollection<Player> InitPlayers()
        {
            //return 2 empty players for now
            return new List<Player>(new Player[] { new Player(1), new Player(2)});
        }
        public Player(int ordinal)
        {
            _id = Guid.NewGuid();
            _ordinal = ordinal;
            _hand = new List<Card>();
        }
        public Player(PlayerView view)
        {
            _ordinal = view.Ordinal;
            _id = view.Id;
            _hand = view.Hand.Select(x => x.MapToCard()).ToList();
        }
        public Player(ICollection<Card> hand, int ordinal)
        {
            _id = Guid.NewGuid();
            _ordinal = ordinal;
            createHand(hand);
        }
        
        public ICollection<Card> AddToHand(Card card)
        { 
            if(_hand.Count >= 3)
                throw new ArgumentException($"Hand cannot be greater than three cards.");
            _hand.Add(card);
            return _hand;
        }
        public ICollection<Card> SetHand (ICollection<Card> hand)
        {
            if (hand.Count > 3)
                throw new ArgumentException($"Hand cannot be greater than three cards.");

            hand.CopyTo(_hand.ToArray(), 0);
            return _hand;
        }


        private ICollection<Card> createHand(ICollection<Card> hand)
        {
            if (hand.Count > 3)
                throw new ArgumentException($"Hand cannot be greater than three cards. Hand passed in contianed {hand.Count} cards.");

            hand.CopyTo(_hand.ToArray(), 0);

            return _hand;
        }
    }
}

