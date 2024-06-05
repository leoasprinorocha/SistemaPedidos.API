namespace SistemaPedidos.Domain.ViewModels.Pedido
{
    public class PedidoProdutoSimplificadoViewModel
    {
        public string DescricaoProduto { get; set; }
        public int Quantidade { get; set; }
        public Guid IdProduto{ get; set; }
        public double Preco { get; set; } = 0;
    }
}
