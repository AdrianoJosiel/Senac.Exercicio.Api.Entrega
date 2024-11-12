using Microsoft.AspNetCore.Mvc;
using Senac.Exercicio.Domain.DTO;
using Senac.Exercicio.Domain.Entities;
using Senac.Exercicio.Infraestrutura.Repository;
using Senac.Exercicio.Service;

namespace Senac.Exercicio.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController
    {

        [HttpGet, Route("logradouro, numero")]
        public List<EnderecoEntity> ObterEndereco(string logradouro, string numero)
        => new EnderecoService().ObterEndereco(logradouro, numero);

        [HttpPost]
        public bool GravarEndereco(EnderecoInputModel p)
            => new EnderecoService().GravarEndereco(p);

        [HttpPut]
        public bool EditarEndereco(BuscarEnderecoInputModel p)
            => new EnderecoService().EditarEndereco(p);
        [HttpDelete]
        public bool ExcluirEndereco(int id)
           => new EnderecoService().ExcluirEndereco(id);

    }
}
