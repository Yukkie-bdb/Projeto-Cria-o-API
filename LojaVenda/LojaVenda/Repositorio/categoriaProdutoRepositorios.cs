using Microsoft.EntityFrameworkCore;
using LojinhaVendas.Models;
using SistemaTarefas.Repositorio.Interfaces;
using SistemaTarefas.Data;

namespace SistemaTarefas.Repositorio
{
    public class CategoriaProdutosRepositorio : IcategoriaProdutoRepositorios
    {
        private readonly lojaVendaDBContext _dbContext;

        public CategoriaProdutosRepositorio(lojaVendaDBContext sistemaTarefasDBContext)
        {
            _dbContext = sistemaTarefasDBContext;
        }

        public async Task<categoriaProdutoModel> BuscarPorId(int id)
        {
            return await _dbContext.categoriaProduto.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<categoriaProdutoModel>> BuscaTodoscategoriaProdutos()
        {
            return await _dbContext.categoriaProduto.ToListAsync();
        }
        public async Task<categoriaProdutoModel> Adicionar(categoriaProdutoModel categoriaproduto)
        {
            await _dbContext.categoriaProduto.AddAsync(categoriaproduto);
            await _dbContext.SaveChangesAsync();

            return categoriaproduto;
        }

        public async Task<bool> Apagar(int id)
        {
            categoriaProdutoModel categoriaPorId = await BuscarPorId(id);


            if (categoriaPorId == null)
            {
                throw new Exception($"Categoria do ID: {id} não foi encontrado");
            }

            _dbContext.categoriaProduto.Remove(categoriaPorId);
            await _dbContext.SaveChangesAsync();

            return true;
           
        }

        public async Task<categoriaProdutoModel> Atualizar(categoriaProdutoModel categoriaproduto, int id)
        {
            categoriaProdutoModel categoriaPorId = await BuscarPorId(id);


            if (categoriaPorId == null)
            {
                throw new Exception($"Categoria do ID: {id} não foi encontrado");
            }

            categoriaPorId.produtoId = categoriaproduto.produtoId;
            categoriaPorId.categoriaId = categoriaproduto.categoriaId;


            _dbContext.categoriaProduto.Update(categoriaPorId);
            await _dbContext.SaveChangesAsync();

            return categoriaPorId;
        }
        
    }
}
