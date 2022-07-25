using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace teen_patti.data.postgres.Migrations
{
    public partial class playername : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "TeenPatti",
                table: "Player",
                type: "text",
                nullable: false,
                defaultValue: "");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                schema: "TeenPatti",
                table: "Player");

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
        }
    }
}
