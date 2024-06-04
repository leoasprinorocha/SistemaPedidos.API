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
        private readonly IProdutoRepository _produtoRepository;


        public PedidoBusiness(IPedidoRepository pedidoRepository, IProdutoRepository produtoRepository)
        {
            _pedidoRepository = pedidoRepository;
            _produtoRepository = produtoRepository;
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

        public async Task<List<PedidoCompletoViewModel>> RecuperaPedidosDataAtualAdesao(Guid idAdesao)
        {
            var pedidos = await _pedidoRepository.RecuperaPedidosDataAtualAdesao(idAdesao);
            var pedidosViewModel = await MontaObjetoPedidoCompleto(pedidos);
            return pedidosViewModel;            
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

        private async Task<List<PedidoCompletoViewModel>> MontaObjetoPedidoCompleto(List<Pedido> pedidos)
        {
            List<PedidoCompletoViewModel> pedidosEmAbertoDataAtualAdesaoViewModel = new();

            foreach (var pedido in pedidos)
            {
                var statusPedido = await _pedidoRepository.RecuperaStatusPedidoPorId(pedido.IdStatusPedido);
                var produtosDoPedido = await _pedidoRepository.RecuperaProdutosDoPedido(pedido.Id);
                List<PedidoProdutoSimplificadoViewModel> produtosDoPedidoViewModel = new();

                if (produtosDoPedido.Any())
                {
                    foreach (var produtoPedido in produtosDoPedido)
                    {
                        var produtoDoBanco = await _produtoRepository.RecuperaProdutoPorId(produtoPedido.IdProduto);
                        PedidoProdutoSimplificadoViewModel pedidoProduto = new()
                        {
                            DescricaoProduto = produtoDoBanco.Descricao,
                            Quantidade = produtoPedido.Quantidade
                        };

                        produtosDoPedidoViewModel.Add(pedidoProduto);
                    }
                }

                PedidoCompletoViewModel pedidoViewModel = new()
                {
                    IdCliente = pedido.IdCliente,
                    IdPedido = pedido.Id,
                    CodigoPedido = pedido.CodigoPedido,
                    DescricaoStatusPedido = statusPedido.Descricao,
                    Data = pedido.Data,
                    Mesa = pedido.Mesa,
                    ValorTotalString = $"R$ {pedido.ValorTotal}",
                    Produtos = produtosDoPedidoViewModel
                };

                pedidosEmAbertoDataAtualAdesaoViewModel.Add(pedidoViewModel);
            }

            return pedidosEmAbertoDataAtualAdesaoViewModel;
        }
    }
}
