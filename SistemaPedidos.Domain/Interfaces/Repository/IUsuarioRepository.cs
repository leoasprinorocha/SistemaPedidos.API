using SistemaPedidos.Domain.Entities.Usuario;

namespace SistemaPedidos.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository
    {
        Task<Usuario> RecuperaUsuarioPeloLogin(string login);
        Task<Usuario> CadastraNovoUsuario(Usuario usuario);
        Task<Guid> RecuperaIdAdesaoPorIdAspnetUser(Guid idAspnetUser);
    }
}
