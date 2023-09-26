using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaPedidos.API.Services.AuthenticationService.Services;

namespace SistemaPedidos.API.Configurations
{
    public static class AuthenticationServiceSetup
    {
        private static IConfiguration _configuration;

        public static string UrlAuthApi => _configuration.ReadConfig<string>("ApiAuth", "ApiAuthUrl");

        public static void SetAuthenticationServiceSetup(this IServiceCollection services, IConfiguration configuration)
        {
            _configuration = configuration;

            services.SetNavigatorServices();
        }

        private static void SetNavigatorServices(this IServiceCollection services)
        {
            services.AddScoped<ApiAuthService>();

        }


    }
}
