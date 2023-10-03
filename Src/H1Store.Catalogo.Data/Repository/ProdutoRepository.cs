using H1Store.Catalogo.Domain.Entities;
using H1Store.Catalogo.Domain.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1Store.Catalogo.Data.Repository
{
	public class ProdutoRepository : IProdutoRepository
	{
        private readonly string _produtoCaminhoArquivo;

        public ProdutoRepository()
        {
             _produtoCaminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "FileJsonData", "produto.json");
        }

        public async Task Adicionar(Produto produto)
        {
             var produtos = await LerProdutosDoArquivoAsync();
             int proximoCodigo = ObterProximoCodigoDisponivel(produtos);
             produto.SetaCodigoProduto(proximoCodigo);
             produtos.Add(produto);
             await EscreverProdutosNoArquivoAsync(produtos);
        }

        public async Task Atualizar(Produto produto, Produto produtoExistente)
        {
             var produtos = await LerProdutosDoArquivoAsync();
             var produtoExistente = produtos.FirstOrDefault(p => p.Codigo == produto.Codigo);
             if (produtoExistente != null)
             {
                 produtoExistente.Nome = produto.Nome;
                 produtoExistente.Descricao = produto.Descricao;
                 produtoExistente.Ativo = produto.Ativo;
                 produtoExistente.Valor = produto.Valor;
                 produtoExistente.DataCadastro = produto.DataCadastro;
                 produtoExistente.Imagem = produto.Imagem;
                 produtoExistente.QuantidadeEstoque = produto.QuantidadeEstoque;
             }
             await EscreverProdutosNoArquivoAsync(produtos);
        }

        public async Task<IEnumerable<Produto>> ObterTodos()
        {
             return await LerProdutosDoArquivoAsync();
        }

        public async Task<Produto> ObterPorId(Guid id)
        {
             var produtos = await LerProdutosDoArquivoAsync();
             return produtos.FirstOrDefault(p => p.Id == id);
        }

        public async Task<IEnumerable<Produto>> ObterPorCategoria(int codigo)
        {
             var produtos = await LerProdutosDoArquivoAsync();
             return produtos.Where(p => p.Categoria.Codigo == codigo);
        }

        public async Task Remover(int codigo)
        {
             var produtos = await LerProdutosDoArquivoAsync();
             var produtoExistente = produtos.FirstOrDefault(p => p.Codigo == codigo);
             if (produtoExistente != null)
             {
                    produtos.Remove(produtoExistente);
                    await EscreverProdutosNoArquivoAsync(produtos);
             }
        }

        private async Task<List<Produto>> LerProdutosDoArquivoAsync()
        {
             if (!File.Exists(_produtoCaminhoArquivo))
             return new List<Produto>();
             string json = await File.ReadAllTextAsync(_produtoCaminhoArquivo);
             return JsonConvert.DeserializeObject<List<Produto>>(json);
        }

        private int ObterProximoCodigoDisponivel(List<Produto> produtos)
        {
             if (produtos.Any())
             return produtos.Max(p => p.Codigo) + 1;
             else
             return 1;
        }

        private async Task EscreverProdutosNoArquivoAsync(List<Produto> produtos)
        {
             string json = JsonConvert.SerializeObject(produtos);
             await File.WriteAllTextAsync(_produtoCaminhoArquivo, json);
        }
    }
}
