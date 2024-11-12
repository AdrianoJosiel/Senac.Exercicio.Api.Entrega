using static System.Net.Mime.MediaTypeNames;

namespace Senac.Exercicio.Service
{
    public class ValidacaoService
    {
        public bool ValidarCadastro (string cpf, DateTime dtNasc)
            => (new CpfService().ValidarCpf(cpf) && (new IdadeService().CalculaAnos(dtNasc) >= 18)) ? true : false;
        /*
        public bool ValidarCadastro (string cpf, DateTime dtNasc)
        {
            bool ehCpfValido = new CpfService().ValidarCpf(cpf);
            int idade = new IdadeService().CalculaAnos(dtNasc);

            if (ehCpfValido && (idade >= 18))
                return true;
            return false;
        }*/
    }
}
