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
        IEnumerable<Categoria> ObterTodasCategorias();
        Task<Categoria> ObterCategoriaPorCodigo(int codigo);
        void AdicionarCategoria(Categoria categoria);
        void AtualizarCategoria(Categoria categoria);
        void RemoverCategoria(int codigo);
    }
}
