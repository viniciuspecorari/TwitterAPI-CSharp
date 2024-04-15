using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TwitterAPI.Migrations
{
    /// <inheritdoc />
    public partial class createdAt_like : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "306e9307-86aa-46b4-a1ab-70760d472529");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "7e6f89f6-a367-498a-91a9-38cd78db9140");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Likes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "196cc165-5974-4f0e-9cd0-5b447c84fdfd", null, "User", "USER" },
                    { "c0c9d537-cea4-4f6e-86c5-e3944b680459", null, "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "196cc165-5974-4f0e-9cd0-5b447c84fdfd");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "c0c9d537-cea4-4f6e-86c5-e3944b680459");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Likes");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "306e9307-86aa-46b4-a1ab-70760d472529", null, "Administrator", "ADMINISTRATOR" },
                    { "7e6f89f6-a367-498a-91a9-38cd78db9140", null, "User", "USER" }
                });
        }
    }
}
