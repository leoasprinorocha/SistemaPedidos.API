using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaPedidos.Domain.Entities.AdesaoEmpresa;

namespace SistemaPedidos.Orm.Core.Configurations
{
    public class AdesaoConfiguration : IEntityTypeConfiguration<Adesao>, IEntityConfiguration
    {
        public void Configure(EntityTypeBuilder<Adesao> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.CodigoAdesao)
                .HasColumnType("number(10)")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(p => p.Id)
                .HasColumnType("varchar(36)")
                .IsRequired();

            builder.Property(p => p.NomeEmpresa)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(p => p.Ativo)
                .HasColumnType("tinyint")
                .IsRequired();

            builder.ToTable("adesao");
        }

        public void Configure(ModelBuilder builder)
        {
            this.Configure(builder.Entity<Adesao>());
        }
    }
}
