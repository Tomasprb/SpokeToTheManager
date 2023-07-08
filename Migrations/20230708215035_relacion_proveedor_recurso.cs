using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpokeToTheManager.Migrations
{
    /// <inheritdoc />
    public partial class relacion_proveedor_recurso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SocioId",
                table: "recu",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_recu_SocioId",
                table: "recu",
                column: "SocioId");

            migrationBuilder.AddForeignKey(
                name: "FK_recu_socios_SocioId",
                table: "recu",
                column: "SocioId",
                principalTable: "socios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_recu_socios_SocioId",
                table: "recu");

            migrationBuilder.DropIndex(
                name: "IX_recu_SocioId",
                table: "recu");

            migrationBuilder.DropColumn(
                name: "SocioId",
                table: "recu");
        }
    }
}
