using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LojaVenda.Migrations
{
    /// <inheritdoc />
    public partial class ImplementacaocategoriaProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidosProdutos");

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "Produtos",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "Produtos",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "categoriaProduto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    produtoId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    categoriaId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    produtoId1 = table.Column<int>(type: "int", nullable: false),
                    categoriaId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoriaProduto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_categoriaProduto_Categorias_categoriaId1",
                        column: x => x.categoriaId1,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_categoriaProduto_Produtos_produtoId1",
                        column: x => x.produtoId1,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_categoriaProduto_categoriaId1",
                table: "categoriaProduto",
                column: "categoriaId1");

            migrationBuilder.CreateIndex(
                name: "IX_categoriaProduto_produtoId1",
                table: "categoriaProduto",
                column: "produtoId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categoriaProduto");

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "Produtos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "Produtos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.CreateTable(
                name: "PedidosProdutos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoriaId1 = table.Column<int>(type: "int", nullable: false),
                    produtoId1 = table.Column<int>(type: "int", nullable: false),
                    categoriaId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    preco = table.Column<int>(type: "int", nullable: false),
                    produtoId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidosProdutos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidosProdutos_Categorias_categoriaId1",
                        column: x => x.categoriaId1,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidosProdutos_Produtos_produtoId1",
                        column: x => x.produtoId1,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PedidosProdutos_categoriaId1",
                table: "PedidosProdutos",
                column: "categoriaId1");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosProdutos_produtoId1",
                table: "PedidosProdutos",
                column: "produtoId1");
        }
    }
}
