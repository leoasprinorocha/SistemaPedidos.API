using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;
using System.Diagnostics;


namespace SistemaPedidos.API.Services
{
    public abstract class BaseRefitNav<TNavigator>
    {
        protected readonly string _host;

        public BaseRefitNav(string host)
        {
            this._host = host;
        }

        public TNavigator GetNavigator()
        {
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.None,
                Error = (sender, args) => Debug.WriteLine(args)
            };

            var navigator = RestService.For<TNavigator>(this._host, new RefitSettings
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer(jsonSerializerSettings)
            });

            return navigator;
        }

        protected CancellationToken GetCancellationToken()
        {
            using (CancellationTokenSource tokenSource = new CancellationTokenSource())
            {
                tokenSource.CancelAfter(1000 * 60); // 1 Minuto aguardando a requisição
                CancellationToken token = tokenSource.Token;

                return token;
            }
        }
    }
}
