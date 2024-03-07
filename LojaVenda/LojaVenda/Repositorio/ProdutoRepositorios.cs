using Microsoft.EntityFrameworkCore;
using LojinhaVendas.Models;
using SistemaTarefas.Repositorio.Interfaces;
using SistemaTarefas.Data;

namespace SistemaTarefas.Repositorio
{
    public class ProdutoRepositorios : IProdutoRepositorios
    {
        private readonly lojaVendaDBContext _dbContext;

        public ProdutoRepositorios(lojaVendaDBContext sistemaTarefasDBContext)
        {
            _dbContext = sistemaTarefasDBContext;
        }

        public async Task<produtoModel> BuscarPorId(int id)
        {
            return await _dbContext.Produtos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<produtoModel>> BuscaTodosProdutos()
        {
            return await _dbContext.Produtos.ToListAsync();
        }
        public async Task<produtoModel> Adicionar(produtoModel produto)
        {
            await _dbContext.Produtos.AddAsync(produto);
            await _dbContext.SaveChangesAsync();

            return produto;
        }

        public async Task<bool> Apagar(int id)
        {
            produtoModel produtoPorId = await BuscarPorId(id);


            if (produtoPorId == null)
            {
                throw new Exception($"Produto do ID: {id} não foi encontrado");
            }

            _dbContext.Produtos.Remove(produtoPorId);
            await _dbContext.SaveChangesAsync();

            return true;
           
        }

        public async Task<produtoModel> Atualizar(produtoModel produto, int id)
        {
            produtoModel produtoPorId = await BuscarPorId(id);


            if (produtoPorId == null)
            {
                throw new Exception($"Produto do ID: {id} não foi encontrado");
            }

            produtoPorId.nome = produto.nome;
            produtoPorId.descricao = produto.descricao;
            produtoPorId.preco = produto.preco;


            _dbContext.Produtos.Update(produtoPorId);
            await _dbContext.SaveChangesAsync();

            return produtoPorId;
        }
        
    }
}
