using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteDeClasses.Migrations
{
    public partial class M04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "_cpf",
                table: "Usuarios_voluntarios",
                newName: "Cpf");

            migrationBuilder.RenameColumn(
                name: "_cnpj",
                table: "Usuarios_ong",
                newName: "Cnpj");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "Usuarios_voluntarios",
                newName: "_cpf");

            migrationBuilder.RenameColumn(
                name: "Cnpj",
                table: "Usuarios_ong",
                newName: "_cnpj");
        }
    }
}
