using H1Store.Catalogo.Application.Interfaces;
using H1Store.Catalogo.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace H1Store.Catalogo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosProdutos()
        {
            var produtos = _produtoService.ObterTodosProdutos();
            return Ok(produtos);
        }

        [HttpGet("{codigo}")]
        public async Task<IActionResult> ObterProdutoPorCodigo(int codigo)
        {
            var produto = _produtoService.ObterProdutoPorCodigo(codigo);
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarProduto(NovoProdutoViewModel novoProduto)
        {
            _produtoService.AdicionarProduto(novoProduto);
            return CreatedAtAction(nameof(ObterProdutoPorCodigo), new { codigo = novoProduto.Codigo }, novoProduto);
        }

        [HttpPut("{codigo}")]
        public async Task<IActionResult> AtualizarProduto(int codigo, ProdutoViewModel produto)
        {
            if (codigo != produto.Codigo)
            {
                return BadRequest();
            }
             _produtoService.AtualizarProduto(produto);
            return NoContent();
        }

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> RemoverProduto(int codigo)
        {
             _produtoService.RemoverProduto(codigo);
            return NoContent();
        }
    }
}
