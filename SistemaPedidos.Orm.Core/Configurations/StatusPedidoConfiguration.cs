using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaPedidos.Domain.Entities.Pedidos;

namespace SistemaPedidos.Orm.Core.Configurations
{
    public class StatusPedidoConfiguration : IEntityTypeConfiguration<StatusPedido>, IEntityConfiguration
    {
        public void Configure(ModelBuilder builder)
        {
            this.Configure(builder.Entity<StatusPedido>());
        }

        public void Configure(EntityTypeBuilder<StatusPedido> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnType("varchar(36)")
                .IsRequired();

            builder.Property(p => p.IdAdesao)
            .HasColumnType("varchar(36)")
            .IsRequired();

            builder.Property(p => p.Descricao)
            .HasColumnType("varchar(15)")
            .IsRequired();


            builder.ToTable("statuspedido");


        }
    }
}
