using Senac.Exercicio.Domain.Entities;
using Senac.Exercicio.Infraestrutura.Data;
using System.Data;

namespace Senac.Exercicio.Infraestrutura.Repository
{
    public class PessoaRepository
    {
        public bool ExcluirPessoa(int idPessoa)
        {
            BancoInstance banco;
            using(banco = new BancoInstance())
            {
                return banco.Banco.ExecuteNonQuery(@"delete from Pessoa where Id=@id", "@id", idPessoa);
            }
        }

        public List<PessoaEntity> ObterPessoas (string cpf)
        {
            BancoInstance banco;
            DataTable retorno = new DataTable();
            using(banco = new BancoInstance()) 
            {
                banco.Banco.ExecuteQuery(@"select * from Pessoa where Cpf = @chave", out retorno, "@chave", cpf);
            }
            return ConvertList(retorno);
        }
        public List<PessoaEntity> ObterPessoasPorNome(string nome)
        {
            BancoInstance banco;
            DataTable dt = new DataTable();
            using(banco = new BancoInstance())
            {
                banco.Banco.ExecuteQuery(@"select * from Pessoa where Nome = @chave", out dt, "@chave", nome);
            }
            return ConvertList(dt);
        }
        public List<PessoaEntity> ObterPessoas()
        {
            BancoInstance banco;
            DataTable retorno = new DataTable();
            using(banco=new BancoInstance())
            {
                banco.Banco.ExecuteQuery(@"select * from Pessoa order by Nome",out retorno); 
            }
            return ConvertList(retorno);
        }

        public bool Gravar(PessoaEntity obj)
        {
            BancoInstance banco;
            if(obj.Id == 0) //Gravação- não tem o objeto no banco
            {
                using (banco = new BancoInstance())
                {
                    return banco.Banco.ExecuteNonQuery(@"insert into Pessoa (Nome, Cpf, DataNascimento, Situacao) values (@nome, @cpf, @dtNasc, @situacao)", "@nome", obj.Nome, "@cpf", obj.Cpf, "@dtNasc", obj.DataNascimento, "@situacao", obj.Situacao);
                }
            }
            else //Realizar alteração, já tem o objeto no banco
            {
                using (banco=new BancoInstance())
                {
                    return banco.Banco.ExecuteNonQuery(@"update Pessoa set Nome=@nome, Cpf=@cpf, DataNascimento=@dtNasc where Id=@id", "@nome", obj.Nome, "@cpf", obj.Cpf, "@dtNasc", obj.DataNascimento, "@id", obj.Id);
                }
            }
        }

        private List<PessoaEntity> ConvertList(DataTable dtDados)
        {
            List<PessoaEntity> listaRetorno = new List<PessoaEntity>();

            //Verificando se a consulta retornou alguma informação
            if(dtDados.Rows.Count == 0 ) 
                return listaRetorno;//A consolta não encontrou nada, retorna a lista vazia

            for(int i = 0; i < dtDados.Rows.Count; i++)
            {
                listaRetorno.Add(new PessoaEntity(
                    Convert.ToInt32(dtDados.Rows[i]["Id"]),
                    dtDados.Rows[i]["Nome"].ToString(),
                    dtDados.Rows[i]["Cpf"].ToString(),
                    Convert.ToDateTime(dtDados.Rows[i]["DataNascimento"].ToString()),
                    Convert.ToBoolean(dtDados.Rows[i]["Situacao"].ToString())));
            }
            return listaRetorno;
        }
    }
}
