using SistemaPedidos.Domain.Entities.AdesaoEmpresa;

namespace SistemaPedidos.Domain.Interfaces.Repository
{
    public interface IAdesaoRepository
    {
        Task<bool> CadastrarAdesao(Adesao adesao);
        Task<bool> AtualizarAdesao(Adesao adesao);
    }
}
