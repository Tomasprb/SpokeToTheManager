using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpokeToTheManager.Migrations
{
    /// <inheritdoc />
    public partial class RubrosSocios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "rubros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rubros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "socios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<double>(type: "float", nullable: false),
                    RubroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_socios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_socios_rubros_RubroId",
                        column: x => x.RubroId,
                        principalTable: "rubros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_socios_RubroId",
                table: "socios",
                column: "RubroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "socios");

            migrationBuilder.DropTable(
                name: "rubros");
        }
    }
}
