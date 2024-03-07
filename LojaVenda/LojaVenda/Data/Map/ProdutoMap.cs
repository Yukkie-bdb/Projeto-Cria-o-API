using LojinhaVendas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SistemaTarefas.Data.Map
{
    public class ProdutoMap : IEntityTypeConfiguration<produtoModel>
    {
        public void Configure(EntityTypeBuilder<produtoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.descricao).IsRequired().HasMaxLength(255);
            builder.Property(x => x.preco).IsRequired().HasMaxLength(255);
        }
    }
}
