using SistemaPedidos.Domain.Entities.AdesaoEmpresa;
namespace SistemaPedidos.Domain.Entities.Usuario
{
    public class Usuario : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nome { get; set; }
        public Guid IdAdesao { get; set; }
        public Guid IdAspnetUser{ get; set; }

        public virtual Adesao AdesaoUsuario { get; set; }

    }
}
