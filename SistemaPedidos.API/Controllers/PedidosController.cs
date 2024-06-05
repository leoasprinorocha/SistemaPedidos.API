using Microsoft.AspNetCore.Mvc;
using SistemaPedidos.Domain.Interfaces.Business;
using SistemaPedidos.Domain.ViewModels.Pedido;

namespace SistemaPedidos.API.Controllers
{
    [Route("pedido")]
    public class PedidosController : BaseController
    {
        private readonly IPedidoBusiness _pedidoBusiness;
        public PedidosController(IPedidoBusiness pedidoBusiness)
        {
            _pedidoBusiness = pedidoBusiness;
        }

        [HttpGet("recuperastatuspedidosadesao/{idAdesao}")]
        public async Task<IActionResult> RecuperaStatusPedidoAdesao(Guid idAdesao)
        {
            var statusPedido = await _pedidoBusiness.RecuperaStatusPedidoAdesao(idAdesao);
            return Ok(statusPedido);
        }

        [HttpGet("recuperapedidosdataatualadesao/{idAdesao}")]
        public async Task<IActionResult> RecuperaPedidosDataAtualAdesao(Guid idAdesao)
        {
            var pedidos = await _pedidoBusiness.RecuperaPedidosDataAtualAdesao(idAdesao);
            return Ok(pedidos);
        }

        [HttpPost("salvarpedido")]
        public async Task<IActionResult> SalvarPedido(PedidoCompletoViewModel pedidoCompleto)
        {
            var pedidos = await _pedidoBusiness.SalvarPedido(pedidoCompleto);
            return Ok(pedidos);
        }

        [HttpGet("recuperastatuspedido/{idStatus}")]
        public async Task<IActionResult> RecuperaStatusPedido(Guid idStatus)
        {
            var statusPedido = await _pedidoBusiness.RecuperaStatusPedidoPorId(idStatus);
            return Ok(statusPedido);
        }

        [HttpPost("salvastatuspedido")]
        public async Task<IActionResult> SalvaStatusPedido(StatusPedidoViewModel statusPedido)
        {
            var statuaFoiSalvo = await _pedidoBusiness.AdicionaStatusPedido(statusPedido);
            return Ok(statusPedido);
        }

        [HttpPut("atualizatatuspedido")]
        public async Task<IActionResult> AtuaizaStatusPedido(StatusPedidoViewModel statusPedido)
        {
            var statuaFoiSalvo = await _pedidoBusiness.AtualizaStatusPedido(statusPedido);
            return Ok(statuaFoiSalvo);
        }

        [HttpDelete("excluirstatuspedido/{idStatus}")]
        public async Task<IActionResult> ExcluirStatusPedido(Guid idStatus)
        {
            var statuaFoiSalvo = await _pedidoBusiness.ExcluiStatusPedido(idStatus);
            return Ok(statuaFoiSalvo);
        }
    }
}
