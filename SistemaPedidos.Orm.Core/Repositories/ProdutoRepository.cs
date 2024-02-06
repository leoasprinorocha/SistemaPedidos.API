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
            var produtoExistente = await _context.Produto.FirstOrDefaultAsync(c => c.Id == produto.Id);
            if (produtoExistente is not null)
            {
                produtoExistente.Descricao = produto.Descricao;
                produtoExistente.Preco = produto.Preco;
                _context.Produto.Update(produtoExistente);
                var updated = await _context.SaveChangesAsync();
                return updated >= 1;

            }
            return false;
        }

        public async Task<bool> ExcluirProduto(Guid idProduto)
        {
            var produtoExiste = await _context.Produto.FirstOrDefaultAsync(x => x.Id == idProduto);
            if (produtoExiste is not null)
            {
                _context.Produto.Remove(produtoExiste);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<Produto> RecuperaProdutoPorId(Guid idProduto)
        {
            var produto = await _context.Produto.FirstOrDefaultAsync(c => c.Id == idProduto);
            return produto;
        }

        public async Task<List<Produto>> RecuperaTodosProdutosAdesao(Guid idAdesao)
        {
            var produtos = await _context.Produto.Where(c => c.IdAdesao == idAdesao).ToListAsync();
            return produtos;
        }
    }
}
