using Microsoft.EntityFrameworkCore;
using SistemaPedidos.Domain.Entities.AdesaoEmpresa;
using SistemaPedidos.Domain.Interfaces.Repository;

namespace SistemaPedidos.Orm.Core.Repositories
{
    public class AdesaoRepository : IAdesaoRepository
    {
        private readonly SistemaPedidosContext _context;
        public AdesaoRepository(SistemaPedidosContext context)
        {
            _context = context;
        }
        public async Task<bool> AtualizarAdesao(Adesao adesao)
        {
            var adesaoJaExistente = await _context.Adesao.FirstOrDefaultAsync(c => c.Id == adesao.Id);
            int updated = 0;
            if (adesaoJaExistente is not null)
            {
                adesaoJaExistente.NomeEmpresa = adesao.NomeEmpresa;
                adesaoJaExistente.Ativo = adesao.Ativo;
                _context.Adesao.Update(adesaoJaExistente);
                updated = await _context.SaveChangesAsync();
            }

            return updated > 0;

        }

        public async Task<bool> CadastrarAdesao(Adesao adesao)
        {
            var adesaoJaExiste = await _context.Adesao.FirstOrDefaultAsync(c => c.Id == adesao.Id);
            int saved = 0;
            if (adesaoJaExiste is null)
            {
                var ultimaAdesao = await _context.Adesao.OrderByDescending(c => c.CodigoAdesao).FirstOrDefaultAsync();
                adesao.CodigoAdesao = ultimaAdesao != null ? ultimaAdesao.CodigoAdesao + 1 : 1;
                await _context.Adesao.AddAsync(adesao);
                saved = await _context.SaveChangesAsync();
            }

            return saved > 0;
        }
    }
}
