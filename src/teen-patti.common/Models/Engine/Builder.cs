using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace teen_patti.common.Models.Engine
{
    public class Builder
    {
        private ICollection<Card> _deck;
        private ICollection<Player> _players;
        private Move _transitionMove;
        private Player _currentPlayer;

        public ICollection<Card> Deck { get => _deck; }
        public ICollection<Player> Players { get => _players; }
        public Move TransitionMove { get => _transitionMove; }
        public Player CurrentPlayer { get => _currentPlayer; }

        public Builder InitDeck(Func<ICollection<Card>> deckBuilder)
        {
            this._deck = deckBuilder();
            return this;
        }
        public Builder AssignDeck(ICollection<Card> deck)
        {
            this._deck = deck;
            return this;
        }
        public Builder SetDeck(ICollection<Card> deck)
        {
            _deck = deck;
            return this;
        }
        public Builder SetPlayers(ICollection<Player> players)
        {
            _players = players;
            return this;
        }
        public Builder AddPlayer(Player player)
        {
            _players.Add(player);
            return this;
        }
        public Builder SetCurrentPlayer(Player player)
        {
            _currentPlayer = player;
            return this;
        }
        public Builder SetMoveTransition(Move move)
        {
            _transitionMove = move;
            return this;
        }

        public GameState Build()
        {
            return new GameState(this);
        }
    }
}
