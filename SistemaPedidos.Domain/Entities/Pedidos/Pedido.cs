namespace SistemaPedidos.Domain.Entities.Pedidos
{
    public class Pedido : BaseEntity
    {
        public Guid IdCliente { get; set; }
        public double ValorTotal { get; set; }
        public DateTime Data { get; set; }
        public Guid IdStatusPedido { get; set; }
        public int CodigoPedido { get; set; }
        public string Mesa { get; set; }
        public Guid IdAdesao{ get; set; }
    }
}
