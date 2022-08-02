using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace teen_patti.data.postgres
{
    public class TeenPattiDbContext : DbContext
    {
        public TeenPattiDbContext(DbContextOptions<TeenPattiDbContext> options) : base(options)
        {
        }

        public DbSet<common.Models.Persistence.User> Users { get; set; }
        public DbSet<common.Models.Persistence.Game> Games { get; set; }
        public DbSet<common.Models.Persistence.GameState> GameStates { get; set; }
        public DbSet<common.Models.Persistence.Transaction> Transactions { get; set; }

        /// <summary>
        /// TODO Use app settings for this
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder builder) => builder.UseNpgsql("Server=localhost;Port=5432;UserId=postgres;Password=123prasad//;Pooling=false;Database=GamblingDB;IncludeErrorDetail=true;");

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
            builder.Entity<common.Models.Persistence.User>()
                .HasKey(x => x.Id);
            builder.Entity<common.Models.Persistence.Transaction>()
                .HasKey(x => x.Id);

            //JSON Serialization
            builder.Entity<common.Models.Persistence.GameState>()
                .Property(x => x.Deck).HasJsonConversion();
            builder.Entity<common.Models.Persistence.GameState>()
                .Property(x => x.Players).HasJsonConversion();
            builder.Entity<common.Models.Persistence.GameState>()
                .Property(x => x.CurrentPlayer).HasJsonConversion()
                .HasDefaultValue(new common.Models.Persistence.Player());
            builder.Entity<common.Models.Persistence.GameState>()
                .Property(x => x.TransitionMove).HasJsonConversion()
                .HasDefaultValue(new common.Models.Persistence.Move());

            //Seed player Data. TODO Remove this in the future once we have real players
            builder.Entity<common.Models.Persistence.User>().HasData(new common.Models.Persistence.User()
            {
                Id = Guid.Parse("ed3dd362-f975-40e9-a045-d0b9714b9b64"),
                CurrencyAmount = 1200,
                CreateDateUTC = DateTime.UtcNow,
                UserName = "aayush.pokharel"
            },
            new common.Models.Persistence.User()
            {
                Id = Guid.Parse("a27bb201-7559-41a2-99fb-02b79346e4ca"),
                CurrencyAmount = 1200,
                CreateDateUTC = DateTime.UtcNow,
                UserName = "sarthak.khatiwada"
            });

            base.OnModelCreating(builder);


        }
    }
    public static class ValueConversionExtensions
    {
        public static PropertyBuilder<T> HasJsonConversion<T>(this PropertyBuilder<T> propertyBuilder) where T : class, new()
        {
            var options = new JsonSerializerOptions()
            {
                AllowTrailingCommas = true
            };
            ValueConverter<T, string> converter = new ValueConverter<T, string>
            (
                v => JsonSerializer.Serialize(v, options),
                v => JsonSerializer.Deserialize<T>(v, options) ?? new T()
            );

            ValueComparer<T> comparer = new ValueComparer<T>
            (
                (l, r) => JsonSerializer.Serialize(l, options) == JsonSerializer.Serialize(r, options),
                v => v == null ? 0 : JsonSerializer.Serialize(v, options).GetHashCode(),
                v => JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(v, options), options)
            );

            propertyBuilder.HasConversion(converter);
            propertyBuilder.Metadata.SetValueConverter(converter);
            propertyBuilder.Metadata.SetValueComparer(comparer);
            propertyBuilder.HasColumnType("jsonb");

            return propertyBuilder;
        }
    }
}
