using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaPedidos.Domain.Entities.Sistema;

namespace SistemaPedidos.Orm.Core.Configurations
{
    public class ModuloConfiguration : IEntityTypeConfiguration<Modulo>, IEntityConfiguration
    {
        public void Configure(EntityTypeBuilder<Modulo> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnType("varchar(36)")
                .IsRequired();

            builder.Property(p => p.Descricao)
                            .HasColumnType("varchar(20)")
                            .IsRequired();

            builder.ToTable("modulo");
        }

        public void Configure(ModelBuilder builder)
        {
            this.Configure(builder.Entity<Modulo>());
        }
    }
}
