using Microsoft.AspNetCore.Mvc;
using SistemaPedidos.Business.Business;
using SistemaPedidos.Domain.Interfaces.Business;
using SistemaPedidos.Domain.ViewModels;
using SistemaPedidos.Domain.ViewModels.Cliente;

namespace SistemaPedidos.API.Controllers
{
    [Route("produto")]
    public class ProdutosController : BaseController
    {
        private readonly IProdutoBusiness _produtoBusiness;
        public ProdutosController(IProdutoBusiness produtoBusiness)
        {
            _produtoBusiness = produtoBusiness;
        }

        [HttpGet("recuperaprodutosadesao/{idAdesao}")]
        public async Task<IActionResult> RecuperaProdutosAdesao(Guid idAdesao)
        {
            var produtos = await _produtoBusiness.RecuperaTodosProdutosAdesao(idAdesao);
            return Ok(produtos);
        }

        [HttpPost("cadastraproduto")]
        public async Task<IActionResult> CadastraProduto(ProdutoViewModel produtoViewModel)
        {
            var produtoFoiCriado = await _produtoBusiness.AdicionaProduto(produtoViewModel); 
            return Ok(produtoFoiCriado);
        }
    }
}
