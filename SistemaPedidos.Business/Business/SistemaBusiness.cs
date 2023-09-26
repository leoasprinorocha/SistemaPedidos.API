using Nelibur.ObjectMapper;
using SistemaPedidos.Domain.Entities.Sistema;
using SistemaPedidos.Domain.Entities.Usuario;
using SistemaPedidos.Domain.Interfaces.Business;
using SistemaPedidos.Domain.Interfaces.Repository;
using SistemaPedidos.Domain.ViewModels.Sistema;
using SistemaPedidos.Domain.ViewModels.Usuario;
using System.Net;

namespace SistemaPedidos.Business.Business
{
    public class SistemaBusiness : ISistemaBusiness
    {
        private readonly ISistemaRepository _sistemaRepository;

        public SistemaBusiness(ISistemaRepository sistemaRepository)
        {
            _sistemaRepository = sistemaRepository;
        }
        public async Task<IEnumerable<ModuloViewModel>> RecuperaModulosSistema()
        {
            var modulosBanco = await _sistemaRepository.RecuperaModulosSistema();
            List<ModuloViewModel> modulosSistema = new();
            TinyMapper.Bind<Rotina, RotinaViewModel>();
            TinyMapper.Bind<Modulo, ModuloViewModel>(config =>
            {
                config.Ignore(c => c.Rotinas);
            });

            MappingModulos(ref modulosSistema, modulosBanco);
            return modulosSistema;

        }

        public void MappingModulos(ref List<ModuloViewModel> modulosViewModel, IEnumerable<Modulo> modulosBanco)
        {
            foreach (var modulo in modulosBanco)
            {
                var moduloViewModel = TinyMapper.Map<ModuloViewModel>(modulo);
                moduloViewModel.Rotinas = MappingRotinas(modulo.Rotinas);
                modulosViewModel.Add(moduloViewModel);

            }
        }

        public List<RotinaViewModel> MappingRotinas(IEnumerable<Rotina> rotinasBanco)
        {
            List<RotinaViewModel> rotinas = new();
            foreach (var rotina in rotinasBanco)
            {
                var rotinaViewModel = TinyMapper.Map<RotinaViewModel>(rotina);
                rotinas.Add(rotinaViewModel);
            }
            return rotinas;
        }
    }
}
