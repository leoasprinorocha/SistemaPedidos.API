using SistemaPedidos.Domain.Entities;

namespace SistemaPedidos.Domain.Interfaces.Repository
{
    public interface IProdutoRepository
    {
        Task<bool> AdicionaProduto(Produto produto);
        Task<Produto> RecuperaProdutoPorId(Guid idProduto);
        Task<List<Produto>> RecuperaTodosProdutosAdesao(Guid idAdesao);
        Task<bool> AtualizaProduto(Produto produto);
        Task<bool> ExcluirProduto(Guid idProduto);
    }
}
