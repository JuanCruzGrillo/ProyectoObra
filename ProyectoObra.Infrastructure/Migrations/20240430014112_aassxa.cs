using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoObra.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class aassxa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Contrataciones",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Finalizado",
                table: "Contrataciones",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Contrataciones");

            migrationBuilder.DropColumn(
                name: "Finalizado",
                table: "Contrataciones");
        }
    }
}
