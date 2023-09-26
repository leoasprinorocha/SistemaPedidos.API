using Microsoft.AspNetCore.Mvc;
using SistemaPedidos.Domain.Interfaces.Business;

namespace SistemaPedidos.API.Controllers
{
    [Route("sistema")]
    public class SistemaController : Controller
    {
        private readonly ISistemaBusiness _sistemaBusiness;

        public SistemaController(ISistemaBusiness sistemaBusiness)
        {
            _sistemaBusiness = sistemaBusiness;
        }

        [HttpGet("recuperamodulossistema")]
        public async Task<IActionResult> RecuperaModulosDoSistema()
        {
            var modulos = await _sistemaBusiness.RecuperaModulosSistema();
            return Ok(modulos);
        }
    }
}
