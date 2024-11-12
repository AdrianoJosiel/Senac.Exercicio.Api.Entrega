using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senac.Exercicio.Domain.DTO
{
    public class BuscarEnderecoInputModel
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
    }
}
