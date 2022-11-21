using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CentralOngs.Migrations
{
    public partial class hanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressModel_UFs_StateName",
                table: "AddressModel");

            migrationBuilder.DropForeignKey(
                name: "FK_AddressModel_UserModel_UserId",
                table: "AddressModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddressModel",
                table: "AddressModel");

            migrationBuilder.RenameTable(
                name: "AddressModel",
                newName: "Address");

            migrationBuilder.RenameIndex(
                name: "IX_AddressModel_UserId",
                table: "Address",
                newName: "IX_Address_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AddressModel_StateName",
                table: "Address",
                newName: "IX_Address_StateName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_UFs_StateName",
                table: "Address",
                column: "StateName",
                principalTable: "UFs",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_UserModel_UserId",
                table: "Address",
                column: "UserId",
                principalTable: "UserModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_UFs_StateName",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_UserModel_UserId",
                table: "Address");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "AddressModel");

            migrationBuilder.RenameIndex(
                name: "IX_Address_UserId",
                table: "AddressModel",
                newName: "IX_AddressModel_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Address_StateName",
                table: "AddressModel",
                newName: "IX_AddressModel_StateName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddressModel",
                table: "AddressModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressModel_UFs_StateName",
                table: "AddressModel",
                column: "StateName",
                principalTable: "UFs",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AddressModel_UserModel_UserId",
                table: "AddressModel",
                column: "UserId",
                principalTable: "UserModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
