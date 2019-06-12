using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogJoaoPedroLeagueofLegends.Infra.Migrations
{
    public partial class AtualizacaoDeClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SubTitulo",
                table: "Posts",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Titulo",
                table: "Posts",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubTitulo",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Titulo",
                table: "Posts");
        }
    }
}
