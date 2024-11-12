using Microsoft.AspNetCore.Mvc;
using Senac.Exercicio.Service;

namespace Senac.Exercicio.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IdadeController
    {
        [HttpGet, Route("IdadeBasica")]
        public string ObterIdade(DateTime dataNacimento)
        {
            int idade = new IdadeService().CalculaAnos(dataNacimento);
            return $"A pessoa tem {idade} anos";
        }

        [HttpGet, Route("IdadeDetalhada")]
        public string ObterIdadeDetalhada(DateTime dataNacimento)
        {
            string idade = new IdadeService().CalculaIdade(dataNacimento);
            return $"A pessoa tem {idade}";
        }
    }
}
