namespace SistemaPedidos.Domain.Entities.Pedidos
{
    public class StatusPedido : BaseEntity
    {
        public string Descricao { get; set; }
        public Guid IdAdesao{ get; set; }
    }
}
