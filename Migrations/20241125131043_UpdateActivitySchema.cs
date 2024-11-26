using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace register_caborno.Migrations
{
    /// <inheritdoc />
    public partial class UpdateActivitySchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Emissao",
                table: "Activities");

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Activities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataRegistro",
                table: "Activities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "EhReducao",
                table: "Activities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "EmissoesCO2",
                table: "Activities",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "DataRegistro",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "EhReducao",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "EmissoesCO2",
                table: "Activities");

            migrationBuilder.AddColumn<float>(
                name: "Emissao",
                table: "Activities",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
