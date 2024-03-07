using LojinhaVendas.Models;
using System.Net.Sockets;

namespace SistemaTarefas.Repositorio.Interfaces
{
    public interface IPedidosRepositorios
    {
        Task<List<pedidoModel>> BuscaTodosPedidos();

        Task<pedidoModel> BuscarPorId(int id);

        Task<pedidoModel> Adicionar(pedidoModel pedido);

        Task<pedidoModel> Atualizar(pedidoModel pedido, int id);

        Task<bool> Apagar(int id);
    }
}
