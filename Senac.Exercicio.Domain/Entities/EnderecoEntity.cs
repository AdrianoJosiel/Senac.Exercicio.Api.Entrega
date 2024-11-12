using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senac.Exercicio.Domain.Entities
{
    public class EnderecoEntity
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        

        public EnderecoEntity()
        {
            
        }

        public EnderecoEntity(int id, int pessoaId, string logradouro, string numero, string complemento, string bairro)
        {
            Id = id;
            PessoaId = pessoaId;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
        }
        
    }
}
