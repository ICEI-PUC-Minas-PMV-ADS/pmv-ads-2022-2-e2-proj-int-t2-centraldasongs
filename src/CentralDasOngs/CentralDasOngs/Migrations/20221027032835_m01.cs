using Microsoft.EntityFrameworkCore.Migrations;

namespace CentralDasOngs.Migrations
{
    public partial class m01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HouseNumber",
                table: "Address",
                newName: "Number");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Address",
                newName: "HouseNumber");
        }
    }
}
