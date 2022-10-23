using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CentralDasOngs.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bancos",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bancos", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "ufs",
                columns: table => new
                {
                    uf = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ufs", x => x.uf);
                });

            migrationBuilder.CreateTable(
                name: "UsuariosOng",
                columns: table => new
                {
                    Cnpj_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Cnpj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosOng", x => x.Cnpj_Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuariosVoluntarios",
                columns: table => new
                {
                    Cpf_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosVoluntarios", x => x.Cpf_Id);
                });

            migrationBuilder.CreateTable(
                name: "DadosBancarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroConta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Agencia = table.Column<int>(type: "int", nullable: false),
                    Operacao = table.Column<int>(type: "int", nullable: false),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    UsuarioOngCnpj = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosBancarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DadosBancarios_bancos_Codigo",
                        column: x => x.Codigo,
                        principalTable: "bancos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DadosBancarios_UsuariosOng_UsuarioOngCnpj",
                        column: x => x.UsuarioOngCnpj,
                        principalTable: "UsuariosOng",
                        principalColumn: "Cnpj_Id",
                        onDelete: ReferentialAction.Restrict);
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
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioVoluntarioCpf = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UsuarioOngCnpj = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Uf = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
                        name: "FK_enderecos_UsuariosOng_UsuarioOngCnpj",
                        column: x => x.UsuarioOngCnpj,
                        principalTable: "UsuariosOng",
                        principalColumn: "Cnpj_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_enderecos_UsuariosVoluntarios_UsuarioVoluntarioCpf",
                        column: x => x.UsuarioVoluntarioCpf,
                        principalTable: "UsuariosVoluntarios",
                        principalColumn: "Cpf_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DadosBancarios_Codigo",
                table: "DadosBancarios",
                column: "Codigo");

            migrationBuilder.CreateIndex(
                name: "IX_DadosBancarios_UsuarioOngCnpj",
                table: "DadosBancarios",
                column: "UsuarioOngCnpj");

            migrationBuilder.CreateIndex(
                name: "IX_enderecos_Uf",
                table: "enderecos",
                column: "Uf");

            migrationBuilder.CreateIndex(
                name: "IX_enderecos_UsuarioOngCnpj",
                table: "enderecos",
                column: "UsuarioOngCnpj");

            migrationBuilder.CreateIndex(
                name: "IX_enderecos_UsuarioVoluntarioCpf",
                table: "enderecos",
                column: "UsuarioVoluntarioCpf");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DadosBancarios");

            migrationBuilder.DropTable(
                name: "enderecos");

            migrationBuilder.DropTable(
                name: "bancos");

            migrationBuilder.DropTable(
                name: "ufs");

            migrationBuilder.DropTable(
                name: "UsuariosOng");

            migrationBuilder.DropTable(
                name: "UsuariosVoluntarios");
        }
    }
}
