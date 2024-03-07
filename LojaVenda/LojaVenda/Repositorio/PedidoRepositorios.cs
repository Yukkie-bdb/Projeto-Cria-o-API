using Microsoft.EntityFrameworkCore;
using LojinhaVendas.Models;
using SistemaTarefas.Repositorio.Interfaces;
using SistemaTarefas.Data;

namespace SistemaTarefas.Repositorio
{
    public class PedidoRepositorio : IPedidosRepositorios
    {
        private readonly lojaVendaDBContext _dbContext;

        public PedidoRepositorio(lojaVendaDBContext sistemaTarefasDBContext)
        {
            _dbContext = sistemaTarefasDBContext;
        }

        public async Task<pedidoModel> BuscarPorId(int id)
        {
            return await _dbContext.Pedidos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<pedidoModel>> BuscaTodosPedidos()
        {
            return await _dbContext.Pedidos.ToListAsync();
        }
        public async Task<pedidoModel> Adicionar(pedidoModel pedido)
        {
            await _dbContext.Pedidos.AddAsync(pedido);
            await _dbContext.SaveChangesAsync();

            return pedido;
        }

        public async Task<bool> Apagar(int id)
        {
            pedidoModel pedidoPorId = await BuscarPorId(id);


            if (pedidoPorId == null)
            {
                throw new Exception($"Pedido do ID: {id} não foi encontrado");
            }

            _dbContext.Pedidos.Remove(pedidoPorId);
            await _dbContext.SaveChangesAsync();

            return true;
           
        }

        public async Task<pedidoModel> Atualizar(pedidoModel pedido, int id)
        {
            pedidoModel pedidoPorId = await BuscarPorId(id);


            if (pedidoPorId == null)
            {
                throw new Exception($"Pedido do ID: {id} não foi encontrado");
            }

            pedidoPorId.usuarioId = pedido.usuarioId;
            pedidoPorId.enderecoEntrega = pedido.enderecoEntrega;


            _dbContext.Pedidos.Update(pedidoPorId);
            await _dbContext.SaveChangesAsync();

            return pedidoPorId;
        }

   
    }
}
