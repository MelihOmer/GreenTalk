using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GreenTalk.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "Username" },
                values: new object[,]
                {
                    { new Guid("c792249f-db81-4cf6-99a8-614720e9250d"), "tugba@mail.com", "654321", "tugba.kamar" },
                    { new Guid("e56f6d4c-b396-42d3-bdd5-109e1d519aa4"), "melih@mail.com", "123456", "melih.kamar" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c792249f-db81-4cf6-99a8-614720e9250d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e56f6d4c-b396-42d3-bdd5-109e1d519aa4"));
        }
    }
}
