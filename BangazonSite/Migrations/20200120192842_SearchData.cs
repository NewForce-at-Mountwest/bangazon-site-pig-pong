using Microsoft.EntityFrameworkCore.Migrations;

namespace BangazonSite.Migrations
{
    public partial class SearchData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Products",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ae6711dc-2f21-43a5-89df-345b2a9004bc", "AQAAAAEAACcQAAAAEKcMT27sLLSLO2MSkyYMGmFqNWB2xgmotd+OxlHu/Um35uk0JeLXEqSM0kMufGcBXA==" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductId",
                table: "Products",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Products_ProductId",
                table: "Products",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Products_ProductId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductId",
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
