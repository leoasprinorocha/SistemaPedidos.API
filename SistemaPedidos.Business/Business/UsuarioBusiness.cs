using Nelibur.ObjectMapper;
using SistemaPedidos.API.Services.AuthenticationService.Services;
using SistemaPedidos.Domain.Entities.Usuario;
using SistemaPedidos.Domain.Enums.Messages.Usuario;
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

            TinyMapper.Bind<UsuarioViewModel, Usuario>();
            TinyMapper.Bind<Usuario, UsuarioViewModel>();
        }
        public async Task<UsuarioLogadoViewModel> Autenticar(string usuario, string senha)
        {
            var usuarioBanco = await _usuarioRepository.RecuperaUsuarioPeloLogin(usuario);
            if (usuarioBanco is not null)
                return new UsuarioLogadoViewModel { Autenticado = true };
            else
                return new UsuarioLogadoViewModel { Autenticado = false };
        }

        public async Task<Tuple<bool, string>> CadastraNovoUsuario(CadastraUsuarioViewModel cadastraUsuarioViewModel)
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
                return new Tuple<bool, string>(true, UsuariosMessages.SUCESSO_SALVAR_USUARIO);
            else
                throw new Exception("Houve erro ao cadastrar usuário");
        }

        public async Task<Tuple<Guid, string>> RecuperaIdAdesaoENomeUsuarioPorIdAspnetUser(Guid idAspnetUser)
        {
            Tuple<Guid, string> result = await _usuarioRepository.RecuperaIdAdesaoENomePorIdAspnetUser(idAspnetUser);
            return result;
        }

        public async Task<List<UsuarioViewModel>> RecuperaUsuariosAdesao(Guid idAdesao)
        {
            List<UsuarioViewModel> usuarios = new();
            var usuariosBanco = await _usuarioRepository.RecuperaTodosUsuariosAdesao(idAdesao);
            usuariosBanco.ForEach(c => usuarios.Add(TinyMapper.Map<UsuarioViewModel>(c)));
            return usuarios;
        }
    }
}
