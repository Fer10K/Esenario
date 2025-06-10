using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Esenario.Migrations
{
    /// <inheritdoc />
    public partial class ProductosOptimizado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id_Producto",
                table: "Productos",
                newName: "IdProducto");

            migrationBuilder.AlterColumn<int>(
                name: "Categoria",
                table: "Productos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdProducto",
                table: "Productos",
                newName: "Id_Producto");

            migrationBuilder.AlterColumn<string>(
                name: "Categoria",
                table: "Productos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
