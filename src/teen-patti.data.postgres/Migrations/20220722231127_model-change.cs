using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace teen_patti.data.postgres.Migrations
{
    public partial class modelchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players",
                schema: "TeenPatti");

            migrationBuilder.RenameColumn(
                name: "Hands",
                schema: "TeenPatti",
                table: "GameStates",
                newName: "Players");

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
                    { new Guid("a27bb201-7559-41a2-99fb-02b79346e4ca"), new DateTime(2022, 7, 22, 23, 11, 27, 619, DateTimeKind.Utc).AddTicks(8712), 1200L, "sarthak.khatiwada" },
                    { new Guid("ed3dd362-f975-40e9-a045-d0b9714b9b64"), new DateTime(2022, 7, 22, 23, 11, 27, 619, DateTimeKind.Utc).AddTicks(8708), 1200L, "aayush.pokharel" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users",
                schema: "TeenPatti");

            migrationBuilder.RenameColumn(
                name: "Players",
                schema: "TeenPatti",
                table: "GameStates",
                newName: "Hands");

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

            migrationBuilder.InsertData(
                schema: "TeenPatti",
                table: "Players",
                columns: new[] { "Id", "CreateDateUTC", "CurrencyAmount", "UserName" },
                values: new object[,]
                {
                    { new Guid("a27bb201-7559-41a2-99fb-02b79346e4ca"), new DateTime(2022, 7, 22, 19, 32, 53, 379, DateTimeKind.Utc).AddTicks(144), 1200L, "sarthak.khatiwada" },
                    { new Guid("ed3dd362-f975-40e9-a045-d0b9714b9b64"), new DateTime(2022, 7, 22, 19, 32, 53, 379, DateTimeKind.Utc).AddTicks(140), 1200L, "aayush.pokharel" }
                });
        }
    }
}
