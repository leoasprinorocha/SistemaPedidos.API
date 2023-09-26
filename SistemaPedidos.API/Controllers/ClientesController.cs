using Microsoft.AspNetCore.Mvc;
using SistemaPedidos.Domain.Interfaces.Business;

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
    }
}
