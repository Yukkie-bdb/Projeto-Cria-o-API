namespace LojinhaVendas.Models
{
    public class categoriaProdutoModel
    {
        public int Id { get; set; }
        public string produtoId { get; set; }
        public string categoriaId { get; set; }

        public virtual produtoModel? produto { get; set; }
        public virtual categoriaModel? categoria { get; set; }
    }
}
