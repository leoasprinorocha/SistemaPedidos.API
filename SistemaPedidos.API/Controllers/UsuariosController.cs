using Microsoft.AspNetCore.Mvc;
using SistemaPedidos.API.Services.AuthenticationService.Services;
using SistemaPedidos.API.Utils;
using SistemaPedidos.Domain.Interfaces.Business;
using SistemaPedidos.Domain.ViewModels.Usuario;

namespace SistemaPedidos.API.Controllers
{
    [Route("usuarios")]
    public class UsuariosController : Controller
    {

        private readonly IUsuarioBusiness _usuarioBusiness;
        private readonly ApiAuthService _apiAuthService;

        public UsuariosController(IUsuarioBusiness usuarioBusiness, ApiAuthService apiAuthService)
        {
            this._usuarioBusiness = usuarioBusiness;
            this._apiAuthService = apiAuthService;

        }

        [HttpGet("autenticar/{usuario}/{senha}")]
        public async Task<IActionResult> AutenticarUsuario(string usuario, string senha)
        {
            LoginUsuarioViewModel login = new() { Email = usuario, Password = senha };
            var autenticado = await _apiAuthService.Login(login);
            var result = await _usuarioBusiness.RecuperaIdAdesaoENomeUsuarioPorIdAspnetUser(new Guid(autenticado.Id));
            autenticado.IdAdesao = result.Item1;
            autenticado.Name = result.Item2;
            return Ok(autenticado);
        }

        [HttpGet("recupera-usuarios-adesao/{adesaoId}")]
        public async Task<IActionResult> RecuperaUsuariosAdesao(Guid adesaoId)
        {
            var usuariosAdesao = await _usuarioBusiness.RecuperaUsuariosAdesao(adesaoId);
            return Ok(usuariosAdesao);
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> CadastrarUsuario(CadastraUsuarioViewModel cadastraUsuarioViewModel)
        {
            var usuarioCriado = await _usuarioBusiness.CadastraNovoUsuario(cadastraUsuarioViewModel);
            return Ok(usuarioCriado.Autenticado);
        }

    }
}
