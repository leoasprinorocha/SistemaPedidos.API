using Nelibur.ObjectMapper;
using SistemaPedidos.Domain.Entities.Pedidos;
using SistemaPedidos.Domain.Interfaces.Business;
using SistemaPedidos.Domain.Interfaces.Repository;
using SistemaPedidos.Domain.ViewModels.Pedido;

namespace SistemaPedidos.Business.Business
{
    public class PedidoBusiness : IPedidoBusiness
    {
        private readonly IPedidoRepository _pedidoRepository;


        public PedidoBusiness(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
            TinyMapper.Bind<StatusPedidoViewModel, StatusPedido>();
            TinyMapper.Bind<StatusPedido, StatusPedidoViewModel>();
        }

        public async Task<bool> AdicionaStatusPedido(StatusPedidoViewModel statusPedido)
        {
            StatusPedido statusPedidoSalvo = TinyMapper.Map<StatusPedido>(statusPedido);
            statusPedidoSalvo.Id = new Guid();
            bool statusFoiSalvo = await _pedidoRepository.AdicionaStatusPedido(statusPedidoSalvo);
            return statusFoiSalvo;
        }

        public async Task<bool> AtualizaStatusPedido(StatusPedidoViewModel statusPedido)
        {
            StatusPedido statusPedidoSalvo = TinyMapper.Map<StatusPedido>(statusPedido);
            bool statusFoiAtualizado = await _pedidoRepository.AtualizaStatusPedido(statusPedidoSalvo);
            return statusFoiAtualizado;
        }

        public async Task<bool> ExcluiStatusPedido(Guid idStatus)
        {
            var foiExcluido = await _pedidoRepository.ExcluiStatusPedido(idStatus);
            return foiExcluido;
        }

        public async Task<List<StatusPedidoViewModel>> RecuperaStatusPedidoAdesao(Guid idAdesao)
        {
            List<StatusPedidoViewModel> statusPedido = new();
            var statusPedidoBanco = await _pedidoRepository.RecuperaStatusPedidoAdesao(idAdesao);
            statusPedidoBanco.ForEach(c => statusPedido.Add(TinyMapper.Map<StatusPedidoViewModel>(c)));
            return statusPedido;
        }

        public async Task<StatusPedidoViewModel> RecuperaStatusPedidoPorId(Guid idStatus)
        {
            StatusPedidoViewModel statusPedidoViewModel = new();
            var statusPedido = await _pedidoRepository.RecuperaStatusPedidoPorId(idStatus);
            if (statusPedido is not null)
            {
                statusPedidoViewModel = TinyMapper.Map<StatusPedidoViewModel>(statusPedido);
            }
            return statusPedidoViewModel;
        }
    }
}
