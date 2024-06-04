using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaPedidos.Domain.Entities.Pedidos;

namespace SistemaPedidos.Orm.Core.Configurations
{
    public class PedidoProdutoConfiguration : IEntityTypeConfiguration<PedidoProduto>, IEntityConfiguration
    {
        public void Configure(ModelBuilder builder)
        {
            this.Configure(builder.Entity<PedidoProduto>());
        }

        public void Configure(EntityTypeBuilder<PedidoProduto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnType("varchar(36)")
                .IsRequired();

            builder.Property(p => p.IdPedido)
            .HasColumnType("varchar(36)")
            .IsRequired();

            builder.Property(p => p.IdProduto)
            .HasColumnType("varchar(36)")
            .IsRequired();

            builder.Property(p => p.Quantidade)
            .HasColumnType("int")
            .IsRequired();

            builder.ToTable("pedidoproduto");


        }
    }
}
