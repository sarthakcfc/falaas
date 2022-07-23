using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace teen_patti.data.postgres.Migrations
{
    public partial class jsonandseeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameStates_Move_TransitionMoveId",
                schema: "TeenPatti",
                table: "GameStates");

            migrationBuilder.DropTable(
                name: "Move",
                schema: "TeenPatti");

            migrationBuilder.DropTable(
                name: "Players",
                schema: "TeenPatti");

            migrationBuilder.DropIndex(
                name: "IX_GameStates_TransitionMoveId",
                schema: "TeenPatti",
                table: "GameStates");

            migrationBuilder.DropColumn(
                name: "TransitionMoveId",
                schema: "TeenPatti",
                table: "GameStates");

            migrationBuilder.RenameColumn(
                name: "Hands",
                schema: "TeenPatti",
                table: "GameStates",
                newName: "Players");

            migrationBuilder.AddColumn<string>(
                name: "TransitionMove",
                schema: "TeenPatti",
                table: "GameStates",
                type: "jsonb",
                nullable: false,
                defaultValue: "{\"Id\":\"00000000-0000-0000-0000-000000000000\",\"MoveType\":null}");

            migrationBuilder.CreateTable(
                name: "Users",
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
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "TeenPatti",
                table: "Users",
                columns: new[] { "Id", "CreateDateUTC", "CurrencyAmount", "UserName" },
                values: new object[,]
                {
                    { new Guid("a27bb201-7559-41a2-99fb-02b79346e4ca"), new DateTime(2022, 7, 23, 1, 32, 46, 429, DateTimeKind.Utc).AddTicks(7316), 1200L, "sarthak.khatiwada" },
                    { new Guid("ed3dd362-f975-40e9-a045-d0b9714b9b64"), new DateTime(2022, 7, 23, 1, 32, 46, 429, DateTimeKind.Utc).AddTicks(7313), 1200L, "aayush.pokharel" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users",
                schema: "TeenPatti");

            migrationBuilder.DropColumn(
                name: "TransitionMove",
                schema: "TeenPatti",
                table: "GameStates");

            migrationBuilder.RenameColumn(
                name: "Players",
                schema: "TeenPatti",
                table: "GameStates",
                newName: "Hands");

            migrationBuilder.AddColumn<Guid>(
                name: "TransitionMoveId",
                schema: "TeenPatti",
                table: "GameStates",
                type: "uuid",
                nullable: true);

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
                    CreateDateUTC = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CurrencyAmount = table.Column<long>(type: "bigint", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameStates_TransitionMoveId",
                schema: "TeenPatti",
                table: "GameStates",
                column: "TransitionMoveId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameStates_Move_TransitionMoveId",
                schema: "TeenPatti",
                table: "GameStates",
                column: "TransitionMoveId",
                principalSchema: "TeenPatti",
                principalTable: "Move",
                principalColumn: "Id");
        }
    }
}
