using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LojaVenda.Migrations
{
    /// <inheritdoc />
    public partial class ImplementacaocategoriaProduto2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categoriaProduto_Categorias_categoriaId1",
                table: "categoriaProduto");

            migrationBuilder.DropForeignKey(
                name: "FK_categoriaProduto_Produtos_produtoId1",
                table: "categoriaProduto");

            migrationBuilder.AlterColumn<int>(
                name: "produtoId1",
                table: "categoriaProduto",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "categoriaId1",
                table: "categoriaProduto",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_categoriaProduto_Categorias_categoriaId1",
                table: "categoriaProduto",
                column: "categoriaId1",
                principalTable: "Categorias",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_categoriaProduto_Produtos_produtoId1",
                table: "categoriaProduto",
                column: "produtoId1",
                principalTable: "Produtos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categoriaProduto_Categorias_categoriaId1",
                table: "categoriaProduto");

            migrationBuilder.DropForeignKey(
                name: "FK_categoriaProduto_Produtos_produtoId1",
                table: "categoriaProduto");

            migrationBuilder.AlterColumn<int>(
                name: "produtoId1",
                table: "categoriaProduto",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "categoriaId1",
                table: "categoriaProduto",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_categoriaProduto_Categorias_categoriaId1",
                table: "categoriaProduto",
                column: "categoriaId1",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_categoriaProduto_Produtos_produtoId1",
                table: "categoriaProduto",
                column: "produtoId1",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
