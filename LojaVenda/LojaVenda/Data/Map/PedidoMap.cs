using LojinhaVendas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SistemaTarefas.Data.Map
{
    public class PedidoMap : IEntityTypeConfiguration<pedidoModel>
    {
        public void Configure(EntityTypeBuilder<pedidoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.usuarioId).IsRequired().HasMaxLength(255);
            builder.Property(x => x.enderecoEntrega).IsRequired().HasMaxLength(255);
        }
    }
}
