using Microsoft.EntityFrameworkCore;
using SistemaPedidos.Domain.Entities;
using SistemaPedidos.Domain.Interfaces.Repository;

namespace SistemaPedidos.Orm.Core.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly SistemaPedidosContext _context;

        public ProdutoRepository(SistemaPedidosContext context)
        {
            _context = context;
        }
        public async Task<bool> AdicionaProduto(Produto produto)
        {
            await _context.Produto.AddAsync(produto);
            var saved = await _context.SaveChangesAsync();
            return saved >= 1;
        }

        public async Task<bool> AtualizaProduto(Produto produto)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExcluirProduto(Guid idProduto)
        {
            throw new NotImplementedException();
        }

        public async Task<Produto> RecuperaProdutoPorId(Guid idProduto)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Produto>> RecuperaTodosProdutosAdesao(Guid idAdesao)
        {
            var produtos = await _context.Produto.Where(c => c.IdAdesao == idAdesao).ToListAsync();
            return produtos;
        }
    }
}
