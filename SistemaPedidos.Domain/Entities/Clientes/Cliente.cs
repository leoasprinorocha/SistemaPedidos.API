using SistemaPedidos.Domain.Entities.AdesaoEmpresa;

namespace SistemaPedidos.Domain.Entities.Clientes
{
    public class Cliente : BaseEntity
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public Guid IdPlano { get; set; }
        public Guid IdFormaPagamento { get; set; }
        public Guid IdAdesao { get; set; }
        public bool EhPlanoMensal { get; set; }

        public virtual Adesao AdesaoCliente { get; set; }
    }
}
