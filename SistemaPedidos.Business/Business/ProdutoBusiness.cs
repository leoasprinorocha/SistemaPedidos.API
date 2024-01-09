using Nelibur.ObjectMapper;
using SistemaPedidos.Domain.Entities;
using SistemaPedidos.Domain.Interfaces.Business;
using SistemaPedidos.Domain.Interfaces.Repository;
using SistemaPedidos.Domain.Validators;
using SistemaPedidos.Domain.ViewModels;

namespace SistemaPedidos.Business.Business
{
    public class ProdutoBusiness : IProdutoBusiness
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoBusiness(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
            TinyMapper.Bind<ProdutoViewModel, Produto>();
            TinyMapper.Bind<Produto, ProdutoViewModel>();
        }
        public async Task<bool> AdicionaProduto(ProdutoViewModel produtoViewModel)
        {
            Produto novoProduto = TinyMapper.Map<Produto>(produtoViewModel);
            var validation = new IsProdutoValid().Validate(novoProduto);
            if (!validation.IsValid)
                throw new Exception(validation.Message);

            bool produtoFoiSalvo = await _produtoRepository.AdicionaProduto(novoProduto);
            return produtoFoiSalvo;

        }

        public Task<bool> AtualizaProduto(ProdutoViewModel produto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExcluirProduto(Guid idProduto)
        {
            throw new NotImplementedException();
        }

        public async Task<Produto> RecuperaProdutoPorId(Guid idProduto)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProdutoViewModel>> RecuperaTodosProdutosAdesao(Guid idAdesao)
        {
            List<ProdutoViewModel> produtos = new();
            var produtosBanco = await _produtoRepository.RecuperaTodosProdutosAdesao(idAdesao);
            produtosBanco.ForEach(c => produtos.Add(TinyMapper.Map<ProdutoViewModel>(c)));
            return produtos;

        }
    }
}
