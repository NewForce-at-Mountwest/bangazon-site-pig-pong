using Microsoft.EntityFrameworkCore.Migrations;

namespace BangazonSite.Migrations
{
    public partial class groupedproductsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupedProductsId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductTypesViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypesViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupedProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(nullable: true),
                    ProductCount = table.Column<int>(nullable: false),
                    ProductTypesViewModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupedProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupedProducts_ProductTypesViewModel_ProductTypesViewModelId",
                        column: x => x.ProductTypesViewModelId,
                        principalTable: "ProductTypesViewModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "47dd6f11-83d9-4422-ad8e-08bf8a4ba03f", "AQAAAAEAACcQAAAAENtZtC4UGPQjt99fcNHF7+C6XH4Znjw+N6B3CoE6MaG0Q3eBuXB8hyWWlL1GUnY1rw==" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_GroupedProductsId",
                table: "Products",
                column: "GroupedProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupedProducts_ProductTypesViewModelId",
                table: "GroupedProducts",
                column: "ProductTypesViewModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_GroupedProducts_GroupedProductsId",
                table: "Products",
                column: "GroupedProductsId",
                principalTable: "GroupedProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_GroupedProducts_GroupedProductsId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "GroupedProducts");

            migrationBuilder.DropTable(
                name: "ProductTypesViewModel");

            migrationBuilder.DropIndex(
                name: "IX_Products_GroupedProductsId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "GroupedProductsId",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "43374cd9-c714-4b33-bdef-320bec0c6aeb", "AQAAAAEAACcQAAAAEL57C67YPi0lCIdTs52t9zLJiMDVvwSS0w7u1a7kFBBj7gOGbayxfCVTMRUUKorQsQ==" });
        }
    }
}
