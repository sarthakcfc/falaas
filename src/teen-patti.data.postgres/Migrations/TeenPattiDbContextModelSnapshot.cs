﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using teen_patti.data.postgres;

#nullable disable

namespace teen_patti.data.postgres.Migrations
{
    [DbContext(typeof(TeenPattiDbContext))]
    partial class TeenPattiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("TeenPatti")
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("teen_patti.common.Models.Persistence.Card", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsVisible")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("PlayerId")
                        .HasColumnType("uuid");

                    b.Property<int>("Rank")
                        .HasColumnType("integer");

                    b.Property<int>("Suit")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("Card", "TeenPatti");
                });

            modelBuilder.Entity("teen_patti.common.Models.Persistence.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDateUTC")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Games", "TeenPatti");
                });

            modelBuilder.Entity("teen_patti.common.Models.Persistence.GameState", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDateUTC")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CurrentPlayerId")
                        .HasColumnType("uuid");

                    b.Property<string>("Deck")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uuid");

                    b.Property<string>("Players")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<string>("TransitionMove")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("jsonb")
                        .HasDefaultValue("{\"Id\":\"00000000-0000-0000-0000-000000000000\",\"MoveType\":null}");

                    b.HasKey("Id");

                    b.HasIndex("CurrentPlayerId");

                    b.HasIndex("GameId");

                    b.ToTable("GameStates", "TeenPatti");
                });

            modelBuilder.Entity("teen_patti.common.Models.Persistence.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Ordinal")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Player", "TeenPatti");
                });

            modelBuilder.Entity("teen_patti.common.Models.Persistence.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<long>("Amount")
                        .HasColumnType("bigint");

                    b.Property<Guid>("ReceiverId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("uuid");

                    b.Property<string>("SenderType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("TimeStampUTC")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Transactions", "TeenPatti");
                });

            modelBuilder.Entity("teen_patti.common.Models.Persistence.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDateUTC")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("CurrencyAmount")
                        .HasColumnType("bigint");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users", "TeenPatti");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ed3dd362-f975-40e9-a045-d0b9714b9b64"),
                            CreateDateUTC = new DateTime(2022, 7, 25, 0, 13, 28, 682, DateTimeKind.Utc).AddTicks(4738),
                            CurrencyAmount = 1200L,
                            UserName = "aayush.pokharel"
                        },
                        new
                        {
                            Id = new Guid("a27bb201-7559-41a2-99fb-02b79346e4ca"),
                            CreateDateUTC = new DateTime(2022, 7, 25, 0, 13, 28, 682, DateTimeKind.Utc).AddTicks(4740),
                            CurrencyAmount = 1200L,
                            UserName = "sarthak.khatiwada"
                        });
                });

            modelBuilder.Entity("teen_patti.common.Models.Persistence.Card", b =>
                {
                    b.HasOne("teen_patti.common.Models.Persistence.Player", null)
                        .WithMany("Hand")
                        .HasForeignKey("PlayerId");
                });

            modelBuilder.Entity("teen_patti.common.Models.Persistence.GameState", b =>
                {
                    b.HasOne("teen_patti.common.Models.Persistence.Player", "CurrentPlayer")
                        .WithMany()
                        .HasForeignKey("CurrentPlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("teen_patti.common.Models.Persistence.Game", null)
                        .WithMany("States")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurrentPlayer");
                });

            modelBuilder.Entity("teen_patti.common.Models.Persistence.Game", b =>
                {
                    b.Navigation("States");
                });

            modelBuilder.Entity("teen_patti.common.Models.Persistence.Player", b =>
                {
                    b.Navigation("Hand");
                });
#pragma warning restore 612, 618
        }
    }
}
