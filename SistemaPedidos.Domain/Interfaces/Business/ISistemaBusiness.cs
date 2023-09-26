using SistemaPedidos.Domain.ViewModels.Sistema;

namespace SistemaPedidos.Domain.Interfaces.Business
{
    public interface ISistemaBusiness
    {
        Task<IEnumerable<ModuloViewModel>> RecuperaModulosSistema();
    }
}
