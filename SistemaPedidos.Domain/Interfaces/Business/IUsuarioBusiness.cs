using SistemaPedidos.Domain.ViewModels.Usuario;

namespace SistemaPedidos.Domain.Interfaces.Business
{
    public interface IUsuarioBusiness
    {
        Task<UsuarioLogadoViewModel> Autenticar(string usuario, string senha);
        Task<UsuarioLogadoViewModel> CadastraNovoUsuario(CadastraUsuarioViewModel cadastraUsuarioViewModel);
        Task<Tuple<Guid, string>> RecuperaIdAdesaoENomeUsuarioPorIdAspnetUser(Guid idAspnetUser);

        Task<List<UsuarioViewModel>> RecuperaUsuariosAdesao(Guid idAdesao);
    }
}
