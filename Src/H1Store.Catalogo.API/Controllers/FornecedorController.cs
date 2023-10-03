using AutoMapper;
using H1Store.Catalogo.Application.Interfaces;
using H1Store.Catalogo.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace H1Store.Catalogo.API.Controllers
{
    [ApiController]
    [Route("api/fornecedores")]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorService _fornecedorService;

        public FornecedorController(IFornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosFornecedores()
        {
            var fornecedores = await _fornecedorService.ObterTodosFornecedores();
            return Ok(fornecedores);
        }

        [HttpGet("{codigo}")]
        public async Task<IActionResult> ObterFornecedorPorCodigo(int codigo)
        {
            var fornecedor = await _fornecedorService.ObterFornecedorPorCodigo(codigo);
            if (fornecedor == null)
            {
                return NotFound();
            }
            return Ok(fornecedor);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarFornecedor(NovoFornecedorViewModel novoFornecedor)
        {
            await _fornecedorService.AdicionarFornecedor(novoFornecedor);
            return CreatedAtAction(nameof(ObterFornecedorPorCodigo), new { codigo = novoFornecedor.Codigo }, novoFornecedor);
        }

        [HttpPut("{codigo}")]
        public async Task<IActionResult> AtualizarFornecedor(int codigo, FornecedorViewModel fornecedor)
        {
            if (codigo != fornecedor.Codigo)
            {
                return BadRequest();
            }
            await _fornecedorService.AtualizarFornecedor(fornecedor);
            return NoContent();
        }

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> RemoverFornecedor(int codigo)
        {
            await _fornecedorService.RemoverFornecedor(codigo);
            return NoContent();
        }
    }
}
