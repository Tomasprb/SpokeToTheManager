using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpokeToTheManager.Migrations
{
    /// <inheritdoc />
    public partial class Recursos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Socio_Rubro_RubroId",
                table: "Socio");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Rubro_TempId",
                table: "Rubro");

            migrationBuilder.RenameTable(
                name: "Socio",
                newName: "socios");

            migrationBuilder.RenameTable(
                name: "Rubro",
                newName: "rubros");

            migrationBuilder.RenameColumn(
                name: "TempId",
                table: "rubros",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "RubroId",
                table: "socios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "socios",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "socios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "socios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Telefono",
                table: "socios",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "rubros",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "rubros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_socios",
                table: "socios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_rubros",
                table: "rubros",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "recursos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<float>(type: "real", nullable: false),
                    ValorXUnidad = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recursos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_socios_RubroId",
                table: "socios",
                column: "RubroId");

            migrationBuilder.AddForeignKey(
                name: "FK_socios_rubros_RubroId",
                table: "socios",
                column: "RubroId",
                principalTable: "rubros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_socios_rubros_RubroId",
                table: "socios");

            migrationBuilder.DropTable(
                name: "recursos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_socios",
                table: "socios");

            migrationBuilder.DropIndex(
                name: "IX_socios_RubroId",
                table: "socios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_rubros",
                table: "rubros");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "socios");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "socios");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "socios");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "socios");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "rubros");

            migrationBuilder.RenameTable(
                name: "socios",
                newName: "Socio");

            migrationBuilder.RenameTable(
                name: "rubros",
                newName: "Rubro");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Rubro",
                newName: "TempId");

            migrationBuilder.AlterColumn<int>(
                name: "RubroId",
                table: "Socio",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TempId",
                table: "Rubro",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Rubro_TempId",
                table: "Rubro",
                column: "TempId");

            migrationBuilder.AddForeignKey(
                name: "FK_Socio_Rubro_RubroId",
                table: "Socio",
                column: "RubroId",
                principalTable: "Rubro",
                principalColumn: "TempId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
