using H1Store.Catalogo.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1Store.Catalogo.Application.Interfaces
{
	public interface IProdutoService
	{
		IEnumerable<ProdutoViewModel> ObterTodosProdutos();
		Task<IEnumerable<ProdutoViewModel>> ObterProdutoPorCodigo(int codigo);
		void AdicionarProduto(NovoProdutoViewModel produto);
		void AtualizarProduto(ProdutoViewModel produto);
		void RemoverProduto(int codigo);
	}
}
