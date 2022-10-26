using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CentralOngs.Migrations
{
    public partial class RefactoringUFwIdAndForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_address_UFs_StateId",
                table: "address");

            migrationBuilder.DropIndex(
                name: "IX_address_StateId",
                table: "address");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "address");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "address",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_address_State",
                table: "address",
                column: "State");

            migrationBuilder.AddForeignKey(
                name: "FK_address_UFs_State",
                table: "address",
                column: "State",
                principalTable: "UFs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_address_UFs_State",
                table: "address");

            migrationBuilder.DropIndex(
                name: "IX_address_State",
                table: "address");

            migrationBuilder.DropColumn(
                name: "State",
                table: "address");

            migrationBuilder.AddColumn<string>(
                name: "StateId",
                table: "address",
                type: "text",
                nullable: true);

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
    }
}
