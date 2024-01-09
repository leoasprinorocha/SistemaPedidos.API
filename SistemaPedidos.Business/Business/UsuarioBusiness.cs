using Nelibur.ObjectMapper;
using SistemaPedidos.API.Services.AuthenticationService.Services;
using SistemaPedidos.Domain.Entities.Usuario;
using SistemaPedidos.Domain.Interfaces.Business;
using SistemaPedidos.Domain.Interfaces.Repository;
using SistemaPedidos.Domain.ViewModels.Usuario;


namespace SistemaPedidos.Business.Business
{
    public class UsuarioBusiness : IUsuarioBusiness
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ApiAuthService _apiAuthService;

        public UsuarioBusiness(IUsuarioRepository usuarioRepository, ApiAuthService apiAuthService)
        {
            _usuarioRepository = usuarioRepository;
            _apiAuthService = apiAuthService;
        }
        public async Task<UsuarioLogadoViewModel> Autenticar(string usuario, string senha)
        {
            var usuarioBanco = await _usuarioRepository.RecuperaUsuarioPeloLogin(usuario);
            if (usuarioBanco is not null)
                return new UsuarioLogadoViewModel { Autenticado = true };
            else
                return new UsuarioLogadoViewModel { Autenticado = false };
        }

        public async Task<UsuarioLogadoViewModel> CadastraNovoUsuario(CadastraUsuarioViewModel cadastraUsuarioViewModel)
        {

            TinyMapper.Bind<CadastraUsuarioViewModel, Usuario>();
            Usuario novoUsuario = TinyMapper.Map<Usuario>(cadastraUsuarioViewModel);
            novoUsuario.Id = Guid.NewGuid();

            RegisterUserAuthServiceViewModel registerUser = new()
            {
                Email = novoUsuario.Email,
                Password = novoUsuario.Password,
                ConfirmPassword = novoUsuario.Password,
            };

            var userIdentityCreated = await _apiAuthService.Register(registerUser);
            novoUsuario.IdAspnetUser = new Guid(userIdentityCreated);

            var usuarioSalvo = await _usuarioRepository.CadastraNovoUsuario(novoUsuario);
            if (usuarioSalvo is not null)
                return new UsuarioLogadoViewModel { Autenticado = true };
            else
                throw new Exception("Houve erro ao cadastrar usuário");
        }

        public async Task<Guid> RecuperaIdAdesaoUsuarioPorIdAspnetUser(Guid idAspnetUser)
        {
            Guid idAdesao = await _usuarioRepository.RecuperaIdAdesaoPorIdAspnetUser(idAspnetUser);
            return idAdesao;
        }
    }
}
