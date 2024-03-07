using LojinhaVendas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SistemaTarefas.Data.Map
{
    public class CategoriaMap : IEntityTypeConfiguration<categoriaModel>
    {
        public void Configure(EntityTypeBuilder<categoriaModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.status).IsRequired();
        }
    }
}
