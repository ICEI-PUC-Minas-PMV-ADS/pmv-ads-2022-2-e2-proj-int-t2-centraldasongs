using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CentralOngs.Migrations
{
    public partial class RemovingRequireds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_UFs_StateId",
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
                name: "IX_Address_StateId",
                table: "AddressModel",
                newName: "IX_AddressModel_StateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddressModel",
                table: "AddressModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressModel_UFs_StateId",
                table: "AddressModel",
                column: "StateId",
                principalTable: "UFs",
                principalColumn: "UF",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AddressModel_UserModel_UserId",
                table: "AddressModel",
                column: "UserId",
                principalTable: "UserModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressModel_UFs_StateId",
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
                name: "IX_AddressModel_StateId",
                table: "Address",
                newName: "IX_Address_StateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_UFs_StateId",
                table: "Address",
                column: "StateId",
                principalTable: "UFs",
                principalColumn: "UF",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_UserModel_UserId",
                table: "Address",
                column: "UserId",
                principalTable: "UserModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
