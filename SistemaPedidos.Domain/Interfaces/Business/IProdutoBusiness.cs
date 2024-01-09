using SistemaPedidos.Domain.Entities;
using SistemaPedidos.Domain.ViewModels;

namespace SistemaPedidos.Domain.Interfaces.Business
{
    public interface IProdutoBusiness
    {
        Task<bool> AdicionaProduto(ProdutoViewModel produto);
        Task<Produto> RecuperaProdutoPorId(Guid idProduto);
        Task<List<ProdutoViewModel>> RecuperaTodosProdutosAdesao(Guid idAdesao);
        Task<bool> AtualizaProduto(ProdutoViewModel produto);
        Task<bool> ExcluirProduto(Guid idProduto);
    }
}
