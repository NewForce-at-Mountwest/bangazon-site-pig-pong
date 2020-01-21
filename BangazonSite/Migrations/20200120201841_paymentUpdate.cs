using Microsoft.EntityFrameworkCore.Migrations;

namespace BangazonSite.Migrations
{
    public partial class paymentUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f13c85d0-dff9-4803-b2ed-d3764c2d7371", "AQAAAAEAACcQAAAAELPQy92aZSv2Lg2iC+39pOvdmSH6VoUKhlS8nVhKnNvhKRxIjduoXB6E1oME9c8IUg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "43374cd9-c714-4b33-bdef-320bec0c6aeb", "AQAAAAEAACcQAAAAEL57C67YPi0lCIdTs52t9zLJiMDVvwSS0w7u1a7kFBBj7gOGbayxfCVTMRUUKorQsQ==" });
        }
    }
}
