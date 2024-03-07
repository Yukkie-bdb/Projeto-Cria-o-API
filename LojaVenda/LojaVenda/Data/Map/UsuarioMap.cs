using LojinhaVendas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SistemaTarefas.Data.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<usuarioModel>
    {
        public void Configure(EntityTypeBuilder<usuarioModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.email).IsRequired().HasMaxLength(255);
            builder.Property(x => x.dataNascimento).IsRequired();
        }
    }
}
