namespace SistemaPedidos.Domain.ViewModels.Sistema
{
    public class RotinaViewModel
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public string RotaUrl { get; set; }
        public Guid ModuloId { get; set; }
    }
}
