using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CentralOngs.Migrations
{
    public partial class Refactoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_address_ufs_State",
                table: "address");

            migrationBuilder.DropForeignKey(
                name: "FK_address_user_voluntario_UserVoluntarioId",
                table: "address");

            migrationBuilder.DropForeignKey(
                name: "FK_address_UserOngModel_UserOngId",
                table: "address");

            migrationBuilder.DropForeignKey(
                name: "FK_bank_account_banks_BankId",
                table: "bank_account");

            migrationBuilder.DropForeignKey(
                name: "FK_bank_account_UserOngModel_UserOngId",
                table: "bank_account");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_voluntario",
                table: "user_voluntario");

            migrationBuilder.DropIndex(
                name: "IX_bank_account_BankId",
                table: "bank_account");

            migrationBuilder.DropIndex(
                name: "IX_bank_account_UserOngId",
                table: "bank_account");

            migrationBuilder.DropIndex(
                name: "IX_address_State",
                table: "address");

            migrationBuilder.DropIndex(
                name: "IX_address_UserOngId",
                table: "address");

            migrationBuilder.DropIndex(
                name: "IX_address_UserVoluntarioId",
                table: "address");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserOngModel",
                table: "UserOngModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ufs",
                table: "ufs");

            migrationBuilder.DropColumn(
                name: "BankId",
                table: "bank_account");

            migrationBuilder.DropColumn(
                name: "UserOngId",
                table: "bank_account");

            migrationBuilder.DropColumn(
                name: "HouseNumber",
                table: "address");

            migrationBuilder.DropColumn(
                name: "State",
                table: "address");

            migrationBuilder.DropColumn(
                name: "UserOngId",
                table: "address");

            migrationBuilder.DropColumn(
                name: "UserVoluntarioId",
                table: "address");

            migrationBuilder.RenameTable(
                name: "UserOngModel",
                newName: "user_ong");

            migrationBuilder.RenameTable(
                name: "ufs",
                newName: "UF");

            migrationBuilder.RenameColumn(
                name: "Uf",
                table: "UF",
                newName: "UF");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateBirthDay",
                table: "user_voluntario",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "user_voluntario",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "user_voluntario",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Contact",
                table: "user_voluntario",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "user_voluntario",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "user_voluntario",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "user_voluntario",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserType",
                table: "user_voluntario",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "banks",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AlterColumn<int>(
                name: "Code",
                table: "banks",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Branch",
                table: "bank_account",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AccountType",
                table: "bank_account",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "AccountNumber",
                table: "bank_account",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "bank_account",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "BankCode",
                table: "bank_account",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "address",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AlterColumn<string>(
                name: "District",
                table: "address",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AlterColumn<string>(
                name: "Complement",
                table: "address",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "address",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "address",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "address",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StateUF",
                table: "address",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "UserType",
                table: "user_ong",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "user_ong",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "user_ong",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "user_ong",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AlterColumn<string>(
                name: "Contact",
                table: "user_ong",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "user_ong",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "user_ong",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BankAccountId",
                table: "user_ong",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UF",
                table: "UF",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_voluntario",
                table: "user_voluntario",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_ong",
                table: "user_ong",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UF",
                table: "UF",
                column: "UF");

            migrationBuilder.CreateIndex(
                name: "IX_user_voluntario_AddressId",
                table: "user_voluntario",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_bank_account_BankCode",
                table: "bank_account",
                column: "BankCode");

            migrationBuilder.CreateIndex(
                name: "IX_address_StateUF",
                table: "address",
                column: "StateUF");

            migrationBuilder.CreateIndex(
                name: "IX_user_ong_AddressId",
                table: "user_ong",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_user_ong_BankAccountId",
                table: "user_ong",
                column: "BankAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_address_UF_StateUF",
                table: "address",
                column: "StateUF",
                principalTable: "UF",
                principalColumn: "UF",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_bank_account_banks_BankCode",
                table: "bank_account",
                column: "BankCode",
                principalTable: "banks",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_ong_address_AddressId",
                table: "user_ong",
                column: "AddressId",
                principalTable: "address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_ong_bank_account_BankAccountId",
                table: "user_ong",
                column: "BankAccountId",
                principalTable: "bank_account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_voluntario_address_AddressId",
                table: "user_voluntario",
                column: "AddressId",
                principalTable: "address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_address_UF_StateUF",
                table: "address");

            migrationBuilder.DropForeignKey(
                name: "FK_bank_account_banks_BankCode",
                table: "bank_account");

            migrationBuilder.DropForeignKey(
                name: "FK_user_ong_address_AddressId",
                table: "user_ong");

            migrationBuilder.DropForeignKey(
                name: "FK_user_ong_bank_account_BankAccountId",
                table: "user_ong");

            migrationBuilder.DropForeignKey(
                name: "FK_user_voluntario_address_AddressId",
                table: "user_voluntario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_voluntario",
                table: "user_voluntario");

            migrationBuilder.DropIndex(
                name: "IX_user_voluntario_AddressId",
                table: "user_voluntario");

            migrationBuilder.DropIndex(
                name: "IX_bank_account_BankCode",
                table: "bank_account");

            migrationBuilder.DropIndex(
                name: "IX_address_StateUF",
                table: "address");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_ong",
                table: "user_ong");

            migrationBuilder.DropIndex(
                name: "IX_user_ong_AddressId",
                table: "user_ong");

            migrationBuilder.DropIndex(
                name: "IX_user_ong_BankAccountId",
                table: "user_ong");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UF",
                table: "UF");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "user_voluntario");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "user_voluntario");

            migrationBuilder.DropColumn(
                name: "Contact",
                table: "user_voluntario");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "user_voluntario");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "user_voluntario");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "user_voluntario");

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "user_voluntario");

            migrationBuilder.DropColumn(
                name: "BankCode",
                table: "bank_account");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "address");

            migrationBuilder.DropColumn(
                name: "StateUF",
                table: "address");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "user_ong");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "user_ong");

            migrationBuilder.DropColumn(
                name: "BankAccountId",
                table: "user_ong");

            migrationBuilder.RenameTable(
                name: "user_ong",
                newName: "UserOngModel");

            migrationBuilder.RenameTable(
                name: "UF",
                newName: "ufs");

            migrationBuilder.RenameColumn(
                name: "UF",
                table: "ufs",
                newName: "Uf");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateBirthDay",
                table: "user_voluntario",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "banks",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "Code",
                table: "banks",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Branch",
                table: "bank_account",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "AccountType",
                table: "bank_account",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "AccountNumber",
                table: "bank_account",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "bank_account",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "BankId",
                table: "bank_account",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "UserOngId",
                table: "bank_account",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "address",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "District",
                table: "address",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Complement",
                table: "address",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "address",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "address",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "HouseNumber",
                table: "address",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "address",
                type: "varchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "UserOngId",
                table: "address",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserVoluntarioId",
                table: "address",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserType",
                table: "UserOngModel",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "UserOngModel",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserOngModel",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "UserOngModel",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Contact",
                table: "UserOngModel",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Uf",
                table: "ufs",
                type: "varchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_voluntario",
                table: "user_voluntario",
                column: "Cpf");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserOngModel",
                table: "UserOngModel",
                column: "Cnpj");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ufs",
                table: "ufs",
                column: "Uf");

            migrationBuilder.CreateIndex(
                name: "IX_bank_account_BankId",
                table: "bank_account",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_bank_account_UserOngId",
                table: "bank_account",
                column: "UserOngId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_address_State",
                table: "address",
                column: "State");

            migrationBuilder.CreateIndex(
                name: "IX_address_UserOngId",
                table: "address",
                column: "UserOngId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_address_UserVoluntarioId",
                table: "address",
                column: "UserVoluntarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_address_ufs_State",
                table: "address",
                column: "State",
                principalTable: "ufs",
                principalColumn: "Uf",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_address_user_voluntario_UserVoluntarioId",
                table: "address",
                column: "UserVoluntarioId",
                principalTable: "user_voluntario",
                principalColumn: "Cpf");

            migrationBuilder.AddForeignKey(
                name: "FK_address_UserOngModel_UserOngId",
                table: "address",
                column: "UserOngId",
                principalTable: "UserOngModel",
                principalColumn: "Cnpj");

            migrationBuilder.AddForeignKey(
                name: "FK_bank_account_banks_BankId",
                table: "bank_account",
                column: "BankId",
                principalTable: "banks",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_bank_account_UserOngModel_UserOngId",
                table: "bank_account",
                column: "UserOngId",
                principalTable: "UserOngModel",
                principalColumn: "Cnpj",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
