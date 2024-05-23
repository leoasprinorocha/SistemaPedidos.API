namespace SistemaPedidos.Domain.Entities.AdesaoEmpresa
{
    public class Adesao : BaseEntity
    {
        public string NomeEmpresa { get; set; }
        public long CodigoAdesao { get; set; }
        public bool Ativo { get; set; }
        public string Telefone{ get; set; }

    }
}
