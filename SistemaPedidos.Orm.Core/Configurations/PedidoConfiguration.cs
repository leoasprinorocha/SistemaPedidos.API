using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaPedidos.Domain.Entities.Clientes;
using SistemaPedidos.Domain.Entities.Pedidos;

namespace SistemaPedidos.Orm.Core.Configurations
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>, IEntityConfiguration
    {
        public void Configure(ModelBuilder builder)
        {
            this.Configure(builder.Entity<Pedido>());
        }

        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnType("varchar(36)")
                .IsRequired();

            builder.Property(p => p.IdCliente)
                .HasColumnType("varchar(36)");

            builder.Property(p => p.IdStatusPedido)
                            .HasColumnType("varchar(36)")
                            .IsRequired();

            builder.Property(p => p.IdAdesao)
            .HasColumnType("varchar(36)")
            .IsRequired();

            builder.Property(p => p.IdMesa)
            .HasColumnType("varchar(36)")
            .IsRequired();

            builder.Property(p => p.ValorTotal)
                        .HasColumnType("decimal(7,2)")
                        .IsRequired();

            builder.Property(p => p.Data)
                                    .HasColumnType("datetime")
                                    .IsRequired();

            builder.Property(p => p.CodigoPedido).HasColumnType("int").ValueGeneratedOnAdd();


            builder.Property(p => p.Mesa)
                            .HasColumnType("varchar(36)")
                            .IsRequired();


            builder.ToTable("pedido");


        }
    }
}
