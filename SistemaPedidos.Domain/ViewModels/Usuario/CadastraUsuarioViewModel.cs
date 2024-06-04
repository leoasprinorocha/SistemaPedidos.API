using SistemaPedidos.Domain.Enums;

namespace SistemaPedidos.Domain.ViewModels.Usuario
{
    public class CadastraUsuarioViewModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid IdAdesao { get; set; }
        public TipoUsuario TipoUsuario { get; set; }

    }
}
