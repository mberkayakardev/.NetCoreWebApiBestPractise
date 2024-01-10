using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AkarSoftware.ApiBestPractise.Repository.Migrations
{
    /// <inheritdoc />
    public partial class InitalCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategori", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Urunler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urunler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Urunler_Kategori_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Kategori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductFeatures_Urunler_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Urunler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Kategori",
                columns: new[] { "Id", "CategoryName", "CreatedDate", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Kalemler", new DateTime(2024, 1, 10, 4, 52, 47, 6, DateTimeKind.Local).AddTicks(5472), new DateTime(2024, 1, 10, 4, 52, 47, 6, DateTimeKind.Local).AddTicks(5487) },
                    { 2, "Kitaplar", new DateTime(2024, 1, 10, 4, 52, 47, 6, DateTimeKind.Local).AddTicks(5489), new DateTime(2024, 1, 10, 4, 52, 47, 6, DateTimeKind.Local).AddTicks(5489) },
                    { 3, "Defterler", new DateTime(2024, 1, 10, 4, 52, 47, 6, DateTimeKind.Local).AddTicks(5490), new DateTime(2024, 1, 10, 4, 52, 47, 6, DateTimeKind.Local).AddTicks(5491) }
                });

            migrationBuilder.InsertData(
                table: "Urunler",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Name", "Price", "Stock", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 1, 10, 4, 52, 47, 6, DateTimeKind.Local).AddTicks(5709), "Kalem1", 100m, 20, new DateTime(2024, 1, 10, 4, 52, 47, 6, DateTimeKind.Local).AddTicks(5710) },
                    { 2, 2, new DateTime(2024, 1, 10, 4, 52, 47, 6, DateTimeKind.Local).AddTicks(5715), "Kalem2", 150m, 120, new DateTime(2024, 1, 10, 4, 52, 47, 6, DateTimeKind.Local).AddTicks(5715) },
                    { 3, 3, new DateTime(2024, 1, 10, 4, 52, 47, 6, DateTimeKind.Local).AddTicks(5717), "Kalem3", 150m, 120, new DateTime(2024, 1, 10, 4, 52, 47, 6, DateTimeKind.Local).AddTicks(5717) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductFeatures_ProductId",
                table: "ProductFeatures",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Urunler_CategoryId",
                table: "Urunler",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductFeatures");

            migrationBuilder.DropTable(
                name: "Urunler");

            migrationBuilder.DropTable(
                name: "Kategori");
        }
    }
}
