using LojinhaVendas.Models;
using Microsoft.AspNetCore.Mvc;
using SistemaTarefas.Data.Map;
using SistemaTarefas.Repositorio.Interfaces;

namespace SistemaTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuariosRepositorios _usuariosRepositorios;

        public UsuarioController(IUsuariosRepositorios usuariosRepositorios)
        {
            _usuariosRepositorios = usuariosRepositorios;
        }

        [HttpGet]
        public async Task<ActionResult<List<usuarioModel>>> BuscaTodosUsuarios()
        {
            List<usuarioModel> usuarios = await _usuariosRepositorios.BuscaTodosUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<usuarioModel>> BuscarPorId(int id)
        {
            usuarioModel usuario = await _usuariosRepositorios.BuscarPorId(id);
            return Ok(usuario);
        }

        [HttpPost]

        public async Task<ActionResult<usuarioModel>> Adicionar([FromBody] usuarioModel usuarioModel)
        {
            usuarioModel usuario = await _usuariosRepositorios.Adicionar(usuarioModel);
            return Ok(usuario);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<usuarioModel>> Atualizar(int id, [FromBody] usuarioModel usuarioModel)
        {
            usuarioModel.Id = id;
           
            usuarioModel usuario = await _usuariosRepositorios.Atualizar(usuarioModel, id);
            return Ok(usuario);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<usuarioModel>> Apagar(int id)
        {
            bool apagado = await _usuariosRepositorios.Apagar(id);
            return Ok(apagado);
        }
    }
}
