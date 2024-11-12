using Senac.Exercicio.Domain.DTO;
using Senac.Exercicio.Domain.Entities;
using Senac.Exercicio.Infraestrutura.Repository;

namespace Senac.Exercicio.Service
{
    public class PessoaService
    {
        public bool ExcluirPessoa(int id)
            => new PessoaRepository().ExcluirPessoa(id);

        public List<PessoaEntity> ObterPessoaPorNome(string nome)
            => new PessoaRepository().ObterPessoasPorNome(nome); 

        public List<PessoaEntity> ObterPessoas(string cpf)
            => new PessoaRepository().ObterPessoas(cpf);

        public List<PessoaEntity> ObterPessoas()
            => new PessoaRepository().ObterPessoas();


        /*
        public List<PessoaEntity> ObterPessoas()
        {
            List<PessoaEntity> objLista = new List<PessoaEntity>();
            PessoaRepository repositorio = new PessoaRepository();
            objLista = repositorio.ObterPessoas();
            return objLista;
        }*/

        public bool GravarPessoa(AlterarPessoaInputModel p)
        {
            //Recebendo o objeto de entrada e convertendo ele em um objeto para a persistência
            PessoaEntity obj = new PessoaEntity(p.Id,p.Nome,p.Cpf,p.DataNascimento,true);

            //Gambi de momento - chamando o repositório para salvar a pessoa no banco - rever
            return new PessoaRepository().Gravar(obj);
        }

        public bool GravarPessoa(PessoaInputModel p)
        {
            //Recebendo o objeto de entrada e convertendo ele em um objeto para a persistência
            PessoaEntity obj = new PessoaEntity(0, p.Nome, p.Cpf, p.DataNascimento, true);

            //Gambi de momento - chamando o repositório para salvar a pessoa no banco - rever
            return new PessoaRepository().Gravar(obj);
        }
    }
}
