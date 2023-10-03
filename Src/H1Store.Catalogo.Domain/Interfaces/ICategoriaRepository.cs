using H1Store.Catalogo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1Store.Catalogo.Domain.Interfaces
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> ObterTodos();
        Categoria ObterPorCodigo(int codigo);
        void Adicionar(Categoria categoria);
        void Atualizar(Categoria categoria);
        void Remover(int codigo);
    }
}
