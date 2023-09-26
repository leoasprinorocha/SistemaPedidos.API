using SistemaPedidos.Domain.ViewModels.Usuario;

namespace SistemaPedidos.Domain.Interfaces.Business
{
    public interface IUsuarioBusiness
    {
        Task<UsuarioLogadoViewModel> Autenticar(string usuario, string senha);
        Task<UsuarioLogadoViewModel> CadastraNovoUsuario(CadastraUsuarioViewModel cadastraUsuarioViewModel);
        Task<Guid> RecuperaIdAdesaoUsuarioPorIdAspnetUser(Guid idAspnetUser);
    }
}
