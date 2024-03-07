using LojinhaVendas.Models;
using System.Net.Sockets;

namespace SistemaTarefas.Repositorio.Interfaces
{
    public interface IcategoriaProdutoRepositorios
    {
        Task<List<categoriaProdutoModel>> BuscaTodoscategoriaProdutos();

        Task<categoriaProdutoModel> BuscarPorId(int id);

        Task<categoriaProdutoModel> Adicionar(categoriaProdutoModel categoriaProduto);

        Task<categoriaProdutoModel> Atualizar(categoriaProdutoModel categoriaProduto, int id);

        Task<bool> Apagar(int id);
    }
}
