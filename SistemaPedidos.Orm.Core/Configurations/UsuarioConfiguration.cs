using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaPedidos.Domain.Entities.Usuario;

namespace SistemaPedidos.Orm.Core.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>, IEntityConfiguration
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnType("varchar(36)")
                .IsRequired();

            builder.Property(p => p.Email)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(p => p.Email)
                .HasColumnType("varchar(12)")
                .IsRequired();

            builder.Property(p => p.Nome)
                .HasColumnType("varchar(40)")
                .IsRequired();

            builder.Property(p => p.IdAdesao)
                            .HasColumnType("varchar(36)")
                            .IsRequired();

            builder.Property(p => p.Ativo)
                    .HasColumnType("tinyint")
                        .IsRequired();

            builder.Property(p => p.IdAspnetUser)
                            .HasColumnType("varchar(36)")
                            .IsRequired();

            builder.Property(p => p.TipoUsuario)
            .HasColumnType("number(1)")
            .IsRequired();

            builder.HasOne(c => c.AdesaoUsuario)
            .WithMany()
            .HasForeignKey(a => a.IdAdesao)
            .HasPrincipalKey(a => a.Id);

            builder.ToTable("usuario");
        }

        public void Configure(ModelBuilder builder)
        {
            this.Configure(builder.Entity<Usuario>());
        }
    }
}
