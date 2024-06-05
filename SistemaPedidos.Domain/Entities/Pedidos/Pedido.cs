namespace SistemaPedidos.Domain.Entities.Pedidos
{
    public class Pedido : BaseEntity
    {
        public Pedido(Guid idMesa, double valorTotal, string mesa, Guid idAdesao, Guid idStatusPedido)
        {
            this.IdMesa = idMesa;
            this.ValorTotal = valorTotal;
            this.Mesa = mesa;
            this.IdAdesao = idAdesao;
            this.IdStatusPedido = idStatusPedido;
            this.Data = DateTime.Now;
        }
        public Guid IdCliente { get; set; }
        public double ValorTotal { get; set; }
        public DateTime Data { get; set; }
        public Guid IdStatusPedido { get; set; }
        public int CodigoPedido { get; set; }
        public string Mesa { get; set; }
        public Guid IdMesa { get; set; }
        public Guid IdAdesao { get; set; }
    }
}
