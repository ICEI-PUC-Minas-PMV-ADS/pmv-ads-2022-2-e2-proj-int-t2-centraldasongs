using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CentralOngs.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "banks",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_banks", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "ufs",
                columns: table => new
                {
                    Uf = table.Column<string>(type: "varchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ufs", x => x.Uf);
                });

            migrationBuilder.CreateTable(
                name: "user_voluntario",
                columns: table => new
                {
                    Cpf = table.Column<long>(type: "bigint", nullable: false),
                    DateBirthDay = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_voluntario", x => x.Cpf);
                });

            migrationBuilder.CreateTable(
                name: "UserOngModel",
                columns: table => new
                {
                    Cnpj = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", nullable: false),
                    Password = table.Column<string>(type: "varchar(200)", nullable: false),
                    Contact = table.Column<string>(type: "varchar(200)", nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOngModel", x => x.Cnpj);
                });

            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<string>(type: "varchar(450)", nullable: false),
                    City = table.Column<string>(type: "varchar(200)", nullable: false),
                    District = table.Column<string>(type: "varchar(200)", nullable: false),
                    Street = table.Column<string>(type: "varchar(200)", nullable: false),
                    HouseNumber = table.Column<int>(type: "int", nullable: false),
                    Complement = table.Column<string>(type: "varchar(200)", nullable: false),
                    UserVoluntarioId = table.Column<long>(type: "bigint", nullable: true),
                    UserOngId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_address_ufs_State",
                        column: x => x.State,
                        principalTable: "ufs",
                        principalColumn: "Uf",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_address_user_voluntario_UserVoluntarioId",
                        column: x => x.UserVoluntarioId,
                        principalTable: "user_voluntario",
                        principalColumn: "Cpf");
                    table.ForeignKey(
                        name: "FK_address_UserOngModel_UserOngId",
                        column: x => x.UserOngId,
                        principalTable: "UserOngModel",
                        principalColumn: "Cnpj");
                });

            migrationBuilder.CreateTable(
                name: "bank_account",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<string>(type: "varchar(200)", nullable: false),
                    Branch = table.Column<int>(type: "int", nullable: false),
                    AccountType = table.Column<int>(type: "int", nullable: false),
                    BankId = table.Column<int>(type: "int", nullable: false),
                    UserOngId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bank_account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bank_account_banks_BankId",
                        column: x => x.BankId,
                        principalTable: "banks",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bank_account_UserOngModel_UserOngId",
                        column: x => x.UserOngId,
                        principalTable: "UserOngModel",
                        principalColumn: "Cnpj",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_bank_account_BankId",
                table: "bank_account",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_bank_account_UserOngId",
                table: "bank_account",
                column: "UserOngId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropTable(
                name: "bank_account");

            migrationBuilder.DropTable(
                name: "ufs");

            migrationBuilder.DropTable(
                name: "user_voluntario");

            migrationBuilder.DropTable(
                name: "banks");

            migrationBuilder.DropTable(
                name: "UserOngModel");
        }
    }
}
