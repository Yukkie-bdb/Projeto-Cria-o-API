using LojinhaVendas.Models;
using System.Net.Sockets;

namespace SistemaTarefas.Repositorio.Interfaces
{
    public interface IUsuariosRepositorios
    {
        Task<List<usuarioModel>> BuscaTodosUsuarios();

        Task<usuarioModel> BuscarPorId(int id);

        Task<usuarioModel> Adicionar(usuarioModel usuario);

        Task<usuarioModel> Atualizar(usuarioModel usuario, int id);

        Task<bool> Apagar(int id);
    }
}
