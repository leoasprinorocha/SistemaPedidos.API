using Nelibur.ObjectMapper;
using SistemaPedidos.Domain.Entities.Clientes;
using SistemaPedidos.Domain.Interfaces.Business;
using SistemaPedidos.Domain.Interfaces.Repository;
using SistemaPedidos.Domain.ViewModels.Cliente;

namespace SistemaPedidos.Business.Business
{
    public class ClienteBusiness : IClienteBusiness
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteBusiness(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
            TinyMapper.Bind<ClientesAdesaoViewModel, Cliente>();
            TinyMapper.Bind<Cliente, ClientesAdesaoViewModel>();
        }
        public async Task<Tuple<bool, string>> AdicionaCliente(ClientesAdesaoViewModel cliente)
        {
            Cliente novoCliente = TinyMapper.Map<Cliente>(cliente);
            novoCliente.Id = Guid.NewGuid();
            var clienteAdicionado = await _clienteRepository.AdicionaCliente(novoCliente);
            return clienteAdicionado ?
            new Tuple<bool, string>(clienteAdicionado, "Cliente salvo com sucesso") :
            new Tuple<bool, string>(false, "Falha ao adicionar cliente");
        }

        public async Task<Tuple<bool, string>> AtualizaCliente(ClientesAdesaoViewModel cliente)
        {
            Cliente clienteASerAtualizado = TinyMapper.Map<Cliente>(cliente);
            var clienteFoiAtualizado = await _clienteRepository.AtualizaCliente(clienteASerAtualizado);
            return clienteFoiAtualizado ?
            new Tuple<bool, string>(clienteFoiAtualizado, "Cliente atualizado com sucesso") :
            new Tuple<bool, string>(false, "Falha ao atualizar cliente");

        }

        public async Task<Tuple<bool, string>> ExcluirCliente(Guid idCliente)
        {
            var clienteExcluido = await _clienteRepository.ExcluirCliente(idCliente);
            return clienteExcluido ?
            new Tuple<bool, string>(clienteExcluido, "Cliente excluído com sucesso") :
            new Tuple<bool, string>(false, "Falha ao excluir cliente");
        }

        public async Task<ClientesAdesaoViewModel> RecuperaClientePorId(Guid idCliente)
        {
            var clienteBanco = await _clienteRepository.RecuperaClientePorId(idCliente);
            if (clienteBanco is not null)
            {
                ClientesAdesaoViewModel novoCliente = TinyMapper.Map<ClientesAdesaoViewModel>(clienteBanco);
                return novoCliente;
            }
            return null;
        }


        public async Task<List<ClientesAdesaoViewModel>> RecuperaTodosClientesPorAdesao(Guid idAdesao)
        {
            List<ClientesAdesaoViewModel> clientes = new();
            var clientesBanco = await _clienteRepository.RecuperaTodosClientesPorAdesao(idAdesao);
            clientesBanco.ForEach(c => clientes.Add(TinyMapper.Map<ClientesAdesaoViewModel>(c)));
            return clientes;

        }
    }
}
