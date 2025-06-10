using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Esenario.Migrations
{
    /// <inheritdoc />
    public partial class DP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_ClienteId_Cliente",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_ClienteId_Cliente",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "ClienteId_Cliente",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Id_Cliente",
                table: "Pedidos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId_Cliente",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_Cliente",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteId_Cliente",
                table: "Pedidos",
                column: "ClienteId_Cliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clientes_ClienteId_Cliente",
                table: "Pedidos",
                column: "ClienteId_Cliente",
                principalTable: "Clientes",
                principalColumn: "Id_Cliente",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
