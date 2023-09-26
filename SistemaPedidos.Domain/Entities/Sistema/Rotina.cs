namespace SistemaPedidos.Domain.Entities.Sistema
{
    public class Rotina : BaseEntity
    {
        public string Descricao { get; set; }
        public string RotaUrl { get; set; }
        public Guid ModuloId { get; set; }
        public Modulo Modulo { get; set; }
    }
}
