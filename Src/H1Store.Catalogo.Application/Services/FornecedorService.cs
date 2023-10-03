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
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private IMapper _mapper;

        public FornecedorService(IFornecedorRepository fornecedorRepository, IMapper mapper)
        {
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
        }

        public async Task AdicionarFornecedor(NovoFornecedorViewModel novoFornecedorViewModel)
        {
            var novoFornecedor = _mapper.Map<Fornecedor>(novoFornecedorViewModel);
            await _fornecedorRepository.Adicionar(novoFornecedor);
        }

        public async Task AtualizarFornecedor(FornecedorViewModel fornecedorViewModel)
        {
            var fornecedor = _mapper.Map<Fornecedor>(fornecedorViewModel);
            await _fornecedorRepository.Atualizar(fornecedor);
        }

        public async Task<FornecedorViewModel> ObterFornecedorPorCodigo(int codigo)
        {
            var fornecedor = await _fornecedorRepository.ObterPorCodigo(codigo);
            return _mapper.Map<FornecedorViewModel>(fornecedor);
        }

        public IEnumerable<FornecedorViewModel> ObterTodosFornecedor()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<FornecedorViewModel>> ObterTodosFornecedores()
        {
            var fornecedores = await _fornecedorRepository.ObterTodos();
            return _mapper.Map<IEnumerable<FornecedorViewModel>>(fornecedores);
        }

        public async Task RemoverFornecedor(int codigo)
        {
            await _fornecedorRepository.Remover(codigo);
        }
    }
}
