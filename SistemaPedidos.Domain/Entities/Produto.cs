namespace SistemaPedidos.Domain.Entities
{
    public class Produto : BaseEntity
    {
        public string Descricao { get; set; }
        public double Preco{ get; set; }
        public string UrlFoto{ get; set; }
        public Guid IdAdesao{ get; set; }
    }
}
