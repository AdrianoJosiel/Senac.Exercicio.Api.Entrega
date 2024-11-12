using Microsoft.AspNetCore.Mvc;
using Senac.Exercicio.Domain.DTO;
using Senac.Exercicio.Domain.Entities;
using Senac.Exercicio.Service;


namespace Senac.Exercicio.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController
    {
        [HttpGet, Route("cpf")]
        public List<PessoaEntity> ObterPessoas(string cpf)
            => new PessoaService().ObterPessoas(cpf);

        [HttpGet, Route("nome")]
        public List<PessoaEntity> ObterPorNome(string nome)
            => new PessoaService().ObterPessoaPorNome(nome);

        [HttpGet, Route("all")]
        public List<PessoaEntity> ObterPessoas()
            => new PessoaService().ObterPessoas();

        [HttpPost]
        public bool GravarPessoa(PessoaInputModel input)
            => new PessoaService().GravarPessoa(input);

        [HttpPut]
        public bool AlterarPessoa(AlterarPessoaInputModel input)
            => new PessoaService().GravarPessoa(input);

        [HttpDelete]
        public bool ExcluirPessoa(int id)
            => new PessoaService().ExcluirPessoa(id);
    }
}
