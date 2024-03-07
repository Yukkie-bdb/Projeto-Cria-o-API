using LojinhaVendas.Models;
using System.Net.Sockets;

namespace SistemaTarefas.Repositorio.Interfaces
{
    public interface ICategoriaRepositorios
    {
        Task<List<categoriaModel>> BuscaTodosCategorias();

        Task<categoriaModel> BuscarPorId(int id);

        Task<categoriaModel> Adicionar(categoriaModel pedido);

        Task<categoriaModel> Atualizar(categoriaModel pedido, int id);

        Task<bool> Apagar(int id);
    }
}
