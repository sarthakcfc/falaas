using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public async Task<Guid> InitializeGame(ICollection<CardView> deck, Guid playerId)
        {
            //Get player
            var player = _dbContext.Players.FirstOrDefault(x => x.Id == playerId);
            if (player == null)
                throw new Exception("Player does not exit!");

            //Create Game
            var game = new Game()
            {
                Id = Guid.NewGuid(),
                CreateDateUTC = DateTime.UtcNow,
            };

            var builder = new common.Models.Engine.Builder();
            builder
                .AddPlayer(player.MapToPlayer(1))
                .AssignDeck(deck.Select(x => x.MapToCart()).ToList().Shuffle());
            var gameState = builder.Build();
            var persitenceState = gameState.MapToPersistence(game);
            _dbContext.Games.Add(game);
            _dbContext.GameStates.Add(persitenceState);
            _dbContext.SaveChangesAsync();
            return game.Id;
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
