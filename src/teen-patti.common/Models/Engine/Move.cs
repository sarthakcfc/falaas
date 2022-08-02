using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;
namespace teen_patti.common.Models.Engine
{
    public abstract class Move
    {
        protected Guid _id;
        protected readonly GameState _state;

        public GameState State { get => _state; }
        public Guid Id { get => _id; }
        public Move(GameState state) 
        {
            _id = Guid.NewGuid();
            _state = state;
        }

        public virtual GameState Execute()
        {
            Builder builder = new Builder();
            builder.SetMoveTransition(this);
            return builder.Build();
        }

        protected bool validateHands()
        {
            foreach (var player in _state.Players)
                if (player.Hand.Count < 3)
                    return false;
            return true;
        }
    }
    public sealed class Deal : Move
    {
        public Deal(GameState state) : base(state)
        {
        }
        public override GameState Execute()
        {
            Builder builder = new Builder();

            var deck = new Stack<Card>(_state.Deck);
            var players = _state.Players.ToList(); 
            var currentPlayer = _state.CurrentPlayer;
            
            var hand = currentPlayer.Hand;
            hand.Add(deck.Pop());
            var newPlayer = new Player(currentPlayer.Id, currentPlayer.Name, hand, currentPlayer.Ordinal);
            
            players[newPlayer.Ordinal - 1] = newPlayer;

            builder.SetCurrentPlayer(_state.GetNextPlayer())
                .SetDeck(deck.ToList())
                .SetPlayers(players)
                .SetMoveTransition(this);
            
            return builder.Build();
        }
    }
    public sealed class Bet : Move
    {
        public Bet(GameState state) : base(state)
        {
        }
        public override GameState Execute() => throw new InvalidOperationException("Cannot execute a Bet move without a bet!");

        public GameState Execute(long betAmount)
        {
            if(!validateHands())
                throw new InvalidOperationException("Cannot Make a bet without first dealing all the cards!");
            if(!validateBet(betAmount))
                throw new InvalidOperationException($"The attemted bet amount of {betAmount} is less than the current bet amount {_state.CurrentBetAmount}!");

            Builder builder = new Builder();

            var deck = new Stack<Card>(_state.Deck);
            var players = _state.Players.ToList();
            var currentPlayer = _state.CurrentPlayer;

            //Decrease currency amount from player
            var newPlayer = new Player(currentPlayer.Id, 
                currentPlayer.Name, 
                currentPlayer.Hand, 
                currentPlayer.Ordinal);
            players[newPlayer.Ordinal - 1] = newPlayer;

            //Add to pot amount with the builder
            builder.SetCurrentPlayer(_state.GetNextPlayer())
                .SetDeck(deck.ToList())
                .SetPlayers(players)
                .SetMoveTransition(this)
                .SetPotAmount(_state.PotAmount + betAmount)
                .SetBetAmount(betAmount);

            return builder.Build();
        }
        private bool validateBet(long betAmount) => betAmount < State.CurrentBetAmount; 
    }
    public sealed class SeeCards : Move
    {
        public SeeCards(GameState state) : base(state)
        {
        }
        public override GameState Execute()
        {
            Builder builder = new Builder();

            var deck = new Stack<Card>(_state.Deck);
            var players = _state.Players.ToList();
            var currentPlayer = _state.CurrentPlayer;

            var hand = currentPlayer.Hand;

            foreach (var card in hand)
                card.IsVisible = true;

            var newPlayer = new Player(currentPlayer.Id, currentPlayer.Name, hand, currentPlayer.Ordinal);

            players[newPlayer.Ordinal - 1] = newPlayer;


            //builder assignments
            builder.SetCurrentPlayer(_state.CurrentPlayer)
                .SetDeck(deck.ToList())
                .SetPlayers(players)
                .SetMoveTransition(this);
            return builder.Build();

        }
    }
    public sealed class NullMove : Move
    {
        public NullMove(GameState state) : base(state)
        {
        }
        public override GameState Execute()
        {
            throw new InvalidOperationException("Cannot execute a null move");
        }
    }
}
