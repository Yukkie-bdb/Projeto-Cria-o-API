namespace LojinhaVendas.Models
{
    public class usuarioModel
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public DateOnly? dataNascimento { get; set; }

    }
}
