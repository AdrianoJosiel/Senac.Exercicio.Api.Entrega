namespace Senac.Exercicio.Service
{
    public class IdadeService
    {
        public string CalculaIdade(DateTime dtNasc)
        {
            int idDias = 0, idMeses = 0, idAnos = 0;
            DateTime dtAtual = DateTime.Now;
            DateTime dNascimentoCorrente = DateTime.Parse(dtNasc.Day.ToString() + "/" +
            dtNasc.Month.ToString() + "/" + (dtAtual.Year - 1).ToString());
            string totalAnos = "", totalMeses = "", totalDias = "";
            if (dtAtual < dtNasc)
            {
                return "Data de nascimento inválida ";
            }
            idAnos = dtAtual.Year - dtNasc.Year;
            if (dtAtual.Month < dtNasc.Month || (dtAtual.Month ==
            dtNasc.Month && dtAtual.Day < dtNasc.Day))
            {
                idAnos--;
            }
            idMeses = CalculaMeses(dtNasc);
            idDias = CalculaDias(dtNasc);

            totalAnos = idAnos > 1 ? idAnos + " anos " : idAnos + "ano";
            totalMeses = idMeses > 1 ? idMeses + " meses " : idMeses + " mês ";
            totalDias = idDias > 1 ? idDias + " dias " : idDias + " dia ";

            return totalAnos + totalMeses + totalDias;
        }
        public int CalculaAnos(DateTime dtNasc)
        {
            DateTime dtHoje = DateTime.Now;
            int resultado;
            resultado = dtHoje.Year - dtNasc.Year;
            if (dtHoje.Month < dtNasc.Month || (dtHoje.Month == dtNasc.Month && dtHoje.Day < dtNasc.Day))
                resultado--;
            return resultado;
        }
        int CalculaDias(DateTime dtNasc)
        {
            int numeroDias = 0;
            DateTime dataAtual = DateTime.Now;
            if ((dataAtual.Month > dtNasc.Month || dataAtual.Month <
            dtNasc.Month) && (dataAtual.Day > dtNasc.Day))
            {
                DateTime dUltima = DateTime.Parse(dtNasc.Day.ToString() + "/" +
                (dataAtual.Month).ToString() + "/" + (dataAtual.Year).ToString());
                numeroDias = (dataAtual - dUltima).Days;
            }
            else if ((dataAtual.Month > dtNasc.Month || dataAtual.Month <
            dtNasc.Month) && (dataAtual.Day < dtNasc.Day))
            {
                DateTime dUltima = DateTime.Parse(dtNasc.Day.ToString() + "/" +
                (dataAtual.Month - 1).ToString() + "/" + (dataAtual.Year).ToString());
                numeroDias = (dataAtual - dUltima).Days;
            }
            else if (dtNasc.Month == dataAtual.Month)
            {
                DateTime dUltima = DateTime.Parse(dtNasc.Day.ToString() + "/" +
                (dataAtual.Month).ToString() + "/" + (dataAtual.Year).ToString());
                numeroDias = (dataAtual - dUltima).Days;
            }
            return numeroDias;
        }

        int CalculaMeses(DateTime dtNasc)
        {
            int numeroMeses = 0;
            DateTime dataAtual = DateTime.Now;
            if ((dataAtual.Month > dtNasc.Month))
            {
                numeroMeses = dataAtual.Month - dtNasc.Month;
            }
            else if ((dataAtual.Month < dtNasc.Month))
            {
                if (dataAtual.Day > dtNasc.Day)
                {
                    numeroMeses = (12 - dtNasc.Month) + (dataAtual.Month);
                }
                else if (dataAtual.Day < dtNasc.Day)
                {
                    numeroMeses = (12 - dtNasc.Month) + (dataAtual.Month - 1);
                }
            }
            return numeroMeses;
        }

    }
}
