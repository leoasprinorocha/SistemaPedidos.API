using SistemaPedidos.Domain.Entities.Sistema;

namespace SistemaPedidos.Domain.Interfaces.Repository
{
    public interface ISistemaRepository
    {
        Task<IEnumerable<Modulo>> RecuperaModulosSistema();
    }
}
