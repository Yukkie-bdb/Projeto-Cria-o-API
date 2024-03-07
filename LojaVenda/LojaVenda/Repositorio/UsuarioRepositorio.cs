using Microsoft.EntityFrameworkCore;
using LojinhaVendas.Models;
using SistemaTarefas.Repositorio.Interfaces;
using SistemaTarefas.Data;

namespace SistemaTarefas.Repositorio
{
    public class UsuarioRepositorio : IUsuariosRepositorios
    {
        private readonly lojaVendaDBContext _dbContext;

        public UsuarioRepositorio(lojaVendaDBContext sistemaTarefasDBContext)
        {
            _dbContext = sistemaTarefasDBContext;
        }

        public async Task<usuarioModel> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<usuarioModel>> BuscaTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }
        public async Task<usuarioModel> Adicionar(usuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<bool> Apagar(int id)
        {
            usuarioModel usuarioPorId = await BuscarPorId(id);


            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário do ID: {id} não foi encontrado");
            }

            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return true;
           
        }

        public async Task<usuarioModel> Atualizar(usuarioModel usuario, int id)
        {
            usuarioModel usuarioPorId = await BuscarPorId(id);


            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário do ID: {id} não foi encontrado");
            }

            usuarioPorId.nome = usuario.nome;
            usuarioPorId.email = usuario.email;
            usuarioPorId.dataNascimento = usuario.dataNascimento;


            _dbContext.Usuarios.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return usuarioPorId;
        }

   
    }
}
