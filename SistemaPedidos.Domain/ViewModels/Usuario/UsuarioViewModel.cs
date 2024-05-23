using SistemaPedidos.Domain.Enums;

namespace SistemaPedidos.Domain.ViewModels.Usuario
{
    public class UsuarioViewModel
    {
        public string Email { get; set; }
        public string Nome { get; set; }
        public Guid IdAdesao { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public bool Ativo{ get; set; }
        public string TipoUsuarioString { get { return Enum.GetName(typeof(TipoUsuario), TipoUsuario); } }
       
    }
}
