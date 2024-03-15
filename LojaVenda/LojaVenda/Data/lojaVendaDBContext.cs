using LojinhaVendas.Models;
using Microsoft.EntityFrameworkCore;
using SistemaTarefas.Data.Map;

namespace SistemaTarefas.Data
{
    public class lojaVendaDBContext : DbContext
    {
        public lojaVendaDBContext(DbContextOptions<lojaVendaDBContext> options) : base(options) { }

        public DbSet<usuarioModel> Usuarios { get; set; }
        public DbSet<categoriaModel> Categorias { get; set; }
        public DbSet<pedidoModel> Pedidos { get; set; }
        public DbSet<categoriaProdutoModel> categoriaProduto { get; set; }
        public DbSet<produtoModel> Produtos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new PedidoMap());
            modelBuilder.ApplyConfiguration(new categoriaProdutoMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}
