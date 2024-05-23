using DomainValidation.Validation;
using SistemaPedidos.Domain.Entities.AdesaoEmpresa;
using SistemaPedidos.Domain.Validations.Adesoes;

namespace SistemaPedidos.Domain.Validators
{
    public class IsAdesaoValid : Validator<Adesao>
    {
        public IsAdesaoValid()
        {
            Add("AdesaoTemTelefone", new Rule<Adesao>(new AdesaoTemTelefone(), "Telefone válido obrigatório!"));
            

        }
    }
}
