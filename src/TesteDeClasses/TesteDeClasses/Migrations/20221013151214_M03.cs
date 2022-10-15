using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteDeClasses.Migrations
{
    public partial class M03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "Usuarios_voluntarios",
                newName: "CpfId");

            migrationBuilder.RenameColumn(
                name: "Cnpj",
                table: "Usuarios_ong",
                newName: "CnpjId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CpfId",
                table: "Usuarios_voluntarios",
                newName: "Cpf");

            migrationBuilder.RenameColumn(
                name: "CnpjId",
                table: "Usuarios_ong",
                newName: "Cnpj");
        }
    }
}
