using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogJoaoPedroLeagueofLegends.Infra.Migrations
{
    public partial class AddPreviaTexto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PreviaTexto",
                table: "Posts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PreviaTexto",
                table: "Posts");
        }
    }
}
