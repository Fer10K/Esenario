using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Esenario.Migrations
{
    /// <inheritdoc />
    public partial class CrearTablasPedidos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id_Pedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Cliente = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id_Pedido);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_Id_Cliente",
                        column: x => x.Id_Cliente,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Detalle_Pedidos",
                columns: table => new
                {
                    Id_Detalle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Pedido = table.Column<int>(type: "int", nullable: false),
                    Id_Producto = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalle_Pedidos", x => x.Id_Detalle);
                    table.ForeignKey(
                        name: "FK_Detalle_Pedidos_Pedidos_Id_Pedido",
                        column: x => x.Id_Pedido,
                        principalTable: "Pedidos",
                        principalColumn: "Id_Pedido",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Detalle_Pedidos_Productos_Id_Producto",
                        column: x => x.Id_Producto,
                        principalTable: "Productos",
                        principalColumn: "Id_Producto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_Pedidos_Id_Pedido",
                table: "Detalle_Pedidos",
                column: "Id_Pedido");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_Pedidos_Id_Producto",
                table: "Detalle_Pedidos",
                column: "Id_Producto");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_Id_Cliente",
                table: "Pedidos",
                column: "Id_Cliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detalle_Pedidos");

            migrationBuilder.DropTable(
                name: "Pedidos");
        }
    }
}
