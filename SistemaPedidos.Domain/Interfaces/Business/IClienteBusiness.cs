using SistemaPedidos.Domain.ViewModels.Cliente;

namespace SistemaPedidos.Domain.Interfaces.Business
{
    public interface IClienteBusiness
    {
        Task<List<ClientesAdesaoViewModel>> RecuperaTodosClientesPorAdesao(Guid idAdesao);
        Task<ClientesAdesaoViewModel> RecuperaClientePorId(Guid idCliente);
        Task<Tuple<bool, string>> AdicionaCliente(ClientesAdesaoViewModel cliente);
        Task<Tuple<bool, string>> AtualizaCliente(ClientesAdesaoViewModel cliente);
        Task<Tuple<bool, string>> ExcluirCliente(Guid idCliente);
    }
}
