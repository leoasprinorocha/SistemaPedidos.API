using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SistemaPedidos.Domain.Entities;
using SistemaPedidos.Domain.Entities.AdesaoEmpresa;
using SistemaPedidos.Domain.Entities.Clientes;
using SistemaPedidos.Domain.Entities.Pedidos;
using SistemaPedidos.Domain.Entities.Sistema;
using SistemaPedidos.Domain.Entities.Usuario;

namespace SistemaPedidos.Orm.Core
{
    public class SistemaPedidosContext : DbContext
    {
        private readonly IServiceProvider _services;
        public SistemaPedidosContext()
        {

        }
        public SistemaPedidosContext(DbContextOptions<SistemaPedidosContext> options, IServiceProvider services) : base(options)
        {
            _services = services;
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Adesao> Adesao { get; set; }
        public DbSet<Modulo> Modulo { get; set; }
        public DbSet<Rotina> Rotina { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<PedidoProduto> PedidoProduto { get; set; }
        public DbSet<StatusPedido> StatusPedido { get; set; }
        public DbSet<Mesa> Mesa { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var configurations = this._services.GetServices<IEntityConfiguration>();

            foreach (var item in configurations)
            {
                item.Configure(modelBuilder);
            }
        }
    }
}
