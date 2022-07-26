using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace teen_patti.data.postgres.Migrations
{
    public partial class currentPlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameStates_Player_CurrentPlayerId",
                schema: "TeenPatti",
                table: "GameStates");

            migrationBuilder.DropTable(
                name: "Card",
                schema: "TeenPatti");

            migrationBuilder.DropTable(
                name: "Player",
                schema: "TeenPatti");

            migrationBuilder.DropIndex(
                name: "IX_GameStates_CurrentPlayerId",
                schema: "TeenPatti",
                table: "GameStates");

            migrationBuilder.DropColumn(
                name: "CurrentPlayerId",
                schema: "TeenPatti",
                table: "GameStates");

            migrationBuilder.AddColumn<string>(
                name: "CurrentPlayer",
                schema: "TeenPatti",
                table: "GameStates",
                type: "jsonb",
                nullable: false,
                defaultValue: "{\"Id\":\"00000000-0000-0000-0000-000000000000\",\"Name\":null,\"Ordinal\":0,\"Hand\":[]}");

            migrationBuilder.UpdateData(
                schema: "TeenPatti",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a27bb201-7559-41a2-99fb-02b79346e4ca"),
                column: "CreateDateUTC",
                value: new DateTime(2022, 7, 25, 1, 33, 40, 851, DateTimeKind.Utc).AddTicks(99));

            migrationBuilder.UpdateData(
                schema: "TeenPatti",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ed3dd362-f975-40e9-a045-d0b9714b9b64"),
                column: "CreateDateUTC",
                value: new DateTime(2022, 7, 25, 1, 33, 40, 851, DateTimeKind.Utc).AddTicks(96));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentPlayer",
                schema: "TeenPatti",
                table: "GameStates");

            migrationBuilder.AddColumn<Guid>(
                name: "CurrentPlayerId",
                schema: "TeenPatti",
                table: "GameStates",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Player",
                schema: "TeenPatti",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Card",
                schema: "TeenPatti",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsVisible = table.Column<bool>(type: "boolean", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uuid", nullable: true),
                    Rank = table.Column<int>(type: "integer", nullable: false),
                    Suit = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Card_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalSchema: "TeenPatti",
                        principalTable: "Player",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                schema: "TeenPatti",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a27bb201-7559-41a2-99fb-02b79346e4ca"),
                column: "CreateDateUTC",
                value: new DateTime(2022, 7, 25, 0, 13, 28, 682, DateTimeKind.Utc).AddTicks(4740));

            migrationBuilder.UpdateData(
                schema: "TeenPatti",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ed3dd362-f975-40e9-a045-d0b9714b9b64"),
                column: "CreateDateUTC",
                value: new DateTime(2022, 7, 25, 0, 13, 28, 682, DateTimeKind.Utc).AddTicks(4738));

            migrationBuilder.CreateIndex(
                name: "IX_GameStates_CurrentPlayerId",
                schema: "TeenPatti",
                table: "GameStates",
                column: "CurrentPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_PlayerId",
                schema: "TeenPatti",
                table: "Card",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameStates_Player_CurrentPlayerId",
                schema: "TeenPatti",
                table: "GameStates",
                column: "CurrentPlayerId",
                principalSchema: "TeenPatti",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
