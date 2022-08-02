using teen_patti.common.Models.Persistence;
using teen_patti.common.Models.ViewModel;

namespace teen_patti.common.Models.Engine
{
    public class Player
    {
        private readonly Guid _id;
        private readonly string _name;
        private readonly int _ordinal;
        private readonly long _currencyAmount;
        private IReadOnlyCollection<Card> _hand;

        public ICollection<Card> Hand { get => _hand.ToList(); }
        public Guid Id { get => _id; }
        public int Ordinal { get => _ordinal; }
        public string Name { get => _name; }
        public Player(Guid playerId, string name, ICollection<Card> hand, int ordinal)
        {
            _id = playerId;
            _name = name;
            _ordinal = ordinal;

            if (hand.Count > 3)
                throw new ArgumentException($"Hand cannot be greater than three cards. Hand passed in contianed {hand.Count} cards.");
            
            _hand = hand.ToList();
        }
        public Player(Persistence.User persistence, int ordinal)
        {
            _id = persistence.Id;
            _name = persistence.UserName;
            _ordinal = ordinal;
            _hand = new List<Card>();
        }
        public Player(Persistence.Player persistence)
        {
            _id = persistence.Id;
            _name = persistence.Name;
            _ordinal = persistence.Ordinal;
            _hand = persistence.Hand.Select(x => x.MapToCard()).ToList();
        }
    }
}

