using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using teen_patti.common.Models.Persistence;

namespace teen_patti.common.Models.Engine
{
    public class Builder
    {
        private ICollection<Card> _deck;
        private ICollection<Player> _players;
        private Move _transitionMove;
        private Player _currentPlayer;
        private Guid _gameId;
        private long _potAmount;
        private long _currentBetAmount;

        public ICollection<Card> Deck { get => _deck; }
        public ICollection<Player> Players { get => _players; }
        public Move TransitionMove { get => _transitionMove; }
        public Player CurrentPlayer { get => _currentPlayer; }
        public Guid GameId { get => _gameId; }
        public long PotAmount { get => _potAmount; }
        public long CurrentBetAmount { get => _currentBetAmount; }
        public Builder()
        {
            _deck = new List<Card>();
            _players = new List<Player>();
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
        public Builder SetGame(Guid gameId)
        {
            _gameId = gameId;
            return this;
        }
        public Builder SetPotAmount(long potAmount)
        {
            _potAmount = potAmount;
            return this;
        }
        public Builder SetBetAmount(long betAmount)
        {
            _currentBetAmount = betAmount;
            return this;
        }

        public GameState Build()
        {
            return new GameState(this);
        }

        public Builder MapFromPersistedState(Persistence.GameState state)
        {
            var currentPlayer = state.Players.FirstOrDefault(x => x.Id == state.CurrentPlayer.Id)?.MapToPlayer() ??
                throw new Exception("Current Player in state not found.");

            this.AssignDeck(state.Deck.Select(x => x.MapToCard()).ToList())
                .SetPlayers(state.Players.Select(x => x.MapToPlayer()).ToList())
                .SetGame(state.GameId)
                .SetPotAmount(state.PotAmount)
                .SetBetAmount(state.CurrentBetAmount)
                .SetCurrentPlayer(currentPlayer);

            return this;
        }
    }
}
