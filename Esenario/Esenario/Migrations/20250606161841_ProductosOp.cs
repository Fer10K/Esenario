using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Esenario.Migrations
{
    /// <inheritdoc />
    public partial class ProductosOp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdProducto",
                table: "Productos",
                newName: "Id_Producto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id_Producto",
                table: "Productos",
                newName: "IdProducto");
        }
    }
}
