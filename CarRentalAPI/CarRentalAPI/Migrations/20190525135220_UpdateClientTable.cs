using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentalAPI.Migrations
{
    public partial class UpdateClientTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(name: "Client", schema: "dbo", newName: "Clients", newSchema: "dbo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(name: "Clients", schema: "dbo", newName: "Client", newSchema: "dbo");
        }
    }
}
