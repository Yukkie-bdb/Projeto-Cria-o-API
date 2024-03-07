namespace LojinhaVendas.Models
{
    public class pedidoModel
    {
        public int Id { get; set; }
        public string enderecoEntrega { get; set; }
        public int usuarioId { get; set; }
        public virtual usuarioModel? usuario { get; set; }
    }
}
