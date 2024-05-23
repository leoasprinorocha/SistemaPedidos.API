using Microsoft.EntityFrameworkCore;
using SistemaPedidos.Domain.Entities.Clientes;
using SistemaPedidos.Domain.Interfaces.Repository;

namespace SistemaPedidos.Orm.Core.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly SistemaPedidosContext _context;
        public ClienteRepository(SistemaPedidosContext context)
        {
            _context = context;
        }

        public async Task<bool> AdicionaCliente(Cliente cliente)
        {
            var adesaoExistente = await _context.Adesao.FirstOrDefaultAsync(c => c.Id == cliente.IdAdesao);
            cliente.AdesaoCliente = adesaoExistente;
            await _context.Cliente.AddAsync(cliente);
            var saved = await _context.SaveChangesAsync();
            return saved >= 1;
        }

        public async Task<bool> AtualizaCliente(Cliente cliente)
        {
            var clienteBanco = await _context.Cliente.FirstOrDefaultAsync(c => c.Id == cliente.Id);
            if (clienteBanco is not null)
            {
                clienteBanco.Nome = cliente.Nome;
                clienteBanco.Telefone = cliente.Telefone;
                clienteBanco.Endereco = cliente.Endereco;
                clienteBanco.EhPlanoMensal = cliente.EhPlanoMensal;
                clienteBanco.IdPlano = cliente.IdPlano;
                clienteBanco.IdFormaPagamento = cliente.IdFormaPagamento;

                _context.Cliente.Update(clienteBanco);
                var updated = await _context.SaveChangesAsync();
                return updated >= 1;
            }

            return false;
        }

        public async Task<bool> ExcluirCliente(Guid idCliente)
        {
            var clienteExistente = await _context.Cliente.FirstOrDefaultAsync(c => c.Id == idCliente);
            if (clienteExistente is not null)
            {
                _context.Cliente.Remove(clienteExistente);
                var removed = await _context.SaveChangesAsync();
                return removed >= 1;
            }
            return false;
        }

        public async Task<Cliente> RecuperaClientePorId(Guid idCliente)
        {
            var cliente = await _context.Cliente.AsNoTracking().FirstOrDefaultAsync(c => c.Id == idCliente);
            return cliente;
        }

        public async Task<List<Cliente>> RecuperaTodosClientesPorAdesao(Guid idAdesao)
        {
            var clientes = await _context.Cliente.AsNoTracking().Where(c => c.IdAdesao == idAdesao).ToListAsync();
            return clientes;
        }
    }
}
