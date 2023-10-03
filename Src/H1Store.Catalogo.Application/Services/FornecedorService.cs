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
             _fornecedorRepository.AdicionarFornecedor(novoFornecedor);
        }

        public async Task AtualizarFornecedor(FornecedorViewModel fornecedorViewModel)
        {
            var fornecedor = _mapper.Map<Fornecedor>(fornecedorViewModel);
             _fornecedorRepository.AtualizarFornecedor(fornecedor);
        }

        public async Task<FornecedorViewModel> ObterFornecedorPorCodigo(int codigo)
        {
            var fornecedor =  _fornecedorRepository.ObterFornecedorPorCodigo(codigo);
            return _mapper.Map<FornecedorViewModel>(fornecedor);
        }

        public IEnumerable<FornecedorViewModel> ObterTodosFornecedor()
        {
            var fornecedor = _fornecedorRepository.ObterTodosFornecedor();
            return _mapper.Map<IEnumerable<FornecedorViewModel>>(fornecedor);
        }

        public async Task RemoverFornecedor(int codigo)
        {
             _fornecedorRepository.RemoverFornecedor(codigo);
        }
    }
}
