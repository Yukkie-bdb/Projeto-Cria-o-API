using LojinhaVendas.Models;
using System.Net.Sockets;

namespace SistemaTarefas.Repositorio.Interfaces
{
    public interface IProdutoRepositorios
    {
        Task<List<produtoModel>> BuscaTodosProdutos();

        Task<produtoModel> BuscarPorId(int id);

        Task<produtoModel> Adicionar(produtoModel pedido);

        Task<produtoModel> Atualizar(produtoModel pedido, int id);

        Task<bool> Apagar(int id);
    }
}
