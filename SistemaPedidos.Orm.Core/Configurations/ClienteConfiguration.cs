using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaPedidos.Domain.Entities.Clientes;

namespace SistemaPedidos.Orm.Core.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>, IEntityConfiguration
    {
        public void Configure(ModelBuilder builder)
        {
            this.Configure(builder.Entity<Cliente>());
        }

        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnType("varchar(36)")
                .IsRequired();

            builder.Property(p => p.Nome)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(p => p.Telefone)
            .HasColumnType("varchar(11)")
            .IsRequired();

            builder.Property(p => p.Endereco)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.IdPlano)
            .HasColumnType("char(36)")
            .IsRequired();

            builder.Property(p => p.IdPlano)
                .HasColumnType("char(36)")
                .IsRequired();

            builder.Property(p => p.IdAdesao)
                .HasColumnType("varchar(36)")
                .IsRequired();

            builder.Property(p => p.EhPlanoMensal)
                .HasColumnType("tinyint")
                .IsRequired();

            builder.HasOne(c => c.AdesaoCliente)
                .WithMany()
                .HasForeignKey(a => a.IdAdesao)
                .HasPrincipalKey(a => a.Id);

            builder.ToTable("cliente");


        }
    }
}
