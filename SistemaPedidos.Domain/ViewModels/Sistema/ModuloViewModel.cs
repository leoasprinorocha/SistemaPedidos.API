namespace SistemaPedidos.Domain.ViewModels.Sistema
{
    public class ModuloViewModel
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public List<RotinaViewModel> Rotinas { get; set; }
    }
}
