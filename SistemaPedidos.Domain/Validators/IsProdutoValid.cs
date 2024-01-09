using DomainValidation.Validation;
using SistemaPedidos.Domain.Entities;
using SistemaPedidos.Domain.Validations.Produtos;
using System;

namespace SistemaPedidos.Domain.Validators
{
    public class IsProdutoValid : Validator<Produto>
    {
        public IsProdutoValid()
        {
            Add("ProdutoTemDescricao", new Rule<Produto>(new ProdutoTemDescricao(), "Descrição do produto é obrigatório!"));
            Add("ProdutoTemPreco", new Rule<Produto>(new ProdutoTemPrecoMaiorQueZero(), "Preço deve ser maior que zero"));

        }
    }
}
