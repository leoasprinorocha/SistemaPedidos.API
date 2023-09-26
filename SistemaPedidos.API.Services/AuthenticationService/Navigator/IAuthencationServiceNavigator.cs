using Refit;
using SistemaPedidos.Domain.ViewModels.Usuario;

namespace SistemaPedidos.API.Services.AuthenticationService.Navigator
{
    public interface IAuthencationServiceNavigator
    {
        [Post("/authentication/login")]
        Task<LoginResponseViewModel> Login([Body] LoginUsuarioViewModel loginUsuarioViewModel,  CancellationToken cancellationToken);
    }
}
