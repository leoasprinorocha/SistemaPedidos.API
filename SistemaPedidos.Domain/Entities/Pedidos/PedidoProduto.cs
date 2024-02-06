namespace SistemaPedidos.Domain.Entities.Pedidos
{
    public class PedidoProduto : BaseEntity
    {
        public Guid IdPedido { get; set; }
        public Guid IdProduto { get; set; }
    }
}
