using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CentralOngs.Migrations
{
    public partial class AddPropAbout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateBirthDay",
                table: "UserVoluntario",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "user_ong",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "About",
                table: "user_ong");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateBirthDay",
                table: "UserVoluntario",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");
        }
    }
}
