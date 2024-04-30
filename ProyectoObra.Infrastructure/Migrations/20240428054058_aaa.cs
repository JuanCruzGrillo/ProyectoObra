using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoObra.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class aaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Empleados");

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Empleados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_EmpresaId",
                table: "Empleados",
                column: "EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Empresas_EmpresaId",
                table: "Empleados",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Empresas_EmpresaId",
                table: "Empleados");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_EmpresaId",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Empleados");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Empleados",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
