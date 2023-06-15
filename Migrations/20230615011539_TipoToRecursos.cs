using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpokeToTheManager.Migrations
{
    /// <inheritdoc />
    public partial class TipoToRecursos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "tipo",
                table: "recu",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tipo",
                table: "recu");
        }
    }
}
