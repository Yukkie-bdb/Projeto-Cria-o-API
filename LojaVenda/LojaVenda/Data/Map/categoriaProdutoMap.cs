using LojinhaVendas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SistemaTarefas.Data.Map
{
    public class categoriaProdutoMap : IEntityTypeConfiguration<categoriaProdutoModel>
    {
        public void Configure(EntityTypeBuilder<categoriaProdutoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.produtoId).IsRequired();
            builder.Property(x => x.categoriaId).IsRequired();
        }
    }
}
