using Microsoft.AspNetCore.Mvc;
using Senac.Exercicio.Service;

namespace Senac.Exercicio.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CpfController
    {
        [HttpGet()]
        public string ValidarCpf(string cpf)
        {
            bool resultado = new CpfService().ValidarCpf(cpf);
            if (resultado)
                return "CPF Válido!";
            return "CPF Inválido!";

            //Exemplo de if ternário return resultado ? "CPF Válido!" : "CPF Inválido!";
        }
    }
}
