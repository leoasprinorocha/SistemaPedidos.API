namespace SistemaPedidos.Domain.ViewModels.Cliente
{
    public class ClientesAdesaoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public Guid IdPlano { get; set; }
        public Guid IdFormaPagamento { get; set; }
        public Guid IdAdesao { get; set; }
        public bool EhPlanoMensal { get; set; }
    }
}
