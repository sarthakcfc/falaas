using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace teen_patti.data.postgres.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "TeenPatti");

            migrationBuilder.CreateTable(
                name: "Games",
                schema: "TeenPatti",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateDateUTC = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Move",
                schema: "TeenPatti",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MoveType = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Move", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                schema: "TeenPatti",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    CurrencyAmount = table.Column<long>(type: "bigint", nullable: false),
                    CreateDateUTC = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                schema: "TeenPatti",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SenderId = table.Column<Guid>(type: "uuid", nullable: false),
                    ReceiverId = table.Column<Guid>(type: "uuid", nullable: false),
                    SenderType = table.Column<string>(type: "text", nullable: false),
                    TimeStampUTC = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Amount = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameStates",
                schema: "TeenPatti",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GameId = table.Column<Guid>(type: "uuid", nullable: false),
                    CurrentPlayerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Hands = table.Column<string>(type: "jsonb", nullable: false),
                    Deck = table.Column<string>(type: "jsonb", nullable: false),
                    TransitionMoveId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDateUTC = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameStates_Games_GameId",
                        column: x => x.GameId,
                        principalSchema: "TeenPatti",
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameStates_Move_TransitionMoveId",
                        column: x => x.TransitionMoveId,
                        principalSchema: "TeenPatti",
                        principalTable: "Move",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameStates_GameId",
                schema: "TeenPatti",
                table: "GameStates",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameStates_TransitionMoveId",
                schema: "TeenPatti",
                table: "GameStates",
                column: "TransitionMoveId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameStates",
                schema: "TeenPatti");

            migrationBuilder.DropTable(
                name: "Players",
                schema: "TeenPatti");

            migrationBuilder.DropTable(
                name: "Transactions",
                schema: "TeenPatti");

            migrationBuilder.DropTable(
                name: "Games",
                schema: "TeenPatti");

            migrationBuilder.DropTable(
                name: "Move",
                schema: "TeenPatti");
        }
    }
}
