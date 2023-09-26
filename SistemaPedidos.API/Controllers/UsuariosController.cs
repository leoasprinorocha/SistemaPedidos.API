﻿using Microsoft.AspNetCore.Mvc;
using SistemaPedidos.API.Services.AuthenticationService.Services;
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
            var idAdesao = await _usuarioBusiness.RecuperaIdAdesaoUsuarioPorIdAspnetUser(new Guid(autenticado.Id));
            autenticado.IdAdesao = idAdesao;
            return Ok(autenticado);
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> CadastrarUsuario(CadastraUsuarioViewModel cadastraUsuarioViewModel)
        {
            var usuarioCriado = await _usuarioBusiness.CadastraNovoUsuario(cadastraUsuarioViewModel);
            return Ok(usuarioCriado.Autenticado);
        }

    }
}
