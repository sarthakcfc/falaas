using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace teen_patti.data.postgres.Migrations
{
    public partial class cardhandling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Player",
                schema: "TeenPatti",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
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
                    Rank = table.Column<int>(type: "integer", nullable: false),
                    Suit = table.Column<int>(type: "integer", nullable: false),
                    IsVisible = table.Column<bool>(type: "boolean", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uuid", nullable: true)
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
                value: new DateTime(2022, 7, 24, 22, 48, 23, 931, DateTimeKind.Utc).AddTicks(3768));

            migrationBuilder.UpdateData(
                schema: "TeenPatti",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ed3dd362-f975-40e9-a045-d0b9714b9b64"),
                column: "CreateDateUTC",
                value: new DateTime(2022, 7, 24, 22, 48, 23, 931, DateTimeKind.Utc).AddTicks(3766));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                schema: "TeenPatti",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a27bb201-7559-41a2-99fb-02b79346e4ca"),
                column: "CreateDateUTC",
                value: new DateTime(2022, 7, 23, 1, 32, 46, 429, DateTimeKind.Utc).AddTicks(7316));

            migrationBuilder.UpdateData(
                schema: "TeenPatti",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ed3dd362-f975-40e9-a045-d0b9714b9b64"),
                column: "CreateDateUTC",
                value: new DateTime(2022, 7, 23, 1, 32, 46, 429, DateTimeKind.Utc).AddTicks(7313));
        }
    }
}
