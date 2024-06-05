namespace SistemaPedidos.Domain.ViewModels.Pedido
{
    public class PedidoCompletoViewModel
    {
        public Guid IdCliente { get; set; }
        public double ValorTotal { get; set; }
        public DateTime Data { get; set; }
        public string DescricaoStatusPedido { get; set; }
        public int CodigoPedido { get; set; }
        public string Mesa { get; set; }
        public string ValorTotalString { get; set; }
        public Guid IdMesa{ get;set; }
        public Guid IdPedido { get; set; }
        public Guid IdAdesao{ get; set; }
        public Guid IdStatusPedido{ get; set; }
        public List<PedidoProdutoSimplificadoViewModel> Produtos { get; set; }
    }
}
