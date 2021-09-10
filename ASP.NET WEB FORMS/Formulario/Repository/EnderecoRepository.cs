using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class EnderecoRepository
    {
        String conexao = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Teste_D1;Data Source=DESKTOP-IILIOLP\SQLEXPRESS";
        public List<TipoEndereco> CarregarEndereco(int IdCliente)
        {
            using (var cn = new SqlConnection(conexao))
            {
                var cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"SELECT IdEndereco,Endereco, Bairro, Cidade, DescricaoEndereco 
                                    FROM dbo.Enderecos WITH(NOLOCK)
                                    	 INNER JOIN TipoEndereco WITH(NOLOCK) 
                                    	 ON TipoEndereco.IdTipoEndereco = Enderecos.IdTipoEndereco
                                    WHERE IdCliente = @IdCliente";

                cmd.Parameters.AddWithValue("IdCliente", IdCliente);

                SqlDataReader dr = null;
                cn.Open();
                dr = cmd.ExecuteReader();

                List<TipoEndereco> tipoEndereco = new List<TipoEndereco>();

                while (dr.Read())
                {
                    TipoEndereco tipoEnde = new TipoEndereco();

                    tipoEnde.IdEndereco = Convert.ToInt32(dr["IdEndereco"]);
                    tipoEnde.Endereco = Convert.ToString(dr["Endereco"]);
                    tipoEnde.Bairro = Convert.ToString(dr["Bairro"]);
                    tipoEnde.Cidade = Convert.ToString(dr["Cidade"]);
                    tipoEnde.DescricaoEndereco = Convert.ToString(dr["DescricaoEndereco"]);
                    tipoEndereco.Add(tipoEnde);

                }
                cn.Close();

                return tipoEndereco;
            }

            return new List<TipoEndereco>();
        }

        public void GravarEndereco(TipoEndereco endereco)
        {
            using (var cn = new SqlConnection(conexao))
            {
                var cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;

                if (endereco.IdEndereco == 0)
                {
                    cmd.CommandText = @"INSERT INTO dbo.Enderecos(Endereco, Bairro, Cidade,IdCliente, IdTipoEndereco)
                                        VALUES(@Endereco, @Bairro, @Cidade, @IdCliente, @IdTipoEndereco)";
                }
                else
                {
                    cmd.CommandText = @"UPDATE dbo.Enderecos 
                                        SET Endereco = @Endereco, Bairro = @Bairro, Cidade = @Cidade, IdCliente = @IdCliente, IdTipoEndereco = @IdTipoEndereco 
                                        WHERE IdEndereco = @IdEndereco";
                    
                    cmd.Parameters.AddWithValue("IdEndereco", endereco.IdEndereco);
                }

                cmd.Parameters.AddWithValue("Endereco", endereco.Endereco);
                cmd.Parameters.AddWithValue("Bairro", endereco.Bairro);
                cmd.Parameters.AddWithValue("Cidade", endereco.Cidade);
                cmd.Parameters.AddWithValue("IdCliente", endereco.IdCliente);
                cmd.Parameters.AddWithValue("IdTipoEndereco", endereco.IdTipoEndereco);

                try
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    cn.Close();
                    cn.Dispose();
                }
            }
        }

        public TipoEndereco EditarEndereco(int IdEndereco)
        {
            using (var cn = new SqlConnection(conexao))
            {
                var cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"SELECT IdEndereco, Endereco, Bairro, Cidade, IdTipoEndereco
                                    FROM dbo.Enderecos WITH(NOLOCK)
                                    WHERE IdEndereco = @IdEndereco";

                cmd.Parameters.AddWithValue("IdEndereco", IdEndereco);

                SqlDataReader dr = null;
                cn.Open();
                dr = cmd.ExecuteReader();

                TipoEndereco endereco = new TipoEndereco();
                while (dr.Read())
                {
                    endereco.IdEndereco = Convert.ToInt32(dr["IdEndereco"]);
                    endereco.Endereco = dr["Endereco"].ToString();
                    endereco.Bairro = dr["Bairro"].ToString();
                    endereco.Cidade = dr["Cidade"].ToString();
                    endereco.IdTipoEndereco = Convert.ToInt32(dr["IdTipoEndereco"]);
                }
                cn.Close();

                return endereco;
            }
        }
        public void Delete(int IdCodigo)
        {
            using (var cn = new SqlConnection(conexao))
            {
                var cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"DELETE 
                                    FROM dbo.Enderecos 
                                    WHERE IdEndereco = @IdEndereco";

                cmd.Parameters.AddWithValue("IdEndereco", IdCodigo);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }
    }
}
