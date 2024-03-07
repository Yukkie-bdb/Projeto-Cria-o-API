using LojinhaVendas.Enums;

namespace LojinhaVendas.Models
{
    public class categoriaModel
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public statusCategoria status { get; set; }
    }
}
