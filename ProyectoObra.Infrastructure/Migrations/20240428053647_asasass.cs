using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoObra.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class asasass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Rubros",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rubros_EmpresaId",
                table: "Rubros",
                column: "EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rubros_Empresas_EmpresaId",
                table: "Rubros",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rubros_Empresas_EmpresaId",
                table: "Rubros");

            migrationBuilder.DropIndex(
                name: "IX_Rubros_EmpresaId",
                table: "Rubros");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Rubros");
        }
    }
}
