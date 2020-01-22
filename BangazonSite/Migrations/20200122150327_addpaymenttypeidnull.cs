using Microsoft.EntityFrameworkCore.Migrations;

namespace BangazonSite.Migrations
{
    public partial class addpaymenttypeidnull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_PaymentTypes_PaymentTypeId",
                table: "Orders");

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

            migrationBuilder.AlterColumn<int>(
                name: "PaymentTypeId",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "47e5f751-e238-4b39-84fb-780412c5bdbd", "AQAAAAEAACcQAAAAEDT+7KKnWbik20tVsi4ls9BCPcq+rzlLiY9btvUHr8TJmwn4bQaqXRHIS+oMh9P5HA==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_PaymentTypes_PaymentTypeId",
                table: "Orders",
                column: "PaymentTypeId",
                principalTable: "PaymentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_PaymentTypes_PaymentTypeId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "GroupedProductsId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PaymentTypeId",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ProductTypesViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCount = table.Column<int>(type: "int", nullable: false),
                    ProductTypesViewModelId = table.Column<int>(type: "int", nullable: true),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "FK_Orders_PaymentTypes_PaymentTypeId",
                table: "Orders",
                column: "PaymentTypeId",
                principalTable: "PaymentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_GroupedProducts_GroupedProductsId",
                table: "Products",
                column: "GroupedProductsId",
                principalTable: "GroupedProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
