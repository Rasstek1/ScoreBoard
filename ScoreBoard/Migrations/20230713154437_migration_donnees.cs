using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScoreBoard.Migrations
{
    /// <inheritdoc />
    public partial class migration_donnees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ScoreTotal",
                table: "Joueurs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScoreTotal",
                table: "Joueurs");
        }
    }
}
