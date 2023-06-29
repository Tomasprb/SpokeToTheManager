using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpokeToTheManager.Migrations
{
    /// <inheritdoc />
    public partial class DateForIncomeOutcome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "fecha",
                table: "ingresos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "fecha",
                table: "egresos",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fecha",
                table: "ingresos");

            migrationBuilder.DropColumn(
                name: "fecha",
                table: "egresos");
        }
    }
}
