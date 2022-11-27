using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CentralOngs.Migrations
{
    public partial class newFeature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //    name: "ImagemUrl",
            //    table: "UserModel",
            //    type: "text",
            //    nullable: true);

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    JobType = table.Column<int>(type: "integer", nullable: false),
                    UserOngId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_user_ong_UserOngId",
                        column: x => x.UserOngId,
                        principalTable: "user_ong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vacancies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserVoluntarioAbout = table.Column<string>(type: "text", nullable: true),
                    JobId = table.Column<int>(type: "integer", nullable: false),
                    UserVoluntarioId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacancies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vacancies_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vacancies_UserVoluntario_UserVoluntarioId",
                        column: x => x.UserVoluntarioId,
                        principalTable: "UserVoluntario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_UserOngId",
                table: "Jobs",
                column: "UserOngId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_JobId",
                table: "Vacancies",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_UserVoluntarioId",
                table: "Vacancies",
                column: "UserVoluntarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vacancies");

            migrationBuilder.DropTable(
                name: "Jobs");

            //migrationBuilder.DropColumn(
            //    name: "ImagemUrl",
            //    table: "UserModel");
        }
    }
}
