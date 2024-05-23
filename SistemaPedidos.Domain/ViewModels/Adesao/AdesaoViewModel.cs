namespace SistemaPedidos.Domain.ViewModels.Adesao
{
    public class AdesaoViewModel
    {
        public string NomeEmpresa { get; set; }
        public long CodigoAdesao { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; }
        public Guid Id{ get; set; }
    }
}
