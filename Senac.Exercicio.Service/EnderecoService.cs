using Senac.Exercicio.Domain.DTO;
using Senac.Exercicio.Domain.Entities;
using Senac.Exercicio.Infraestrutura.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senac.Exercicio.Service
{
    public class EnderecoService
    {

        public bool ExcluirEndereco(int id)
           => new EnderecoRepository().ExcluirEndereco(id);

        public bool GravarEndereco(EnderecoInputModel p)
        {
            //Recebendo o objeto de entrada e convertendo ele em um objeto para a persistência
            EnderecoEntity obj = new EnderecoEntity(0, p.PessoaId, p.Logradouro,p.Numero , p.Complemento,p.Bairro);

            //Gambi de momento - chamando o repositório para salvar a pessoa no banco - rever
            return new EnderecoRepository().Gravar(obj);
        }

        public bool EditarEndereco(BuscarEnderecoInputModel p)
        {
            //Recebendo o objeto de entrada e convertendo ele em um objeto para a persistência
            EnderecoEntity obj = new EnderecoEntity(p.Id, p.PessoaId, p.Logradouro, p.Numero, p.Complemento, p.Bairro);

            //Gambi de momento - chamando o repositório para salvar a pessoa no banco - rever
            return new EnderecoRepository().Editar(obj);
        }

        


        public List<EnderecoEntity> ObterEndereco(string logradouro, string numero)
        => new EnderecoRepository().ObterEndereco(logradouro, numero);
    }


   
}
