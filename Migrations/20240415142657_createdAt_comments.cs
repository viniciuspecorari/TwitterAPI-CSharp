using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TwitterAPI.Migrations
{
    /// <inheritdoc />
    public partial class createdAt_comments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "58e2f064-12ca-4878-b2cb-512b5b1b9997");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "ee38de2e-e937-4705-ba27-e030f2302c46");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "306e9307-86aa-46b4-a1ab-70760d472529", null, "Administrator", "ADMINISTRATOR" },
                    { "7e6f89f6-a367-498a-91a9-38cd78db9140", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "306e9307-86aa-46b4-a1ab-70760d472529");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "7e6f89f6-a367-498a-91a9-38cd78db9140");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Comments");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "58e2f064-12ca-4878-b2cb-512b5b1b9997", null, "User", "USER" },
                    { "ee38de2e-e937-4705-ba27-e030f2302c46", null, "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
