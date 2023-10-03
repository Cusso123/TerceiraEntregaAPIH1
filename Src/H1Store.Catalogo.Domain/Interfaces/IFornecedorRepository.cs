using H1Store.Catalogo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1Store.Catalogo.Domain.Interfaces
{
    public interface IFornecedorRepository
    {
        IEnumerable<Fornecedor> ObterTodosFornecedor();
        Task<Fornecedor> ObterFornecedorPorCodigo(int codigo);
        void AdicionarFornecedor(Fornecedor fornecedor);
        void AtualizarFornecedor(Fornecedor fornecedor);
        void RemoverFornecedor(int codigo);
    }
}
