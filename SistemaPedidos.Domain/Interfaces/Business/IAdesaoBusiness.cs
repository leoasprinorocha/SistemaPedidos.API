using SistemaPedidos.Domain.ViewModels.Adesao;

namespace SistemaPedidos.Domain.Interfaces.Business
{
    public interface IAdesaoBusiness
    {
        Task<bool> CadastrarAdesao(AdesaoViewModel adesao);
        Task<bool> AtualizarAdesao(AdesaoViewModel adesao);
    }
}
