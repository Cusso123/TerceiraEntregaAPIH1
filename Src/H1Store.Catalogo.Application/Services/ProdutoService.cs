using AutoMapper;
using H1Store.Catalogo.Application.Interfaces;
using H1Store.Catalogo.Application.ViewModels;
using H1Store.Catalogo.Domain.Entities;
using H1Store.Catalogo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1Store.Catalogo.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private IMapper _mapper;

        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task AdicionarProduto(NovoProdutoViewModel novoProdutoViewModel)
        {
            var novoProduto = _mapper.Map<Produto>(novoProdutoViewModel);
            _produtoRepository.AdicionarProduto(novoProduto);
        }

        public async Task AtualizarProduto(ProdutoViewModel produtoViewModel)
        {
            var produto = _mapper.Map<Produto>(produtoViewModel);
            _produtoRepository.AtualizarProduto(produto);
        }

        public async Task<IEnumerable<ProdutoViewModel>> ObterProdutoPorCodigo(int codigo)
        {
            var produtos = await _produtoRepository.ObterProdutoPorCodigo(codigo);
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(produtos);
        }

        public IEnumerable<ProdutoViewModel> ObterTodosProdutos()
        {
            var produtos = _produtoRepository.ObterTodosProdutos();
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(produtos);
        }

        public async Task RemoverProduto(int codigo)
        {
            _produtoRepository.RemoverProduto(codigo);
        }
    }
}
