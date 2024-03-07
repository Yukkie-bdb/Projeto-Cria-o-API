using Microsoft.EntityFrameworkCore;
using LojinhaVendas.Models;
using SistemaTarefas.Repositorio.Interfaces;
using SistemaTarefas.Data;

namespace SistemaTarefas.Repositorio
{
    public class CategoriaRepositorios : ICategoriaRepositorios
    {
        private readonly lojaVendaDBContext _dbContext;

        public CategoriaRepositorios(lojaVendaDBContext sistemaTarefasDBContext)
        {
            _dbContext = sistemaTarefasDBContext;
        }

        public async Task<categoriaModel> BuscarPorId(int id)
        {
            return await _dbContext.Categorias.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<categoriaModel>> BuscaTodosCategorias()
        {
            return await _dbContext.Categorias.ToListAsync();
        }
        public async Task<categoriaModel> Adicionar(categoriaModel categoria)
        {
            await _dbContext.Categorias.AddAsync(categoria);
            await _dbContext.SaveChangesAsync();

            return categoria;
        }

        public async Task<bool> Apagar(int id)
        {
            categoriaModel categoriaPorId = await BuscarPorId(id);


            if (categoriaPorId == null)
            {
                throw new Exception($"Categoria do ID: {id} não foi encontrado");
            }

            _dbContext.Categorias.Remove(categoriaPorId);
            await _dbContext.SaveChangesAsync();

            return true;
           
        }

        public async Task<categoriaModel> Atualizar(categoriaModel categoria, int id)
        {
            categoriaModel categoriaPorId = await BuscarPorId(id);


            if (categoriaPorId == null)
            {
                throw new Exception($"Categoria do ID: {id} não foi encontrado");
            }

            categoriaPorId.nome = categoria.nome;
            categoriaPorId.status = categoria.status;


            _dbContext.Categorias.Update(categoriaPorId);
            await _dbContext.SaveChangesAsync();

            return categoriaPorId;
        }
        
    }
}
