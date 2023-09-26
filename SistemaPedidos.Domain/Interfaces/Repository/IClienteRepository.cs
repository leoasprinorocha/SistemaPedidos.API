using SistemaPedidos.Domain.Entities.Clientes;

namespace SistemaPedidos.Domain.Interfaces.Repository
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> RecuperaTodosClientesPorAdesao(Guid idAdesao);
        Task<Cliente> RecuperaClientePorId(Guid idCliente);
        Task<bool> AdicionaCliente(Cliente cliente);
        Task<bool> AtualizaCliente(Cliente cliente);
        Task<bool> ExcluirCliente(Guid idCliente);
    }
}
