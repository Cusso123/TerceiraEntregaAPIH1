using AutoMapper;
using H1Store.Catalogo.Application.Interfaces;
using H1Store.Catalogo.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace H1Store.Catalogo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorService _fornecedorService;

        public FornecedorController(IFornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosFornecedor()
        {
            var fornecedores =  _fornecedorService.ObterTodosFornecedor();
            return Ok(fornecedores);
        }

        [HttpGet("{codigo}")]
        public async Task<IActionResult> ObterFornecedorPorCodigo(int codigo)
        {
            var fornecedor =  _fornecedorService.ObterFornecedorPorCodigo(codigo);
            if (fornecedor == null)
            {
                return NotFound();
            }
            return Ok(fornecedor);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarFornecedor(NovoFornecedorViewModel novoFornecedor)
        {
             _fornecedorService.AdicionarFornecedor(novoFornecedor);
            return CreatedAtAction(nameof(ObterFornecedorPorCodigo), new { codigo = novoFornecedor.Codigo }, novoFornecedor);
        }

        [HttpPut("{codigo}")]
        public async Task<IActionResult> AtualizarFornecedor(int codigo, FornecedorViewModel fornecedor)
        {
            if (codigo != fornecedor.Codigo)
            {
                return BadRequest();
            }
             _fornecedorService.AtualizarFornecedor(fornecedor);
            return NoContent();
        }

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> RemoverFornecedor(int codigo)
        {
             _fornecedorService.RemoverFornecedor(codigo);
            return NoContent();
        }
    }
}

