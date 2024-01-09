using DomainValidation.Interfaces.Specification;
using SistemaPedidos.Domain.Entities;

namespace SistemaPedidos.Domain.Validations.Produtos
{
    public class ProdutoTemDescricao : ISpecification<Produto>
    {
        public bool IsSatisfiedBy(Produto entity)
        {
            return !string.IsNullOrWhiteSpace(entity.Descricao);
        }
    }
}
