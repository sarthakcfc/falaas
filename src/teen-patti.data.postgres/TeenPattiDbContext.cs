using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teen_patti.data.postgres
{
    public class TeenPattiDbContext : DbContext
    {
        public TeenPattiDbContext(DbContextOptions<TeenPattiDbContext> options) : base(options)
        {
        }

        public DbSet<common.Models.Persistence.Player> Players { get; set; }
        public DbSet<common.Models.Persistence.Game> Games { get; set; }
        public DbSet<common.Models.Persistence.GameState> GameStates { get; set; }
        public DbSet<common.Models.Persistence.Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder) => builder.UseNpgsql("Server=localhost;Port=5432;UserId=postgres;Password=123prasad//;Pooling=false;Database=GamblingDB");

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Schema
            builder.HasDefaultSchema("TeenPatti");

            //Entities
            builder.Entity<common.Models.Persistence.Game>()
                .HasKey(x => x.Id);
            builder.Entity<common.Models.Persistence.GameState>()
                .HasKey(x => x.Id);
            builder.Entity<common.Models.Persistence.GameState>()
                .HasIndex(x => x.GameId);
            builder.Entity<common.Models.Persistence.Player>()
                .HasKey(x => x.Id);
            builder.Entity<common.Models.Persistence.Transaction>()
                .HasKey(x => x.Id);

            base.OnModelCreating(builder);


        }
    }
}
