﻿using Microsoft.EntityFrameworkCore;
using SistemaPedidos.Domain.Entities.Pedidos;
using SistemaPedidos.Domain.Interfaces.Repository;

namespace SistemaPedidos.Orm.Core.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly SistemaPedidosContext _context;

        public PedidoRepository(SistemaPedidosContext context)
        {
            _context = context;
        }

        public async Task<bool> AdicionaStatusPedido(StatusPedido statusPedido)
        {
            await _context.StatusPedido.AddAsync(statusPedido);
            var statusFoiSalvo = await _context.SaveChangesAsync();
            return statusFoiSalvo > 0;
        }

        public async Task<bool> AtualizaStatusPedido(StatusPedido statusPedido)
        {
            var statusPedidoBanco = await _context.StatusPedido.FirstOrDefaultAsync(c => c.Id == statusPedido.Id);
            bool statusPedidoFoiAtualizado = false;
            if (statusPedidoBanco is not null)
            {
                statusPedidoBanco.Descricao = statusPedido.Descricao;
                _context.StatusPedido.Update(statusPedidoBanco);
                var result = await _context.SaveChangesAsync();
                statusPedidoFoiAtualizado = result > 0;
            }

            return statusPedidoFoiAtualizado;
        }

        public async Task<bool> ExcluiStatusPedido(Guid idStatus)
        {
            bool statusPedidoFoiExcluido = false;
            var statusPedidoExiste = await _context.StatusPedido.FirstOrDefaultAsync(c => c.Id == idStatus);
            if (statusPedidoExiste is not null)
            {
                _context.StatusPedido.Remove(statusPedidoExiste);
                statusPedidoFoiExcluido = await _context.SaveChangesAsync() > 0;
            }

            return statusPedidoFoiExcluido;
        }

        public async Task<List<Pedido>> RecuperaPedidosDataAtualAdesao(Guid idAdesao)
        {
            var pedidosDataAtualAdesao = await _context.Pedido.Where(a => a.IdAdesao == idAdesao).ToListAsync();
            return pedidosDataAtualAdesao;
        }

        public async Task<List<PedidoProduto>> RecuperaProdutosDoPedido(Guid idPedido)
        {
            var produtosDoPedido = await _context.PedidoProduto.Where(a => a.IdPedido == idPedido).ToListAsync();
            return produtosDoPedido;
        }

        public async Task<List<StatusPedido>> RecuperaStatusPedidoAdesao(Guid idAdesao)
        {
            var statusPedidoAdesao = await _context.StatusPedido.AsNoTracking().Where(c => c.IdAdesao == idAdesao).ToListAsync();
            return statusPedidoAdesao;
        }

        public async Task<StatusPedido> RecuperaStatusPedidoPorId(Guid idStatus)
        {
            StatusPedido statusPedido;
            statusPedido = await _context.StatusPedido.AsNoTracking().FirstOrDefaultAsync(o => o.Id == idStatus);
            return statusPedido;
        }

        public async Task<Tuple<bool, Guid>> SalvarMesa(Mesa mesa)
        {
            await _context.Mesa.AddAsync(mesa);
            int registroSalvo = await _context.SaveChangesAsync();
            if (registroSalvo > 0)
            {
                return new Tuple<bool, Guid>(true, mesa.Id);
            }
            else
            {
                return new Tuple<bool, Guid>(false, Guid.Empty);
            }
            

        }

        public async Task<bool> SalvarPedido(Pedido pedido)
        {
            await _context.Pedido.AddAsync(pedido);
            int registroSalvo = await _context.SaveChangesAsync();
            return registroSalvo > 0;
        }
    }
}
