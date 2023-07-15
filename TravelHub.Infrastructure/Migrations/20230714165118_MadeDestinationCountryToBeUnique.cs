using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelHub.Infrastructure.Migrations
{
    public partial class MadeDestinationCountryToBeUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c4fa568-5033-40d9-8064-9db512d3de49",
                column: "ConcurrencyStamp",
                value: "ce6289c2-dd76-417f-90a3-5fce166b8830");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "613e9a9a-de45-4cec-8519-81625c7e603e",
                column: "ConcurrencyStamp",
                value: "25355ba4-1841-4b12-b401-dad5c2c85bad");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ac5688a2-417e-4a2d-973c-503b7c8eb951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4af79f3d-464d-4405-adfa-6e21278913dd", "AQAAAAEAACcQAAAAELGVFwe6fQGDjtoOCnCzwl6jpAuB+Uts1NVeFYzaP8N4U7jcRwq7eRiTLzXA6NikaA==", "495d7a3e-484f-4093-ab50-2b8157e6ec08" });

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_Country_Place",
                table: "Destinations",
                columns: new[] { "Country", "Place" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Destinations_Country_Place",
                table: "Destinations");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c4fa568-5033-40d9-8064-9db512d3de49",
                column: "ConcurrencyStamp",
                value: "eb7a88fe-1a8f-46d5-9c11-068a989dab46");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "613e9a9a-de45-4cec-8519-81625c7e603e",
                column: "ConcurrencyStamp",
                value: "65e5f5b2-a382-4ee9-886b-371e3c3996a5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ac5688a2-417e-4a2d-973c-503b7c8eb951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "af510c1d-4881-4486-b16c-f976616490ab", "AQAAAAEAACcQAAAAENGZ/Ie6UG58Kc/EhS5NndhBJTPCDbsIZzYwxibwbHZOqzk3bfkTkRWcbMXd6JKBJA==", "41b9766d-c879-4be2-8b3e-d0f232deb0b5" });
        }
    }
}
