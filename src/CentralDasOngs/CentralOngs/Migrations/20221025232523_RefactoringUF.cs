using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CentralOngs.Migrations
{
    public partial class RefactoringUF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_address_UF_StateUF",
                table: "address");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UF",
                table: "UF");

            migrationBuilder.RenameTable(
                name: "UF",
                newName: "UFs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UFs",
                table: "UFs",
                column: "UF");

            migrationBuilder.AddForeignKey(
                name: "FK_address_UFs_StateUF",
                table: "address",
                column: "StateUF",
                principalTable: "UFs",
                principalColumn: "UF",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_address_UFs_StateUF",
                table: "address");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UFs",
                table: "UFs");

            migrationBuilder.RenameTable(
                name: "UFs",
                newName: "UF");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UF",
                table: "UF",
                column: "UF");

            migrationBuilder.AddForeignKey(
                name: "FK_address_UF_StateUF",
                table: "address",
                column: "StateUF",
                principalTable: "UF",
                principalColumn: "UF",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
