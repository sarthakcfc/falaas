using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace teen_patti.common
{
    public sealed class GameState
    {
        /// <summary>
        /// Private declarations
        /// </summary>
        private readonly IReadOnlyCollection<Card> _deck;
        private readonly IReadOnlyCollection<Player> _players;
        private readonly Player _currentPlayer;
        private readonly Move _transitionMove;


        /// <summary>
        /// Public properties
        /// </summary>
        public Player CurrentPlayer { get => _currentPlayer; }
        public Move TransitionMove { get => _transitionMove; }
        public ICollection<Card> Deck { get => _deck.ToList(); }
        public ICollection<Player> Players { get => _players.ToList(); }

        public GameState(GameStateView view)
        {
            this._deck = view.Deck.ToList();
            this._players = view.Players.ToList();
            this._transitionMove = view.TransitionMove ?? MoveFactory.GetNullMove();
            this._currentPlayer = view.CurrentPlayer ?? throw new Exception("Current Player does not exist!");
        }
        /// <summary>
        /// Consturctor
        /// </summary>
        /// <param name="builder"></param>
        public GameState(Builder builder)
        {
            this._deck = builder.Deck.ToList();
            this._players = builder.Players.ToList();
            this._transitionMove = builder.TransitionMove ?? MoveFactory.GetNullMove();
            this._currentPlayer = builder.CurrentPlayer;
        }

        public Player GetNextPlayer() =>
            _players?.FirstOrDefault(x => x.Ordinal == (_currentPlayer.Ordinal == _players.Count ? 1 : _currentPlayer.Ordinal + 1)) ?? throw new Exception("There are no players");


        /// <summary>
        /// Overrides
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            //stringBuilder.Append($"Deck Count: {this._deck.Count} \n");
            //stringBuilder.Append("Deck \n");
            //foreach(var card in this._deck)
            //    stringBuilder.Append(card.ToString() + "\n");
            stringBuilder.Append("Player Hands \n");
            foreach(var player in this._players)
                foreach(var card in player.Hand)
                    stringBuilder.Append($"Player {player.Ordinal}: " + card.ToString() + "\n");
            return stringBuilder.ToString();
        }
    }
}
