using H1Store.Catalogo.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1Store.Catalogo.Application.Interfaces
{
    public interface ICategoriaService
    {
        IEnumerable<CategoriaViewModel> ObterTodasCategorias();
        Task<IEnumerable<CategoriaViewModel>> ObterCategoriaPorCodigo(int codigo);
        void AdicionarCategoria(NovaCategoriaViewModel categoria);
        void AtualizarCategoria(CategoriaViewModel categoria);
        void RemoverCategoria(int codigo);
    }
}
