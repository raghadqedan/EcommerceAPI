using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class first_migrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocalUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocalUserId = table.Column<int>(type: "int", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_LocalUsers_LocalUserId",
                        column: x => x.LocalUserId,
                        principalTable: "LocalUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdersDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersDetails", x => new { x.OrderId, x.Id, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrdersDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdersDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Devices and gadgets", "Electronics" },
                    { 2, "Books and literature", "Books" },
                    { 3, "Apparel and accessories", "Clothing" }
                });

            migrationBuilder.InsertData(
                table: "LocalUsers",
                columns: new[] { "Id", "Name", "Password", "Phone", "Role", "UserName" },
                values: new object[,]
                {
                    { 1, "Ahmed Haggag", "password123", null, "Admin", "Haggag281" },
                    { 2, "Tarek Sharim", "password456", null, "User", "Tarek777" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "LocalUserId", "OrderDate", "OrderStatus" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending" },
                    { 2, 2, new DateTime(2023, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 3, 1, new DateTime(2023, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shipped" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "smartphone.jpg", "Smartphone", 299.99m },
                    { 2, 1, "laptop.jpg", "Laptop", 799.99m },
                    { 3, 2, "novel.jpg", "Novel", 19.99m },
                    { 4, 3, "tshirt.jpg", "T-Shirt", 9.99m },
                    { 5, 3, "jeans.jpg", "Jeans", 49.99m }
                });

            migrationBuilder.InsertData(
                table: "OrdersDetails",
                columns: new[] { "Id", "OrderId", "ProductId", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 299.99m, 1m },
                    { 2, 1, 4, 9.99m, 2m },
                    { 3, 2, 3, 19.99m, 1m },
                    { 4, 3, 2, 799.99m, 1m },
                    { 5, 3, 5, 9.99m, 1m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_LocalUserId",
                table: "Orders",
                column: "LocalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersDetails_ProductId",
                table: "OrdersDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdersDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "LocalUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
