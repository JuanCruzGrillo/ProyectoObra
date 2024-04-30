using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoObra.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class aassxañ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContratacionProductos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContratacionId = table.Column<int>(type: "int", nullable: true),
                    ProductoId = table.Column<int>(type: "int", nullable: true),
                    Unidad = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratacionProductos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContratacionProductos_Contrataciones_ContratacionId",
                        column: x => x.ContratacionId,
                        principalTable: "Contrataciones",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContratacionProductos_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContratacionProductos_ContratacionId",
                table: "ContratacionProductos",
                column: "ContratacionId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratacionProductos_ProductoId",
                table: "ContratacionProductos",
                column: "ProductoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContratacionProductos");
        }
    }
}
