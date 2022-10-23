using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CentralDasOngs.Migrations
{
    public partial class Usuario_Voluntario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ufs",
                columns: table => new
                {
                    uf = table.Column<string>(type: "char(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ufs", x => x.uf);
                });

            migrationBuilder.CreateTable(
                name: "UsuariosVoluntarios",
                columns: table => new
                {
                    Cpf_Id = table.Column<string>(type: "varchar(14)", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(14)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contato = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosVoluntarios", x => x.Cpf_Id);
                });

            migrationBuilder.CreateTable(
                name: "enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroEndereco = table.Column<int>(type: "int", nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "varchar(29)", nullable: false),
                    UsuarioVoluntarioCpf = table.Column<string>(type: "varchar(14)", nullable: true),
                    Uf = table.Column<string>(type: "char(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enderecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_enderecos_ufs_Uf",
                        column: x => x.Uf,
                        principalTable: "ufs",
                        principalColumn: "uf",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_enderecos_UsuariosVoluntarios_UsuarioVoluntarioCpf",
                        column: x => x.UsuarioVoluntarioCpf,
                        principalTable: "UsuariosVoluntarios",
                        principalColumn: "Cpf_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_enderecos_Uf",
                table: "enderecos",
                column: "Uf");

            migrationBuilder.CreateIndex(
                name: "IX_enderecos_UsuarioVoluntarioCpf",
                table: "enderecos",
                column: "UsuarioVoluntarioCpf");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "enderecos");

            migrationBuilder.DropTable(
                name: "ufs");

            migrationBuilder.DropTable(
                name: "UsuariosVoluntarios");
        }
    }
}
