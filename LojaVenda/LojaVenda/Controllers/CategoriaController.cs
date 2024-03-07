using LojinhaVendas.Models;
using Microsoft.AspNetCore.Mvc;
using SistemaTarefas.Data.Map;
using SistemaTarefas.Repositorio.Interfaces;

namespace SistemaTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepositorios _categoriasRepositorios;

        public CategoriaController(ICategoriaRepositorios categoriasRepositorios)
        {
            _categoriasRepositorios = categoriasRepositorios;
        }

        [HttpGet]
        public async Task<ActionResult<List<categoriaModel>>> BuscaTodosCategorias()
        {
            List<categoriaModel> categorias = await _categoriasRepositorios.BuscaTodosCategorias();
            return Ok();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<categoriaModel>> BuscarPorId(int id)
        {
            categoriaModel categoria = await _categoriasRepositorios.BuscarPorId(id);
            return Ok(categoria);
        }

        [HttpPost]

        public async Task<ActionResult<categoriaModel>> Adicionar([FromBody] categoriaModel categoriaModel)
        {
            categoriaModel categoria = await _categoriasRepositorios.Adicionar(categoriaModel);
            return Ok(categoria);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<categoriaModel>> Atualizar(int id, [FromBody] categoriaModel categoriaModel)
        {
            categoriaModel.Id = id;
           
            categoriaModel categoria = await _categoriasRepositorios.Atualizar(categoriaModel, id);
            return Ok(categoria);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<categoriaModel>> Apagar(int id)
        {
            bool apagado = await _categoriasRepositorios.Apagar(id);
            return Ok(apagado);
        }
    }
}
