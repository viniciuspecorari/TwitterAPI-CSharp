using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TwitterAPI.Migrations
{
    /// <inheritdoc />
    public partial class AjusteModelPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "85f136a9-2d07-47b1-8aa4-5e5dbec6eccf");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "8caa5e7f-530b-470a-a296-8a27f2ae6e76");

            migrationBuilder.AlterColumn<string>(
                name: "MediaUrl",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "58e2f064-12ca-4878-b2cb-512b5b1b9997", null, "User", "USER" },
                    { "ee38de2e-e937-4705-ba27-e030f2302c46", null, "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "58e2f064-12ca-4878-b2cb-512b5b1b9997");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "ee38de2e-e937-4705-ba27-e030f2302c46");

            migrationBuilder.AlterColumn<string>(
                name: "MediaUrl",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "85f136a9-2d07-47b1-8aa4-5e5dbec6eccf", null, "Administrator", "ADMINISTRATOR" },
                    { "8caa5e7f-530b-470a-a296-8a27f2ae6e76", null, "User", "USER" }
                });
        }
    }
}
