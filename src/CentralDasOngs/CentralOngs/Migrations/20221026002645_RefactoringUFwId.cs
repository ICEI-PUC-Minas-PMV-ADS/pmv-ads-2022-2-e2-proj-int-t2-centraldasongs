using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CentralOngs.Migrations
{
    public partial class RefactoringUFwId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_address_UFs_StateUF",
                table: "address");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UFs",
                table: "UFs");

            migrationBuilder.DropIndex(
                name: "IX_address_StateUF",
                table: "address");

            migrationBuilder.DropColumn(
                name: "StateUF",
                table: "address");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "UFs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StateId",
                table: "address",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UFs",
                table: "UFs",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_address_StateId",
                table: "address",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_address_UFs_StateId",
                table: "address",
                column: "StateId",
                principalTable: "UFs",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_address_UFs_StateId",
                table: "address");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UFs",
                table: "UFs");

            migrationBuilder.DropIndex(
                name: "IX_address_StateId",
                table: "address");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UFs");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "address");

            migrationBuilder.AddColumn<string>(
                name: "StateUF",
                table: "address",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UFs",
                table: "UFs",
                column: "UF");

            migrationBuilder.CreateIndex(
                name: "IX_address_StateUF",
                table: "address",
                column: "StateUF");

            migrationBuilder.AddForeignKey(
                name: "FK_address_UFs_StateUF",
                table: "address",
                column: "StateUF",
                principalTable: "UFs",
                principalColumn: "UF",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
