using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, "Description for product 1", "Product 1", 10m, 2 },
                    { 2, "Description for product 2", "Product 2", 20m, 4 },
                    { 3, "Description for product 3", "Product 3", 30m, 6 },
                    { 4, "Description for product 4", "Product 4", 40m, 8 },
                    { 5, "Description for product 5", "Product 5", 50m, 10 },
                    { 6, "Description for product 6", "Product 6", 60m, 12 },
                    { 7, "Description for product 7", "Product 7", 70m, 14 },
                    { 8, "Description for product 8", "Product 8", 80m, 16 },
                    { 9, "Description for product 9", "Product 9", 90m, 18 },
                    { 10, "Description for product 10", "Product 10", 100m, 20 },
                    { 11, "Description for product 11", "Product 11", 110m, 22 },
                    { 12, "Description for product 12", "Product 12", 120m, 24 },
                    { 13, "Description for product 13", "Product 13", 130m, 26 },
                    { 14, "Description for product 14", "Product 14", 140m, 28 },
                    { 15, "Description for product 15", "Product 15", 150m, 30 },
                    { 16, "Description for product 16", "Product 16", 160m, 32 },
                    { 17, "Description for product 17", "Product 17", 170m, 34 },
                    { 18, "Description for product 18", "Product 18", 180m, 36 },
                    { 19, "Description for product 19", "Product 19", 190m, 38 },
                    { 20, "Description for product 20", "Product 20", 200m, 40 },
                    { 21, "Description for product 21", "Product 21", 210m, 42 },
                    { 22, "Description for product 22", "Product 22", 220m, 44 },
                    { 23, "Description for product 23", "Product 23", 230m, 46 },
                    { 24, "Description for product 24", "Product 24", 240m, 48 },
                    { 25, "Description for product 25", "Product 25", 250m, 50 },
                    { 26, "Description for product 26", "Product 26", 260m, 52 },
                    { 27, "Description for product 27", "Product 27", 270m, 54 },
                    { 28, "Description for product 28", "Product 28", 280m, 56 },
                    { 29, "Description for product 29", "Product 29", 290m, 58 },
                    { 30, "Description for product 30", "Product 30", 300m, 60 },
                    { 31, "Description for product 31", "Product 31", 310m, 62 },
                    { 32, "Description for product 32", "Product 32", 320m, 64 },
                    { 33, "Description for product 33", "Product 33", 330m, 66 },
                    { 34, "Description for product 34", "Product 34", 340m, 68 },
                    { 35, "Description for product 35", "Product 35", 350m, 70 },
                    { 36, "Description for product 36", "Product 36", 360m, 72 },
                    { 37, "Description for product 37", "Product 37", 370m, 74 },
                    { 38, "Description for product 38", "Product 38", 380m, 76 },
                    { 39, "Description for product 39", "Product 39", 390m, 78 },
                    { 40, "Description for product 40", "Product 40", 400m, 80 },
                    { 41, "Description for product 41", "Product 41", 410m, 82 },
                    { 42, "Description for product 42", "Product 42", 420m, 84 },
                    { 43, "Description for product 43", "Product 43", 430m, 86 },
                    { 44, "Description for product 44", "Product 44", 440m, 88 },
                    { 45, "Description for product 45", "Product 45", 450m, 90 },
                    { 46, "Description for product 46", "Product 46", 460m, 92 },
                    { 47, "Description for product 47", "Product 47", 470m, 94 },
                    { 48, "Description for product 48", "Product 48", 480m, 96 },
                    { 49, "Description for product 49", "Product 49", 490m, 98 },
                    { 50, "Description for product 50", "Product 50", 500m, 100 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "pass1", "user1" },
                    { 2, "pass2", "user2" },
                    { 3, "pass3", "user3" },
                    { 4, "pass4", "user4" },
                    { 5, "pass5", "user5" },
                    { 6, "pass6", "user6" },
                    { 7, "pass7", "user7" },
                    { 8, "pass8", "user8" },
                    { 9, "pass9", "user9" },
                    { 10, "pass10", "user10" },
                    { 11, "pass11", "user11" },
                    { 12, "pass12", "user12" },
                    { 13, "pass13", "user13" },
                    { 14, "pass14", "user14" },
                    { 15, "pass15", "user15" },
                    { 16, "pass16", "user16" },
                    { 17, "pass17", "user17" },
                    { 18, "pass18", "user18" },
                    { 19, "pass19", "user19" },
                    { 20, "pass20", "user20" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
