using Microsoft.EntityFrameworkCore.Migrations;

namespace BangazonSite.Migrations
{
    public partial class nullPmtTypeIdOnOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "31679dda-897c-4a79-b008-170bf26bb9cb", "AQAAAAEAACcQAAAAEO9Q9xYI3pdFAmnpVbXMbQsOYbl+aaymS7cPrTGCe8BUU05D4QycSvEtAiA7RpZ0PA==" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "PaymentTypeId",
                value: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5b2c98e7-e2c2-4c8b-8f67-4ecf71aa3f4e", "AQAAAAEAACcQAAAAEH+HnKSfdh9KLO/GocBIfKTbX1JSpokXq8ZfjKS+rep+f/cwjwcBhqqxrOpMcs5x4Q==" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "PaymentTypeId",
                value: 2);
        }
    }
}
