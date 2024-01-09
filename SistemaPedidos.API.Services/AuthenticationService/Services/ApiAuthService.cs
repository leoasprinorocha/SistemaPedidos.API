using SistemaPedidos.API.Configurations;
using SistemaPedidos.API.Services.AuthenticationService.Navigator;
using SistemaPedidos.Domain.ViewModels.Usuario;

namespace SistemaPedidos.API.Services.AuthenticationService.Services
{
    public class ApiAuthService : BaseRefitNav<IAuthencationServiceNavigator>
    {
        public ApiAuthService() : base(AuthenticationServiceSetup.UrlAuthApi)
        {

        }


        public async Task<LoginResponseViewModel> Login(LoginUsuarioViewModel loginUsuarioViewModel)
        {
            var navigator = GetNavigator();
            var loginResponse = await navigator.Login(loginUsuarioViewModel, GetCancellationToken());
            return loginResponse;
        }

        public async Task<string> Register(RegisterUserAuthServiceViewModel registerUser)
        {
            var navigator = GetNavigator();
            var registerResponse = await navigator.Register(registerUser, GetCancellationToken());
            return registerResponse;
        }
    }
}
