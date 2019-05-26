using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentalAPI.Migrations
{
    public partial class CarDataAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "Cost", "Description", "ImageUrl" },
                values: new object[] { 1, "test1", 31.0, "Simple description1", "Url1" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "Cost", "Description", "ImageUrl" },
                values: new object[] { 2, "test2", 32.0, "Simple description2", "Url2" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "Cost", "Description", "ImageUrl" },
                values: new object[] { 3, "test3", 33.0, "Simple description3", "Url3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
