using Microsoft.AspNetCore.Mvc;
using Senac.Exercicio.Service;

namespace Senac.Exercicio.Api.Controllers
{
    [ApiController]
    [Route ("[controller]")]
    public class ValidacaoController
    {
        [HttpGet]
        public string ValidarCadastro(string cpf, DateTime dtNasc)
            => new ValidacaoService().ValidarCadastro(cpf, dtNasc) ? "Cadastro validado com sucesso!" : "Cadastro inválido!";

        /*
        public string ValidarCadastro (string cpf, DateTime dtNasc)
        {
            bool resultado = new ValidacaoService().ValidarCadastro(cpf, dtNasc);
            if (resultado)
                return "Cadastro validado com sucesso!";
            return "Cadastro inválido!";
        }*/
    }
}
