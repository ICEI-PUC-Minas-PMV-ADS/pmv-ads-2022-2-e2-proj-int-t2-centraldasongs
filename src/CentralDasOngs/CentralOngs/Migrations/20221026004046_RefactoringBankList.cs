using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CentralOngs.Migrations
{
    public partial class RefactoringBankList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bank_account_banks_BankCode",
                table: "bank_account");

            migrationBuilder.RenameColumn(
                name: "BankCode",
                table: "bank_account",
                newName: "BankId");

            migrationBuilder.RenameIndex(
                name: "IX_bank_account_BankCode",
                table: "bank_account",
                newName: "IX_bank_account_BankId");

            migrationBuilder.AddForeignKey(
                name: "FK_bank_account_banks_BankId",
                table: "bank_account",
                column: "BankId",
                principalTable: "banks",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bank_account_banks_BankId",
                table: "bank_account");

            migrationBuilder.RenameColumn(
                name: "BankId",
                table: "bank_account",
                newName: "BankCode");

            migrationBuilder.RenameIndex(
                name: "IX_bank_account_BankId",
                table: "bank_account",
                newName: "IX_bank_account_BankCode");

            migrationBuilder.AddForeignKey(
                name: "FK_bank_account_banks_BankCode",
                table: "bank_account",
                column: "BankCode",
                principalTable: "banks",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
