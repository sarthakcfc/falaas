using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace teen_patti.data.postgres.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "TeenPatti",
                table: "Players",
                columns: new[] { "Id", "CreateDateUTC", "CurrencyAmount", "UserName" },
                values: new object[,]
                {
                    { new Guid("a27bb201-7559-41a2-99fb-02b79346e4ca"), new DateTime(2022, 7, 22, 16, 51, 29, 571, DateTimeKind.Utc).AddTicks(3371), 1200L, "sarthak.khatiwada" },
                    { new Guid("ed3dd362-f975-40e9-a045-d0b9714b9b64"), new DateTime(2022, 7, 22, 16, 51, 29, 571, DateTimeKind.Utc).AddTicks(3368), 1200L, "aayush.pokharel" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "TeenPatti",
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("a27bb201-7559-41a2-99fb-02b79346e4ca"));

            migrationBuilder.DeleteData(
                schema: "TeenPatti",
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("ed3dd362-f975-40e9-a045-d0b9714b9b64"));
        }
    }
}
