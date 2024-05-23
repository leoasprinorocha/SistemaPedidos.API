using Microsoft.EntityFrameworkCore;
using SistemaPedidos.Domain.Entities.Sistema;
using SistemaPedidos.Domain.Interfaces.Repository;

namespace SistemaPedidos.Orm.Core.Repositories
{
    public class SistemaRepository : ISistemaRepository
    {
        private readonly SistemaPedidosContext _context;

        public SistemaRepository(SistemaPedidosContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Modulo>> RecuperaModulosSistema()
        {
            var modulos = await _context.Modulo.AsNoTracking().Include(a => a.Rotinas).ToListAsync();
            return modulos;
        }
    }
}
