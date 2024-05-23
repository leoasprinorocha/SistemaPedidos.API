using SistemaPedidos.Domain.Entities.AdesaoEmpresa;
using SistemaPedidos.Domain.Enums;
namespace SistemaPedidos.Domain.Entities.Usuario
{
    public class Usuario : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nome { get; set; }
        public Guid IdAdesao { get; set; }
        public Guid IdAspnetUser { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public bool Ativo{ get; set; }

        public virtual Adesao AdesaoUsuario { get; set; }

    }
}
