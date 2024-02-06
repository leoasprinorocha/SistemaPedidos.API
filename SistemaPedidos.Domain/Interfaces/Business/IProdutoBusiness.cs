using SistemaPedidos.Domain.Entities;
using SistemaPedidos.Domain.ViewModels;

namespace SistemaPedidos.Domain.Interfaces.Business
{
    public interface IProdutoBusiness
    {
        Task<Tuple<bool, string>> AdicionaProduto(ProdutoViewModel produto);
        Task<ProdutoViewModel> RecuperaProdutoPorId(Guid idProduto);
        Task<List<ProdutoViewModel>> RecuperaTodosProdutosAdesao(Guid idAdesao);
        Task<bool> AtualizaProduto(ProdutoViewModel produto);
        Task<bool> ExcluirProduto(Guid idProduto);
    }
}
