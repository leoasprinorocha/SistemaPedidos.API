using Microsoft.EntityFrameworkCore;
using SistemaPedidos.Business.Business;
using SistemaPedidos.Domain.Interfaces.Business;
using SistemaPedidos.Domain.Interfaces.Repository;
using SistemaPedidos.Orm.Core;
using SistemaPedidos.Orm.Core.Repositories;

namespace SistemaPedidos.API.Configurations
{
    public static class ApiConfiguration
    {
        public static void AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            #region DataBaseConfig
            var mySqlPath = "MySql";

            var host = configuration.ReadConfig<string>(mySqlPath, "Host");
            var dataBase = configuration.ReadConfig<string>(mySqlPath, "DataBaseName");
            var userName = configuration.ReadConfig<string>(mySqlPath, "User");
            var password = configuration.ReadConfig<string>(mySqlPath, "Password");
            var timeOut = configuration.ReadConfig<int>(mySqlPath, "Timeout");
            var maxPoolSize = configuration.ReadConfig<int>(mySqlPath, "MaxPoolSize");
            var defaultCommandTimeout = configuration.ReadConfig<int>(mySqlPath, "DefaultCommandTimeout");

            var connectionString = $"Server={host};Database={dataBase};Uid={userName};Pwd={password};default command timeout={defaultCommandTimeout};Connection Timeout={timeOut};Max Pool Size={maxPoolSize}";
            var serverVersion = ServerVersion.AutoDetect(connectionString);

            services.AddDbContext<SistemaPedidosContext>(options =>
            {
                options.UseMySql(connectionString, serverVersion, mySqlOptions => mySqlOptions.MigrationsAssembly("SistemaPedidos.API"));

            });
            #endregion

            #region Depency Injection
            services.AddScoped<IUsuarioBusiness, UsuarioBusiness>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddScoped<ISistemaBusiness, SistemaBusiness>();
            services.AddScoped<ISistemaRepository, SistemaRepository>();

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteBusiness, ClienteBusiness>();

            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoBusiness, ProdutoBusiness>();

            #endregion
        }
    }
}
