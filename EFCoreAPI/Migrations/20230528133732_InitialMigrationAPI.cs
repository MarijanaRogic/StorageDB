using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreAPI.Migrations
{
    public partial class InitialMigrationAPI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "storage",
                columns: table => new
                {
                    StorageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KindOfStoragte = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_storage", x => x.StorageId);
                });

            migrationBuilder.CreateTable(
                name: "stateofstorage",
                columns: table => new
                {
                    StateOfStorageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StorageId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stateofstorage", x => x.StateOfStorageId);
                    table.ForeignKey(
                        name: "FK_stateofstorage_product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_stateofstorage_storage_StorageId",
                        column: x => x.StorageId,
                        principalTable: "storage",
                        principalColumn: "StorageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_stateofstorage_ProductId",
                table: "stateofstorage",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_stateofstorage_StorageId",
                table: "stateofstorage",
                column: "StorageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "stateofstorage");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "storage");
        }
    }
}
