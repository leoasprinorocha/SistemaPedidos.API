using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaPedidos.Domain.Entities.Pedidos;

namespace SistemaPedidos.Orm.Core.Configurations
{
    public class MesaConfiguration : IEntityTypeConfiguration<Mesa>, IEntityConfiguration
    {
        public void Configure(ModelBuilder builder)
        {
            this.Configure(builder.Entity<Mesa>());
        }

        public void Configure(EntityTypeBuilder<Mesa> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnType("varchar(36)")
                .IsRequired();

            builder.Property(p => p.Descricao)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(p => p.Status)
            .HasColumnType("int(1)")
            .IsRequired();

            builder.Property(p => p.ValorTotal)
            .HasColumnType("decimal(7,2)")
            .IsRequired();

            builder.ToTable("mesa");


        }
    }
}
