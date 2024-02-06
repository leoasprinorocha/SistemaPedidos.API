using Microsoft.AspNetCore.Mvc;
using SistemaPedidos.Business.Business;
using SistemaPedidos.Domain.Interfaces.Business;
using SistemaPedidos.Domain.ViewModels.Adesao;
using SistemaPedidos.Domain.ViewModels.Cliente;

namespace SistemaPedidos.API.Controllers
{
    [Route("adesao")]
    public class AdesoesController : BaseController
    {
        private readonly IAdesaoBusiness _adesaoBusiness;

        public AdesoesController(IAdesaoBusiness adesaoBusiness)
        {
            _adesaoBusiness = adesaoBusiness;
        }

        [HttpPost("cadastraadesao")]
        public async Task<IActionResult> CadastraAdesao(AdesaoViewModel novaAdesao)
        {
            var adesaoFoiSalva = await _adesaoBusiness.CadastrarAdesao(novaAdesao);
            return Ok(adesaoFoiSalva);
        }

        [HttpPut("atualizaradesao")]
        public async Task<IActionResult> AtualizaAdesao(AdesaoViewModel novaAdesao)
        {
            var adesaoFoiAtualizada = await _adesaoBusiness.AtualizarAdesao(novaAdesao);
            return Ok(adesaoFoiAtualizada);
        }
    }
}
