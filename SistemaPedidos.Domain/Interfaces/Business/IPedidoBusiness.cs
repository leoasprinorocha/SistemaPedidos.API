using SistemaPedidos.Domain.ViewModels.Pedido;

namespace SistemaPedidos.Domain.Interfaces.Business
{
    public interface IPedidoBusiness
    {
        Task<StatusPedidoViewModel> RecuperaStatusPedidoPorId(Guid idStatus);
        Task<List<StatusPedidoViewModel>> RecuperaStatusPedidoAdesao(Guid idAdesao);
        Task<bool> AtualizaStatusPedido(StatusPedidoViewModel statusPedido);
        Task<bool> AdicionaStatusPedido(StatusPedidoViewModel statusPedido);
        Task<bool> ExcluiStatusPedido(Guid idStatus);
        Task<List<PedidoCompletoViewModel>> RecuperaPedidosDataAtualAdesao(Guid idAdesao);
    }
}
