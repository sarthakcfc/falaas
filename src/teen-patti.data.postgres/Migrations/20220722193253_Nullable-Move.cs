using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace teen_patti.data.postgres.Migrations
{
    public partial class NullableMove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "TeenPatti",
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("a27bb201-7559-41a2-99fb-02b79346e4ca"),
                column: "CreateDateUTC",
                value: new DateTime(2022, 7, 22, 19, 32, 53, 379, DateTimeKind.Utc).AddTicks(144));

            migrationBuilder.UpdateData(
                schema: "TeenPatti",
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("ed3dd362-f975-40e9-a045-d0b9714b9b64"),
                column: "CreateDateUTC",
                value: new DateTime(2022, 7, 22, 19, 32, 53, 379, DateTimeKind.Utc).AddTicks(140));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "TeenPatti",
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("a27bb201-7559-41a2-99fb-02b79346e4ca"),
                column: "CreateDateUTC",
                value: new DateTime(2022, 7, 22, 16, 51, 29, 571, DateTimeKind.Utc).AddTicks(3371));

            migrationBuilder.UpdateData(
                schema: "TeenPatti",
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("ed3dd362-f975-40e9-a045-d0b9714b9b64"),
                column: "CreateDateUTC",
                value: new DateTime(2022, 7, 22, 16, 51, 29, 571, DateTimeKind.Utc).AddTicks(3368));
        }
    }
}
