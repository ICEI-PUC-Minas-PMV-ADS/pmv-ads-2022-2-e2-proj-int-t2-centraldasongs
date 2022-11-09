using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CentralOngs.Migrations
{
    public partial class ChangeStateKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressModel_UFs_StateId",
                table: "AddressModel");

            migrationBuilder.RenameColumn(
                name: "UF",
                table: "UFs",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "StateId",
                table: "AddressModel",
                newName: "StateName");

            migrationBuilder.RenameIndex(
                name: "IX_AddressModel_StateId",
                table: "AddressModel",
                newName: "IX_AddressModel_StateName");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressModel_UFs_StateName",
                table: "AddressModel",
                column: "StateName",
                principalTable: "UFs",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressModel_UFs_StateName",
                table: "AddressModel");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "UFs",
                newName: "UF");

            migrationBuilder.RenameColumn(
                name: "StateName",
                table: "AddressModel",
                newName: "StateId");

            migrationBuilder.RenameIndex(
                name: "IX_AddressModel_StateName",
                table: "AddressModel",
                newName: "IX_AddressModel_StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressModel_UFs_StateId",
                table: "AddressModel",
                column: "StateId",
                principalTable: "UFs",
                principalColumn: "UF",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
