﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using teen_patti.data.postgres;

#nullable disable

namespace teen_patti.data.postgres.Migrations
{
    [DbContext(typeof(TeenPattiDbContext))]
    [Migration("20220722151342_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("TeenPatti")
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

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

                    b.Property<string>("Hands")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<Guid?>("TransitionMoveId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("TransitionMoveId");

                    b.ToTable("GameStates", "TeenPatti");
                });

            modelBuilder.Entity("teen_patti.common.Models.Persistence.Move", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("MoveType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Move", "TeenPatti");
                });

            modelBuilder.Entity("teen_patti.common.Models.Persistence.Player", b =>
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

                    b.ToTable("Players", "TeenPatti");
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

            modelBuilder.Entity("teen_patti.common.Models.Persistence.GameState", b =>
                {
                    b.HasOne("teen_patti.common.Models.Persistence.Game", null)
                        .WithMany("States")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("teen_patti.common.Models.Persistence.Move", "TransitionMove")
                        .WithMany()
                        .HasForeignKey("TransitionMoveId");

                    b.Navigation("TransitionMove");
                });

            modelBuilder.Entity("teen_patti.common.Models.Persistence.Game", b =>
                {
                    b.Navigation("States");
                });
#pragma warning restore 612, 618
        }
    }
}