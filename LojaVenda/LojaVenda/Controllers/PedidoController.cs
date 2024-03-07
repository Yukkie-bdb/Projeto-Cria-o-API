using LojinhaVendas.Models;
using Microsoft.AspNetCore.Mvc;
using SistemaTarefas.Data.Map;
using SistemaTarefas.Repositorio.Interfaces;

namespace SistemaTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidosRepositorios _pedidosRepositorios;

        public PedidoController(IPedidosRepositorios pedidosRepositorios)
        {
            _pedidosRepositorios = pedidosRepositorios;
        }

        [HttpGet]
        public async Task<ActionResult<List<pedidoModel>>> BuscaTodosPedidos()
        {
            List<pedidoModel> pedidos = await _pedidosRepositorios.BuscaTodosPedidos();
            return Ok();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<pedidoModel>> BuscarPorId(int id)
        {
            pedidoModel pedido = await _pedidosRepositorios.BuscarPorId(id);
            return Ok(pedido);
        }

        [HttpPost]

        public async Task<ActionResult<pedidoModel>> Adicionar([FromBody] pedidoModel pedidoModel)
        {
            pedidoModel pedido = await _pedidosRepositorios.Adicionar(pedidoModel);
            return Ok(pedido);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<pedidoModel>> Atualizar(int id, [FromBody] pedidoModel pedidoModel)
        {
            pedidoModel.Id = id;
           
            pedidoModel pedido = await _pedidosRepositorios.Atualizar(pedidoModel, id);
            return Ok(pedido);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<pedidoModel>> Apagar(int id)
        {
            bool apagado = await _pedidosRepositorios.Apagar(id);
            return Ok(apagado);
        }
    }
}
