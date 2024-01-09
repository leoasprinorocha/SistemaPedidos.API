using DomainValidation.Interfaces.Specification;
using SistemaPedidos.Domain.Entities;

namespace SistemaPedidos.Domain.Validations.Produtos
{
    public class ProdutoTemPrecoMaiorQueZero : ISpecification<Produto>
    {
        public bool IsSatisfiedBy(Produto entity)
        {
            return entity.Preco > 0;
        }
    }
}
