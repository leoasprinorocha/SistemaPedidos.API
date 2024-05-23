using DomainValidation.Interfaces.Specification;
using SistemaPedidos.Domain.Entities.AdesaoEmpresa;
using System.Text.RegularExpressions;

namespace SistemaPedidos.Domain.Validations.Adesoes
{
    public class AdesaoTemTelefone : ISpecification<Adesao>
    {
        private string pattern = @"^\d{11}$";

        public bool IsSatisfiedBy(Adesao entity)
        {
            return ValidateBrazilianMobilePhoneNumber(entity.Telefone);
        }

        private bool ValidateBrazilianMobilePhoneNumber(string phoneNumber)
        {
            Regex regex = new Regex(pattern);
            return regex.IsMatch(phoneNumber);
        }
    }
}
