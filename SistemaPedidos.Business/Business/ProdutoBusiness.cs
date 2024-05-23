using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Nelibur.ObjectMapper;
using SistemaPedidos.Domain.Entities;
using SistemaPedidos.Domain.Exceptions;
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
        public async Task<Tuple<bool, string>> AdicionaProduto(ProdutoViewModel produtoViewModel)
        {
            produtoViewModel.Id = Guid.NewGuid();
            Produto novoProduto = TinyMapper.Map<Produto>(produtoViewModel);
            var validation = new IsProdutoValid().Validate(novoProduto);
            if (!validation.IsValid)
                throw new BadRequestException(validation.Message);

            bool produtoFoiSalvo = await _produtoRepository.AdicionaProduto(novoProduto);
            return produtoFoiSalvo ?
            new Tuple<bool, string>(produtoFoiSalvo, "Produto salvo com sucesso") :
            new Tuple<bool, string>(false, "Falha ao salvar produto");

        }

        public async Task<bool> AtualizaProduto(ProdutoViewModel produtoViewModel)
        {
            Produto produtoBanco = TinyMapper.Map<Produto>(produtoViewModel);
            var produtoFoiAtualizado = await _produtoRepository.AtualizaProduto(produtoBanco);
            return produtoFoiAtualizado;
        }

        public async Task<bool> ExcluirProduto(Guid idProduto)
        {
            string bucketName = "pedidos-web-app";
            //string key = "path/to/your/file.txt";
            bool produtoFoiExcluido = false;
            var produtoRecuperado = await _produtoRepository.RecuperaProdutoPorId(idProduto);
            if (produtoRecuperado is not null)
            {
                (string bucketNameNotUsed, string key) = ParseS3Url(produtoRecuperado.UrlFoto);
                await DeleteFileFromS3Async(bucketName, key);
                produtoFoiExcluido = await _produtoRepository.ExcluirProduto(idProduto);
            }

            return produtoFoiExcluido;
        }

        public async Task<ProdutoViewModel> RecuperaProdutoPorId(Guid idProduto)
        {
            var produtoBanco = await _produtoRepository.RecuperaProdutoPorId(idProduto);
            ProdutoViewModel produtoDTO = new();
            if (produtoBanco is not null)
            {
                produtoDTO = TinyMapper.Map<ProdutoViewModel>(produtoBanco);
            }
            return produtoDTO;
        }

        public async Task<List<ProdutoViewModel>> RecuperaTodosProdutosAdesao(Guid idAdesao)
        {
            List<ProdutoViewModel> produtos = new();
            var produtosBanco = await _produtoRepository.RecuperaTodosProdutosAdesao(idAdesao);
            produtosBanco.ForEach(c => produtos.Add(TinyMapper.Map<ProdutoViewModel>(c)));
            return produtos;

        }

        private async Task DeleteFileFromS3Async(string bucketName, string key)
        {
            try
            {

                string accessKey = Environment.GetEnvironmentVariable("accessKeyAws_Leonardo", EnvironmentVariableTarget.Machine);
                string secretKey = Environment.GetEnvironmentVariable("secretKeyAws_Leonardo", EnvironmentVariableTarget.Machine);

                using (var client = new AmazonS3Client(awsAccessKeyId: accessKey, awsSecretAccessKey: secretKey, RegionEndpoint.SAEast1)) // Replace with your desired AWS region
                {
                    var deleteObjectRequest = new DeleteObjectRequest
                    {
                        BucketName = bucketName,
                        Key = $"fotosProdutos/{key}"
                    };

                    var responseDelete = await client.DeleteObjectAsync(deleteObjectRequest);

                    Console.WriteLine($"File '{key}' deleted successfully from '{bucketName}' bucket.");
                }
            }
            catch (AmazonS3Exception ex)
            {
                Console.WriteLine($"Error deleting file: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }

        private (string, string) ParseS3Url(string url)
        {
            try
            {
                Uri uri = new Uri(url);
                string[] segments = uri.Segments;

                if (segments.Length >= 2)
                {
                    string bucketName = segments[1].TrimEnd('/');
                    string key = string.Join("", segments, 2, segments.Length - 2);

                    return (bucketName, key);
                }
            }
            catch (UriFormatException)
            {
                // URL is not in a valid format
            }

            return (null, null);
        }
    }
}
