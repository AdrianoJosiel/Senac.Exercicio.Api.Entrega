using Senac.Exercicio.Domain.Entities;
using Senac.Exercicio.Infraestrutura.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senac.Exercicio.Infraestrutura.Repository
{
    public class EnderecoRepository
    {
        public bool ExcluirEndereco(int idEndereco)
        {
            BancoInstance banco;
            using (banco = new BancoInstance())
            {
                return banco.Banco.ExecuteNonQuery(@"delete from Endereco where Id=@id", "@id", idEndereco);
            }
        }


        public bool Gravar(EnderecoEntity obj)
        {


            BancoInstance banco;
            {
                using (banco = new BancoInstance())
                {

                    var enderecoExistente = ObterEndereco(obj.Logradouro, obj.Numero);

                    if (enderecoExistente != null && enderecoExistente.Count > 0)
                    {
                       
                        throw new Exception("Já existe um usuário cadastrado com este endereço.");
                    }
                    
                    return banco.Banco.ExecuteNonQuery(@"
                insert into Endereco (IdPessoa, Logradouro, Numero, Complemento, Bairro) 
                values (@pessoaId, @logradouro, @numero, @complemento, @bairro)",
                        "@pessoaId", obj.PessoaId,
                        "@logradouro", obj.Logradouro,
                        "@numero", obj.Numero,
                        "@complemento", obj.Complemento,
                        "@bairro", obj.Bairro);
                }
            }
        }

        public bool Editar(EnderecoEntity obj)
        {
            BancoInstance banco;
            {
                using (banco = new BancoInstance())
                {
                   
                    var enderecoExistente = ObterEnderecosPorPessoa(obj.PessoaId);

                   
                    if (enderecoExistente != null && enderecoExistente.Count > 0)
                    {
                        return banco.Banco.ExecuteNonQuery(@"
                UPDATE Endereco 
                SET Logradouro = @logradouro, 
                    Numero = @numero, 
                    Complemento = @complemento, 
                    Bairro = @bairro
                WHERE Id = @id",
                     "@logradouro", obj.Logradouro,
                     "@numero", obj.Numero,
                     "@complemento", obj.Complemento,
                     "@bairro", obj.Bairro,
                      "@id", obj.Id);
                     
                    }
                    
                    throw new Exception("Não existe endereço vinculado para esta pessoaID.");
                }
            }
        }



        public List<EnderecoEntity> ObterEnderecosPorPessoa(int pessoaId)
        {
            BancoInstance banco;
            DataTable retorno = new DataTable();
            using (banco = new BancoInstance())
            {
              
                banco.Banco.ExecuteQuery(@"
            SELECT * 
            FROM Endereco 
            WHERE IdPessoa = @pessoaId",
                    out retorno,
                    "@pessoaId", pessoaId);
            }

            // Converte o DataTable para uma lista de objetos EnderecoEntity
            return ConvertList(retorno);
        }


        public List<EnderecoEntity> ObterEndereco(string logradouro, string numero)
        {
            BancoInstance banco;
            DataTable retorno = new DataTable();
            using (banco = new BancoInstance())
            {
                banco.Banco.ExecuteQuery(@"SELECT * FROM Endereco WHERE Logradouro = @logradouro AND Numero = @numero", out retorno, "@logradouro", logradouro, "@numero", numero);
            }
            return ConvertList(retorno);
        }

        private List<EnderecoEntity> ConvertList(DataTable dtDados)
        {
            List<EnderecoEntity> listaRetorno = new List<EnderecoEntity>();

            //Verificando se a consulta retornou alguma informação
            if (dtDados.Rows.Count == 0)
                return listaRetorno;//A consolta não encontrou nada, retorna a lista vazia

            for (int i = 0; i < dtDados.Rows.Count; i++)
            {
                listaRetorno.Add(new EnderecoEntity(
                    Convert.ToInt32(dtDados.Rows[i]["Id"]),
                    Convert.ToInt32(dtDados.Rows[i]["IdPessoa"]),
                    dtDados.Rows[i]["Logradouro"].ToString(),
                    dtDados.Rows[i]["Numero"].ToString(),
                    dtDados.Rows[i]["Complemento"].ToString(),
                    dtDados.Rows[i]["Bairro"].ToString()));
            }
            return listaRetorno;
        }


    }
}
