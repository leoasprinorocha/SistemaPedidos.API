using Microsoft.AspNetCore.Mvc;
using SistemaPedidos.Domain.Interfaces.Business;
using SistemaPedidos.Domain.ViewModels.Cliente;

namespace SistemaPedidos.API.Controllers
{
    [Route("cliente")]
    public class ClientesController : BaseController
    {
        private readonly IClienteBusiness _clienteBusiness;
        public ClientesController(IClienteBusiness clienteBusiness)
        {
            _clienteBusiness = clienteBusiness;
        }

        [HttpGet("recuperaclientesadesao/{idAdesao}")]
        public async Task<IActionResult> RecuperaClientesAdesao(Guid idAdesao)
        {
            var clientes = await _clienteBusiness.RecuperaTodosClientesPorAdesao(idAdesao);
            return Ok(clientes);
        }

        [HttpGet("recuperaclienteadesao/{idCliente}")]
        public async Task<IActionResult> RecuperaClienteAdesao(Guid idCliente)
        {
            var cliente = await _clienteBusiness.RecuperaClientePorId(idCliente);
            return Ok(cliente);
        }

        [HttpPut("atualizacliente")]
        public async Task<IActionResult> AtualizaCliente(ClientesAdesaoViewModel clienteAdesao)
        {
            var cliente = await _clienteBusiness.AtualizaCliente(clienteAdesao);
            return Ok(cliente);
        }

        [HttpPost("cadastracliente")]
        public async Task<IActionResult> CadastraCliente(ClientesAdesaoViewModel clienteAdesao)
        {
            var cliente = await _clienteBusiness.AdicionaCliente(clienteAdesao);
            return Ok(cliente);
        }

        [HttpDelete("excluircliente/{idCliente}")]
        public async Task<IActionResult> ExcluirCliente(Guid idCliente)
        {
            var cliente = await _clienteBusiness.ExcluirCliente(idCliente);
            return Ok(cliente);
        }
    }
}
