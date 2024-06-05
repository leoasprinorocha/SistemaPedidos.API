using SistemaPedidos.Domain.Enums;

namespace SistemaPedidos.Domain.Entities.Pedidos
{
    public class Mesa : BaseEntity
    {
        public Mesa(Guid id, string descricao, double valorTotal)
        {
            this.Descricao = descricao;
            this.ValorTotal = valorTotal;
            this.Status = StatusMesaEnum.Aberta;
        }



        public string Descricao { get; set; }
        public double ValorTotal { get; set; }
        public StatusMesaEnum Status { get; set; }


    }
}
