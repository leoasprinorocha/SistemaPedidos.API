namespace SistemaPedidos.Domain.ViewModels.Usuario
{
    public class LoginResponseViewModel
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public Guid IdAdesao { get; set; }
    }
}
