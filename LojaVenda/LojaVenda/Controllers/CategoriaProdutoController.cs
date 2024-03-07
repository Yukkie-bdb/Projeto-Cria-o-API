using LojinhaVendas.Models;
using Microsoft.AspNetCore.Mvc;
using SistemaTarefas.Data.Map;
using SistemaTarefas.Repositorio.Interfaces;

namespace SistemaTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaProdutoController : ControllerBase
    {
        private readonly IcategoriaProdutoRepositorios _categoriasRepositorios;

        public CategoriaProdutoController(IcategoriaProdutoRepositorios categoriasRepositorios)
        {
            _categoriasRepositorios = categoriasRepositorios;
        }

        [HttpGet]
        public async Task<ActionResult<List<categoriaProdutoModel>>> BuscaTodoscategoriaProdutos()
        {
            List<categoriaProdutoModel> categorias = await _categoriasRepositorios.BuscaTodoscategoriaProdutos();
            return Ok();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<categoriaProdutoModel>> BuscarPorId(int id)
        {
            categoriaProdutoModel categoria = await _categoriasRepositorios.BuscarPorId(id);
            return Ok(categoria);
        }

        [HttpPost]

        public async Task<ActionResult<categoriaProdutoModel>> Adicionar([FromBody] categoriaProdutoModel categoriaProduto)
        {
            categoriaProdutoModel categoria = await _categoriasRepositorios.Adicionar(categoriaProduto);
            return Ok(categoria);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<categoriaProdutoModel>> Atualizar(int id, [FromBody] categoriaProdutoModel categoriaProduto)
        {
            categoriaProduto.Id = id;
           
            categoriaProdutoModel categoria = await _categoriasRepositorios.Atualizar(categoriaProduto, id);
            return Ok(categoria);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<categoriaProdutoModel>> Apagar(int id)
        {
            bool apagado = await _categoriasRepositorios.Apagar(id);
            return Ok(apagado);
        }
    }
}
