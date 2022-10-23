using Microsoft.EntityFrameworkCore.Migrations;

namespace CentralDasOngs.Migrations
{
    public partial class Usuario_Ong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsuarioOngCnpj",
                table: "enderecos",
                type: "nvarchar(450)",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_enderecos_UsuarioOngCnpj",
                table: "enderecos",
                column: "UsuarioOngCnpj");

            migrationBuilder.CreateIndex(
                name: "IX_DadosBancarios_Codigo",
                table: "DadosBancarios",
                column: "Codigo");

            migrationBuilder.CreateIndex(
                name: "IX_DadosBancarios_UsuarioOngCnpj",
                table: "DadosBancarios",
                column: "UsuarioOngCnpj");

            migrationBuilder.AddForeignKey(
                name: "FK_enderecos_UsuariosOng_UsuarioOngCnpj",
                table: "enderecos",
                column: "UsuarioOngCnpj",
                principalTable: "UsuariosOng",
                principalColumn: "Cnpj_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_enderecos_UsuariosOng_UsuarioOngCnpj",
                table: "enderecos");

            migrationBuilder.DropTable(
                name: "DadosBancarios");

            migrationBuilder.DropTable(
                name: "bancos");

            migrationBuilder.DropTable(
                name: "UsuariosOng");

            migrationBuilder.DropIndex(
                name: "IX_enderecos_UsuarioOngCnpj",
                table: "enderecos");

            migrationBuilder.DropColumn(
                name: "UsuarioOngCnpj",
                table: "enderecos");
        }
    }
}
