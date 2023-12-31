﻿using H1Store.Catalogo.Application.Interfaces;
using H1Store.Catalogo.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace H1Store.Catalogo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodasCategorias()
        {
            var categorias =  _categoriaService.ObterTodasCategorias();
            return Ok(categorias);
        }

        [HttpGet("{codigo}")]
        public async Task<IActionResult> ObterCategoriaPorCodigo(int codigo)
        {
            var categoria = await _categoriaService.ObterCategoriaPorCodigo(codigo);
            if (categoria == null)
            {
                return NotFound();
            }
            return Ok(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarCategoria(NovaCategoriaViewModel novaCategoria)
        {
             _categoriaService.AdicionarCategoria(novaCategoria);
            return CreatedAtAction(nameof(ObterCategoriaPorCodigo), new { codigo = novaCategoria.Codigo }, novaCategoria);
        }

        [HttpPut("{codigo}")]
        public async Task<IActionResult> AtualizarCategoria(int codigo, CategoriaViewModel categoria)
        {
            if (codigo != categoria.Codigo)
            {
                return BadRequest();
            }
             _categoriaService.AtualizarCategoria(categoria);
            return NoContent();
        }

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> RemoverCategoria(int codigo)
        {
             _categoriaService.RemoverCategoria(codigo);
            return NoContent();
        }
    }
}

