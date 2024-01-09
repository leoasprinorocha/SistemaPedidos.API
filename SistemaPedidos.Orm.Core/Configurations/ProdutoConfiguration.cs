using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaPedidos.Domain.Entities;

namespace SistemaPedidos.Orm.Core.Configurations
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>, IEntityConfiguration
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnType("varchar(36)")
                .IsRequired();

            builder.Property(p => p.Descricao)
                            .HasColumnType("varchar(20)")
                            .IsRequired();

            builder.Property(p => p.Preco)
            .HasColumnType("decimal(7,2)")
            .IsRequired();

            builder.Property(p => p.IdAdesao)
                .HasColumnType("varchar(36)")
                .IsRequired();

            builder.Property(p => p.UrlFoto)
            .HasColumnType("varchar(1000)");
            

            builder.ToTable("produto");
        }

        public void Configure(ModelBuilder builder)
        {
            this.Configure(builder.Entity<Produto>());
        }
    }
}
