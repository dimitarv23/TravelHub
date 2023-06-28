﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelHub.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Destinations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Place = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    FoodService = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasPool = table.Column<bool>(type: "bit", nullable: false),
                    HasSpa = table.Column<bool>(type: "bit", nullable: false),
                    DestinationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotels_Destinations_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Destinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DestinationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Destinations_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Destinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Travels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaxNumberOfPeople = table.Column<int>(type: "int", nullable: false),
                    DestinationId = table.Column<int>(type: "int", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Travels_Destinations_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Destinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Travels_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TravelId = table.Column<int>(type: "int", nullable: false),
                    BookDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => new { x.UserId, x.TravelId });
                    table.ForeignKey(
                        name: "FK_Bookings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Travels_TravelId",
                        column: x => x.TravelId,
                        principalTable: "Travels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4c4fa568-5033-40d9-8064-9db512d3de49", "0b9ed84e-0bb5-47b9-aa5a-02d2fbbbd29f", "User", "USER" },
                    { "613e9a9a-de45-4cec-8519-81625c7e603e", "2f6a706d-9b3f-4c06-a410-deb4549e2d28", "Organizer", "ORGANIZER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ac5688a2-417e-4a2d-973c-503b7c8eb951", 0, "bc2d9f57-5621-480a-8d9c-952c9b3d02c3", "User", "organizer@email.com", false, "Organizer", "Organizer", false, null, "ORGANIZER@EMAIL.COM", "ORGANIZER1", "AQAAAAEAACcQAAAAEEevn2sFcJRNeD9CtSb05T08VGEneqR8+9axex9VS053vV75FJRdYiUO8P/qKUSanQ==", null, false, "3e392b56-2cac-4d50-9578-1d7f444b729a", false, "Organizer1" });

            migrationBuilder.InsertData(
                table: "Destinations",
                columns: new[] { "Id", "Country", "Currency", "ImageUrl", "Place" },
                values: new object[,]
                {
                    { 1, "Bulgaria", "BGN", "https://i2-prod.mylondon.news/incoming/article26617964.ece/ALTERNATES/s615b/1_GettyImages-1312067182.jpg", "Sunny Beach" },
                    { 2, "Bulgaria", "BGN", "https://freesofiatour.com/wp-content/uploads/2018/05/seven-rila-lakes-how-to-get-to-1200x675.jpeg", "The Seven Rila Lakes" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "613e9a9a-de45-4cec-8519-81625c7e603e", "ac5688a2-417e-4a2d-973c-503b7c8eb951" });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "DestinationId", "FoodService", "HasPool", "HasSpa", "ImageUrl", "Name", "Rating" },
                values: new object[,]
                {
                    { 1, 1, "AllInclusive", true, true, "https://cf.bstatic.com/xdata/images/hotel/max1024x768/340492725.jpg?k=e27fd2bc7277de6b6794b15d1d258441ecb5e85929edc499bff3cb69e8742779&o=&hp=1", "Diamant Residence", 4 },
                    { 2, 1, "UltraAllInclusive", true, true, "https://cf.bstatic.com/xdata/images/hotel/max1024x768/60906632.jpg?k=845e3aa0d06eba8ca8a546425f6100f8b9609e836228d3c3966d45607b4807cb&o=&hp=1", "Effect Grand Victoria Hotel", 4 }
                });

            migrationBuilder.InsertData(
                table: "Travels",
                columns: new[] { "Id", "DateFrom", "DateTo", "Description", "DestinationId", "HotelId", "MaxNumberOfPeople", "Price", "Type" },
                values: new object[] { 3, new DateTime(2023, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "A mountain hike to gorgeous Seven Rila Lakes. We are starting our trip at 8AM on 02/07/2023 and will be back in town around 5PM on the same day. Come with us to enjoy the beauty of our bulgarian nature!", 2, null, 40, 30m, "MountainVacation" });

            migrationBuilder.InsertData(
                table: "Travels",
                columns: new[] { "Id", "DateFrom", "DateTo", "Description", "DestinationId", "HotelId", "MaxNumberOfPeople", "Price", "Type" },
                values: new object[] { 1, new DateTime(2023, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "A vacation on sunny beach for 6 days for a great amount of money! The bus leaves at 4AM on 03/07/2023 and we will be back in town at around 7PM on 08/07/2023. Come and party with us!", 1, 1, 58, 780m, "BeachVacation" });

            migrationBuilder.InsertData(
                table: "Travels",
                columns: new[] { "Id", "DateFrom", "DateTo", "Description", "DestinationId", "HotelId", "MaxNumberOfPeople", "Price", "Type" },
                values: new object[] { 2, new DateTime(2023, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "A vacation on sunny beach for 6 days for a great amount of money! The bus leaves at 4AM on 10/07/2023 and we will be back in town at around 7PM on 16/07/2023. Come and party with us!", 1, 2, 62, 820m, "BeachVacation" });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_TravelId",
                table: "Bookings",
                column: "TravelId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_DestinationId",
                table: "Hotels",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_DestinationId",
                table: "Reviews",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Travels_DestinationId",
                table: "Travels",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Travels_HotelId",
                table: "Travels",
                column: "HotelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Travels");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "Destinations");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c4fa568-5033-40d9-8064-9db512d3de49");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "613e9a9a-de45-4cec-8519-81625c7e603e", "ac5688a2-417e-4a2d-973c-503b7c8eb951" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "613e9a9a-de45-4cec-8519-81625c7e603e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ac5688a2-417e-4a2d-973c-503b7c8eb951");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");
        }
    }
}
