namespace Senac.Exercicio.Domain.DTO
{
    public class AlterarPessoaInputModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
