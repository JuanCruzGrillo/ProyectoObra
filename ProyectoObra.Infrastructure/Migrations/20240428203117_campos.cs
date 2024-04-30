using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoObra.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class campos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaInicio",
                table: "Contrataciones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Contrataciones_idEmpresa",
                table: "Contrataciones",
                column: "idEmpresa");

            migrationBuilder.AddForeignKey(
                name: "FK_Contrataciones_Empresas_idEmpresa",
                table: "Contrataciones",
                column: "idEmpresa",
                principalTable: "Empresas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        
            migrationBuilder.DropIndex(
                name: "IX_Contrataciones_idEmpresa",
                table: "Contrataciones");

            migrationBuilder.DropColumn(
                name: "FechaInicio",
                table: "Contrataciones");
        }
    }
}
