using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace teen_patti.data.postgres.Migrations
{
    public partial class currencysupport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CurrentBetAmount",
                schema: "TeenPatti",
                table: "GameStates",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "PotAmount",
                schema: "TeenPatti",
                table: "GameStates",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                schema: "TeenPatti",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a27bb201-7559-41a2-99fb-02b79346e4ca"),
                column: "CreateDateUTC",
                value: new DateTime(2022, 8, 2, 2, 20, 17, 328, DateTimeKind.Utc).AddTicks(1936));

            migrationBuilder.UpdateData(
                schema: "TeenPatti",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ed3dd362-f975-40e9-a045-d0b9714b9b64"),
                column: "CreateDateUTC",
                value: new DateTime(2022, 8, 2, 2, 20, 17, 328, DateTimeKind.Utc).AddTicks(1932));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentBetAmount",
                schema: "TeenPatti",
                table: "GameStates");

            migrationBuilder.DropColumn(
                name: "PotAmount",
                schema: "TeenPatti",
                table: "GameStates");

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
    }
}
