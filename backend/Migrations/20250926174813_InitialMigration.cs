using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
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
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Stock = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, "Description for product 1", null, "Product 1", 10m, 2 },
                    { 2, "Description for product 2", null, "Product 2", 20m, 4 },
                    { 3, "Description for product 3", null, "Product 3", 30m, 6 },
                    { 4, "Description for product 4", null, "Product 4", 40m, 8 },
                    { 5, "Description for product 5", null, "Product 5", 50m, 10 },
                    { 6, "Description for product 6", null, "Product 6", 60m, 12 },
                    { 7, "Description for product 7", null, "Product 7", 70m, 14 },
                    { 8, "Description for product 8", null, "Product 8", 80m, 16 },
                    { 9, "Description for product 9", null, "Product 9", 90m, 18 },
                    { 10, "Description for product 10", null, "Product 10", 100m, 20 },
                    { 11, "Description for product 11", null, "Product 11", 110m, 22 },
                    { 12, "Description for product 12", null, "Product 12", 120m, 24 },
                    { 13, "Description for product 13", null, "Product 13", 130m, 26 },
                    { 14, "Description for product 14", null, "Product 14", 140m, 28 },
                    { 15, "Description for product 15", null, "Product 15", 150m, 30 },
                    { 16, "Description for product 16", null, "Product 16", 160m, 32 },
                    { 17, "Description for product 17", null, "Product 17", 170m, 34 },
                    { 18, "Description for product 18", null, "Product 18", 180m, 36 },
                    { 19, "Description for product 19", null, "Product 19", 190m, 38 },
                    { 20, "Description for product 20", null, "Product 20", 200m, 40 },
                    { 21, "Description for product 21", null, "Product 21", 210m, 42 },
                    { 22, "Description for product 22", null, "Product 22", 220m, 44 },
                    { 23, "Description for product 23", null, "Product 23", 230m, 46 },
                    { 24, "Description for product 24", null, "Product 24", 240m, 48 },
                    { 25, "Description for product 25", null, "Product 25", 250m, 50 },
                    { 26, "Description for product 26", null, "Product 26", 260m, 52 },
                    { 27, "Description for product 27", null, "Product 27", 270m, 54 },
                    { 28, "Description for product 28", null, "Product 28", 280m, 56 },
                    { 29, "Description for product 29", null, "Product 29", 290m, 58 },
                    { 30, "Description for product 30", null, "Product 30", 300m, 60 },
                    { 31, "Description for product 31", null, "Product 31", 310m, 62 },
                    { 32, "Description for product 32", null, "Product 32", 320m, 64 },
                    { 33, "Description for product 33", null, "Product 33", 330m, 66 },
                    { 34, "Description for product 34", null, "Product 34", 340m, 68 },
                    { 35, "Description for product 35", null, "Product 35", 350m, 70 },
                    { 36, "Description for product 36", null, "Product 36", 360m, 72 },
                    { 37, "Description for product 37", null, "Product 37", 370m, 74 },
                    { 38, "Description for product 38", null, "Product 38", 380m, 76 },
                    { 39, "Description for product 39", null, "Product 39", 390m, 78 },
                    { 40, "Description for product 40", null, "Product 40", 400m, 80 },
                    { 41, "Description for product 41", null, "Product 41", 410m, 82 },
                    { 42, "Description for product 42", null, "Product 42", 420m, 84 },
                    { 43, "Description for product 43", null, "Product 43", 430m, 86 },
                    { 44, "Description for product 44", null, "Product 44", 440m, 88 },
                    { 45, "Description for product 45", null, "Product 45", 450m, 90 },
                    { 46, "Description for product 46", null, "Product 46", 460m, 92 },
                    { 47, "Description for product 47", null, "Product 47", 470m, 94 },
                    { 48, "Description for product 48", null, "Product 48", 480m, 96 },
                    { 49, "Description for product 49", null, "Product 49", 490m, 98 },
                    { 50, "Description for product 50", null, "Product 50", 500m, 100 }
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

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
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
