using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CentralDasOngs.Migrations
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_banks", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "ufs",
                columns: table => new
                {
                    Uf = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ufs", x => x.Uf);
                });

            migrationBuilder.CreateTable(
                name: "user_ong",
                columns: table => new
                {
                    Cnpj = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_ong", x => x.Cnpj);
                });

            migrationBuilder.CreateTable(
                name: "user_voluntario",
                columns: table => new
                {
                    Cpf = table.Column<long>(type: "bigint", nullable: false),
                    DateBirthDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_voluntario", x => x.Cpf);
                });

            migrationBuilder.CreateTable(
                name: "ong_bank_information",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Agency = table.Column<int>(type: "int", nullable: false),
                    AccountType = table.Column<int>(type: "int", nullable: false),
                    BankId = table.Column<int>(type: "int", nullable: false),
                    UserOngId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ong_bank_information", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ong_bank_information_banks_BankId",
                        column: x => x.BankId,
                        principalTable: "banks",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ong_bank_information_user_ong_UserOngId",
                        column: x => x.UserOngId,
                        principalTable: "user_ong",
                        principalColumn: "Cnpj",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "adress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseNumber = table.Column<int>(type: "int", nullable: false),
                    Complement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserVoluntarioId = table.Column<long>(type: "bigint", nullable: true),
                    UserOngId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_adress_ufs_State",
                        column: x => x.State,
                        principalTable: "ufs",
                        principalColumn: "Uf",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_adress_user_ong_UserOngId",
                        column: x => x.UserOngId,
                        principalTable: "user_ong",
                        principalColumn: "Cnpj",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_adress_user_voluntario_UserVoluntarioId",
                        column: x => x.UserVoluntarioId,
                        principalTable: "user_voluntario",
                        principalColumn: "Cpf",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_adress_State",
                table: "adress",
                column: "State");

            migrationBuilder.CreateIndex(
                name: "IX_adress_UserOngId",
                table: "adress",
                column: "UserOngId",
                unique: true,
                filter: "[UserOngId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_adress_UserVoluntarioId",
                table: "adress",
                column: "UserVoluntarioId",
                unique: true,
                filter: "[UserVoluntarioId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ong_bank_information_BankId",
                table: "ong_bank_information",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_ong_bank_information_UserOngId",
                table: "ong_bank_information",
                column: "UserOngId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adress");

            migrationBuilder.DropTable(
                name: "ong_bank_information");

            migrationBuilder.DropTable(
                name: "ufs");

            migrationBuilder.DropTable(
                name: "user_voluntario");

            migrationBuilder.DropTable(
                name: "banks");

            migrationBuilder.DropTable(
                name: "user_ong");
        }
    }
}
