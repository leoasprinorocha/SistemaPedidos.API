namespace SistemaPedidos.Domain.Entities.Sistema
{
    public class Modulo : BaseEntity
    {
        public string Descricao { get; set; }
        public ICollection<Rotina> Rotinas { get; set; }
    }
}
