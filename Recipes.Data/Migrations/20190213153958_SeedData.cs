using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Recipes.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Created", "Modified", "Name", "Rating" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 2, 13, 15, 39, 58, 112, DateTimeKind.Local).AddTicks(9051), new DateTime(2019, 2, 13, 15, 39, 58, 121, DateTimeKind.Local).AddTicks(2690), "Chilli Con Carne", 3.0 },
                    { 2, new DateTime(2019, 2, 13, 15, 39, 58, 121, DateTimeKind.Local).AddTicks(4573), new DateTime(2019, 2, 13, 15, 39, 58, 121, DateTimeKind.Local).AddTicks(4590), "Spagetti Bolognese", 5.0 },
                    { 3, new DateTime(2019, 2, 13, 15, 39, 58, 121, DateTimeKind.Local).AddTicks(4611), new DateTime(2019, 2, 13, 15, 39, 58, 121, DateTimeKind.Local).AddTicks(4635), "Chicken Tikka Masala", 4.5 },
                    { 4, new DateTime(2019, 2, 13, 15, 39, 58, 121, DateTimeKind.Local).AddTicks(4639), new DateTime(2019, 2, 13, 15, 39, 58, 121, DateTimeKind.Local).AddTicks(4644), "Sausage Casserole", 4.2000000000000002 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
