using H1Store.Catalogo.Domain.Entities;
using H1Store.Catalogo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1Store.Catalogo.Data.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly List<Categoria> _categorias; 

        public CategoriaRepository()
        {
            _categorias = new List<Categoria>();
        }

        public async Task<IEnumerable<Categoria>> ObterTodos()
        {
            return await Task.FromResult(_categorias);
        }

        public async Task<Categoria> ObterPorCodigo(int codigo)
        {
            return await Task.FromResult(_categorias.FirstOrDefault(c => c.Codigo == codigo));
        }

        public async Task Adicionar(Categoria categoria)
        {
            _categorias.Add(categoria);
            await Task.CompletedTask;
        }

        public async Task Atualizar(Categoria categoria)
        {
            var categoriaExistente = _categorias.FirstOrDefault(c => c.Codigo == categoria.Codigo);
            if (categoriaExistente != null)
            {
                categoriaExistente.Descricao = categoria.Descricao;
            }
            await Task.CompletedTask;
        }

        public async Task Remover(int codigo)
        {
            var categoriaExistente = _categorias.FirstOrDefault(c => c.Codigo == codigo);
            if (categoriaExistente != null)
            {
                _categorias.Remove(categoriaExistente);
            }
            await Task.CompletedTask;
        }
    }
}
