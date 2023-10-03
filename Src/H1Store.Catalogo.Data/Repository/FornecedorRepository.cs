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
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly string _fornecedorCaminhoArquivo;

        public FornecedorRepository()
        {
            _fornecedorCaminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "FileJsonData", "fornecedor.json");
        }

        public async Task AdicionarFornecedor(Fornecedor fornecedor)
        {
            var fornecedores = await LerFornecedoresDoArquivoAsync();
            int proximoCodigo = ObterProximoCodigoDisponivel(fornecedores);
            fornecedor.SetaCodigoFornecedor(proximoCodigo);
            fornecedores.Add(fornecedor);
            await EscreverFornecedoresNoArquivoAsync(fornecedores);
        }

        public async Task AtualizarFornecedor(Fornecedor fornecedor)
        {
            var fornecedores = await LerFornecedoresDoArquivoAsync();
            var fornecedorExistente = fornecedores.FirstOrDefault(f => f.Codigo == fornecedor.Codigo);
            if (fornecedorExistente != null)
            {
                fornecedorExistente.RazaoSocial = fornecedor.RazaoSocial;
                fornecedorExistente.CNPJ = fornecedor.CNPJ;
                fornecedorExistente.Ativo = fornecedor.Ativo;
                fornecedorExistente.DataCadastro = fornecedor.DataCadastro;
                fornecedorExistente.EmailContato = fornecedor.EmailContato;
            }
            await EscreverFornecedoresNoArquivoAsync(fornecedores);
        }

        public async Task<IEnumerable<Fornecedor>> ObterTodosFornecedor()
        {
            return await LerFornecedoresDoArquivoAsync();
        }

        public async Task<Fornecedor> ObterFornecedorPorCodigo(int codigo)
        {
            var fornecedores = await LerFornecedoresDoArquivoAsync();
            return fornecedores.FirstOrDefault(f => f.Codigo == codigo);
        }

        public async Task RemoverFornecedor(int codigo)
        {
            var fornecedores = await LerFornecedoresDoArquivoAsync();
            var fornecedorExistente = fornecedores.FirstOrDefault(f => f.Codigo == codigo);
            if (fornecedorExistente != null)
            {
                fornecedores.Remove(fornecedorExistente);
                await EscreverFornecedoresNoArquivoAsync(fornecedores);
            }
        }

        private async Task<List<Fornecedor>> LerFornecedoresDoArquivoAsync()
        {
            if (!File.Exists(_fornecedorCaminhoArquivo))
                return new List<Fornecedor>();
            string json = await File.ReadAllTextAsync(_fornecedorCaminhoArquivo);
            return JsonConvert.DeserializeObject<List<Fornecedor>>(json);
        }

        private int ObterProximoCodigoDisponivel(List<Fornecedor> fornecedores)
        {
            if (fornecedores.Any())
                return fornecedores.Max(f => f.Codigo) + 1;
            else
                return 1;
        }

        private async Task EscreverFornecedoresNoArquivoAsync(List<Fornecedor> fornecedores)
        {
            string json = JsonConvert.SerializeObject(fornecedores);
            await File.WriteAllTextAsync(_fornecedorCaminhoArquivo, json);
        }
    }
}

