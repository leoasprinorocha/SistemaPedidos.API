using SistemaPedidos.Domain.Entities.Pedidos;
using SistemaPedidos.Domain.ViewModels.Pedido;

namespace SistemaPedidos.Domain.Interfaces.Repository
{
    public interface IPedidoRepository
    {
        Task<StatusPedido> RecuperaStatusPedidoPorId(Guid idStatus);
        Task<List<StatusPedido>> RecuperaStatusPedidoAdesao(Guid idAdesao);
        Task<bool> AtualizaStatusPedido(StatusPedido statusPedido);
        Task<bool> AdicionaStatusPedido(StatusPedido statusPedido);
        Task<bool> ExcluiStatusPedido(Guid idStatus);
    }
}
