using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteDeClasses.Migrations
{
    public partial class M02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "_cpf",
                table: "Usuarios_voluntarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "_cnpj",
                table: "Usuarios_ong",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "_cpf",
                table: "Usuarios_voluntarios");

            migrationBuilder.DropColumn(
                name: "_cnpj",
                table: "Usuarios_ong");
        }
    }
}
