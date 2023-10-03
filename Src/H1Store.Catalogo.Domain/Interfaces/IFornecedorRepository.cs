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
        IEnumerable<Fornecedor> ObterTodos();
        Categoria ObterPorCodigo(int codigo);
        void Adicionar(Fornecedor fornecedor);
        void Atualizar(Fornecedor fornecedor);
        void Remover(int codigo);
    }
}
