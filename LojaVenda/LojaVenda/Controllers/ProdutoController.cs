using LojinhaVendas.Models;
using Microsoft.AspNetCore.Mvc;
using SistemaTarefas.Data.Map;
using SistemaTarefas.Repositorio.Interfaces;

namespace SistemaTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepositorios _produtosRepositorios;

        public ProdutoController(IProdutoRepositorios produtosRepositorios)
        {
            _produtosRepositorios = produtosRepositorios;
        }

        [HttpGet]
        public async Task<ActionResult<List<produtoModel>>> BuscaTodosProdutos()
        {
            List<produtoModel> produtos = await _produtosRepositorios.BuscaTodosProdutos();
            return Ok();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<produtoModel>> BuscarPorId(int id)
        {
            produtoModel produto = await _produtosRepositorios.BuscarPorId(id);
            return Ok(produto);
        }

        [HttpPost]

        public async Task<ActionResult<produtoModel>> Adicionar([FromBody] produtoModel produtoModel)
        {
            produtoModel produto = await _produtosRepositorios.Adicionar(produtoModel);
            return Ok(produto);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<produtoModel>> Atualizar(int id, [FromBody] produtoModel produtoModel)
        {
            produtoModel.Id = id;
           
            produtoModel produto = await _produtosRepositorios.Atualizar(produtoModel, id);
            return Ok(produto);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<produtoModel>> Apagar(int id)
        {
            bool apagado = await _produtosRepositorios.Apagar(id);
            return Ok(apagado);
        }
    }
}
