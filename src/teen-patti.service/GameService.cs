using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teen_patti.common.Models.Engine;
using teen_patti.common.Models.Persistence;
using teen_patti.common.Models.ViewModel;
using teen_patti.data.postgres;
using teen_patti.service.Interefaces;

namespace teen_patti.service
{
    public class GameService : IGameService
    {
        private readonly TeenPattiDbContext _dbContext;
        public GameService(TeenPattiDbContext dbContext) => _dbContext = dbContext;

        public async Task<common.Models.ViewModel.GameStateView> AddPlayer(Guid gameId, Guid playerId)
        {
            var game = await _dbContext.Games.Include(x => x.States).FirstOrDefaultAsync(x => x.Id == gameId);
            if (game == null)
                throw new ArgumentException("Game does not exist!");
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == playerId);
            if (user == null)
                throw new ArgumentException("Player does not exit!");

            //get latest game state
            var state = game.States.OrderByDescending(x => x.CreatedDateUTC).FirstOrDefault();
            if (state == null)
                throw new Exception($"Could not find states for game: {game.Id}");

            var currentPlayer = state.Players.FirstOrDefault(x => x.Id == state.CurrentPlayer.Id)?.MapToPlayer() ??
                throw new Exception("Current Player in state not found.");

            var gameState = new Builder()
                .MapFromPersistedState(state)
                .AddPlayer(user.MapToPlayer(currentPlayer.Ordinal + 1))
                .Build();
            await _dbContext.GameStates.AddAsync(gameState.MapToPersistence(game));
            await _dbContext.SaveChangesAsync();

            return gameState.MapToPlayerView();
        }

        public Task<common.Models.ViewModel.GameStateView> Bet(Guid gameId, Guid playerId)
        {
            throw new NotImplementedException();
        }

        public async Task<common.Models.ViewModel.GameStateView> Deal(Guid gameId, int handSize)
        {
            var game = await _dbContext.Games.Include(x => x.States).FirstOrDefaultAsync(x => x.Id == gameId);
            if (game == null)
                throw new ArgumentException("Game does not exist!");

            //get latest game state
            var state = game.States.OrderByDescending(x => x.CreatedDateUTC).FirstOrDefault();
            if (state == null)
                throw new Exception($"Could not find states for game: {game.Id}");

            var intiialState = new Builder()
                .MapFromPersistedState(state)
                .Build();

            var saveStates = new List<common.Models.Persistence.GameState>();

            var move = new Deal(intiialState);
            for(int i = 0; i < handSize; i++)
            {
                foreach (var player in intiialState.Players)
                {
                    var dealState = move.Execute();
                    saveStates.Add(dealState.MapToPersistence(game));
                    move = new Deal(dealState);
                }
            }

            await _dbContext.GameStates.AddRangeAsync(saveStates);
            await _dbContext.SaveChangesAsync();

            return saveStates.OrderByDescending(x => x.CreatedDateUTC).FirstOrDefault()?.MapToPlayerView() ?? new GameStateView();
        }

        public async Task<common.Models.ViewModel.GameStateView> GetState(Guid gameId, Guid playerId)
        {
            var game = await _dbContext.Games.Include(x => x.States).FirstOrDefaultAsync(x => x.Id == gameId);
            if (game == null)
                throw new ArgumentException("Game does not exist!");

            //get latest game state
            var state = game.States.OrderByDescending(x => x.CreatedDateUTC).FirstOrDefault();
            if (state == null)
                throw new Exception($"Could not find states for game: {game.Id}");

            var player = state.Players.FirstOrDefault(x => x.Id == playerId);
            if(player == null)
                throw new ArgumentException("Player does not exist in the game!");

            return state.MapToPlayerView();
        }

        public async Task<common.Models.ViewModel.GameStateView> InitializeGame(ICollection<CardView> deck, Guid playerId)
        {
            //Get player
            var player = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == playerId);
            if (player == null)
                throw new ArgumentException("Player does not exit!");

            //Create Game
            var game = new Game()
            {
                Id = Guid.NewGuid(),
                CreateDateUTC = DateTime.UtcNow,
            };

            var builder = new common.Models.Engine.Builder();
            builder
                .AddPlayer(player.MapToPlayer(1))
                .SetCurrentPlayer(player.MapToPlayer(1))
                .AssignDeck(deck.Select(x => x.MapToCard()).ToList().Shuffle());
            var gameState = builder.Build();

            var persitenceState = gameState.MapToPersistence(game);
            await _dbContext.Games.AddAsync(game);
            await _dbContext.GameStates.AddAsync(persitenceState);
            await _dbContext.SaveChangesAsync();
            return persitenceState.MapToPlayerView();
        }

        public async Task<GameStateView> SeeHand(Guid gameId, Guid playerId)
        {
            var game = await _dbContext.Games.Include(x => x.States).FirstOrDefaultAsync(x => x.Id == gameId);
            if (game == null)
                throw new ArgumentException("Game does not exist!");

            //get latest game state
            var persistedState = game.States.OrderByDescending(x => x.CreatedDateUTC).FirstOrDefault();
            if (persistedState == null)
                throw new Exception($"Could not find states for game: {game.Id}");

            var player = persistedState.Players.FirstOrDefault(x => x.Id == playerId);
            if (player == null)
                throw new ArgumentException("Player does not exist in the game!");

            var builder = new Builder()
                .MapFromPersistedState(persistedState);
            var state = builder.Build();

            var move = MoveFactory.CreateMove(state, nameof(SeeCards));

            state = move.Execute();

            var saveState = state.MapToPersistence(game);
            
            await _dbContext.GameStates.AddAsync(saveState);
            await _dbContext.SaveChangesAsync();

            return saveState.MapToPlayerView();
        }
    }

}
