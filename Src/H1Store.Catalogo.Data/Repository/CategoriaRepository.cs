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
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly string _categoriaCaminhoArquivo;

        public CategoriaRepository()
        {
            _categoriaCaminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "FileJsonData", "Categoria.json");
        }

        public async Task<IEnumerable<Categoria>> ObterTodasCategorias()
        {
            var categorias = await LerCategoriaDoArquivoAsync();
            return categorias;
        }

        public async Task<Categoria> ObterCategoriaPorCodigo(int codigo)
        {
            var categorias = await LerCategoriaDoArquivoAsync();
            return categorias.FirstOrDefault(c => c.Codigo == codigo);
        }

        public async Task AdicionarCategoria(Categoria categoria)
        {
            var categorias = await LerCategoriaDoArquivoAsync();
            int proximoCodigo = ObterProximoCodigoDisponivel(categorias);
            categoria.SetCodigo(proximoCodigo);
            categorias.Add(categoria);
            await EscreverCategoriaNoArquivoAsync(categorias);
        }

        public async Task AtualizarCategoria(Categoria categoria)
        {
            var categorias = await LerCategoriaDoArquivoAsync();
            var categoriaExistente = categorias.FirstOrDefault(c => c.Codigo == categoria.Codigo);
            if (categoriaExistente != null)
            {
                categoriaExistente.Descricao = categoria.Descricao;
            }
            await EscreverCategoriaNoArquivoAsync(categorias);
        }

        public async Task RemoverCategoria(int codigo)
        {
            var categorias = await LerCategoriaDoArquivoAsync();
            var categoriaExistente = categorias.FirstOrDefault(c => c.Codigo == codigo);
            if (categoriaExistente != null)
            {
                categorias.Remove(categoriaExistente);
                await EscreverCategoriaNoArquivoAsync(categorias);
            }
        }

        private async Task<List<Categoria>> LerCategoriaDoArquivoAsync()
        {
            if (!File.Exists(_categoriaCaminhoArquivo))
                return new List<Categoria>();
            string json = await File.ReadAllTextAsync(_categoriaCaminhoArquivo);
            return JsonConvert.DeserializeObject<List<Categoria>>(json);
        }

        private int ObterProximoCodigoDisponivel(List<Categoria> categorias)
        {
            if (categorias.Any())
                return categorias.Max(c => c.Codigo) + 1;
            else
                return 1;
        }

        private async Task EscreverCategoriaNoArquivoAsync(List<Categoria> categorias)
        {
            string json = JsonConvert.SerializeObject(categorias);
            await File.WriteAllTextAsync(_categoriaCaminhoArquivo, json);
        }
    }
}

