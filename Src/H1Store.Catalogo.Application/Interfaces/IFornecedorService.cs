using H1Store.Catalogo.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1Store.Catalogo.Application.Interfaces
{
    public interface IFornecedorService
    {
        IEnumerable<FornecedorViewModel> ObterTodosFornecedor();
        FornecedorViewModel ObterFornecedorPorCodigo(int codigo);
        void AdicionarFornecedor(NovoFornecedorViewModel fornecedor);
        void AtualizarFornecedor(FornecedorViewModel fornecedor);
        void RemoverFornecedor(int codigo);
    }
}
