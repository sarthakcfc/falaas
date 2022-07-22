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
        protected readonly Guid _id;
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
            var newPlayer = new Player(currentPlayer.Id, hand, currentPlayer.Ordinal);
            
            players[newPlayer.Ordinal - 1] = newPlayer;

            builder.SetCurrentPlayer(_state.GetNextPlayer());
            builder.SetDeck(deck.ToList());
            builder.SetPlayers(players);
            builder.SetMoveTransition(this);
            
            return builder.Build();
        }
    }
    public sealed class BlindBet : Move
    {
        public BlindBet(GameState state) : base(state)
        {
        }
    }
    public sealed class SeenBet : Move
    {
        public SeenBet(GameState state) : base(state)
        {
        }
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

            var newPlayer = new Player(currentPlayer.Id, hand, currentPlayer.Ordinal);

            players[newPlayer.Ordinal - 1] = newPlayer;


            //builder assignments
            builder.SetCurrentPlayer(_state.GetNextPlayer());
            builder.SetDeck(deck.ToList());
            builder.SetPlayers(players);
            builder.SetMoveTransition(this);
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
    public static class MoveFactory
    {
        internal static Move GetNullMove(GameState state)
        {
            return new NullMove(state);
        }

        public static Move CreateMove(GameState state, string input = "")
        {
            //Validate that Every player has 3 cards per hand else keep dealing
            if(String.IsNullOrEmpty(input))
                return new Deal(state);

            switch (input)
            {
                case "S":
                case "s":
                    return new SeeCards(state);
                default:
                    throw new ArgumentException("Invalid Input");
            }
            //Calculate possible moves for player
        }
    }
}
