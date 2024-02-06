using Nelibur.ObjectMapper;
using SistemaPedidos.Domain.Entities.AdesaoEmpresa;
using SistemaPedidos.Domain.Interfaces.Business;
using SistemaPedidos.Domain.Interfaces.Repository;
using SistemaPedidos.Domain.ViewModels.Adesao;

namespace SistemaPedidos.Business.Business
{
    public class AdesaoBusiness : IAdesaoBusiness
    {
        private readonly IAdesaoRepository _adesaoRepository;

        public AdesaoBusiness(IAdesaoRepository adesaoRepository)
        {
            _adesaoRepository = adesaoRepository;
            TinyMapper.Bind<AdesaoViewModel, Adesao>();
            TinyMapper.Bind<Adesao, AdesaoViewModel>();
        }
        public async Task<bool> AtualizarAdesao(AdesaoViewModel adesao)
        {
            Adesao adesaoAtualizada = TinyMapper.Map<Adesao>(adesao);
            var updated = await _adesaoRepository.AtualizarAdesao(adesaoAtualizada);
            return updated;
        }

        public async Task<bool> CadastrarAdesao(AdesaoViewModel adesao)
        {
            Adesao novaAdesao = TinyMapper.Map<Adesao>(adesao);
            novaAdesao.Id = Guid.NewGuid();
            var saved = await _adesaoRepository.CadastrarAdesao(novaAdesao);
            return saved;
        }
    }
}
