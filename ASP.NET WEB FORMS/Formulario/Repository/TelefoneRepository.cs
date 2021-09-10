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
    public class TelefoneRepository
    {
        String conexao = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Teste_D1;Data Source=DESKTOP-IILIOLP\SQLEXPRESS";
        public List<TipoTelefone> CarregarTelefone(int IdCliente)
        {
            using (var cn = new SqlConnection(conexao))
            {
                var cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"SELECT IdTelefone, DDD, Telefone, Descricao
                                    FROM dbo.Telefones WITH(NOLOCK)
                                         INNER JOIN dbo.TipoTelefone WITH(NOLOCK) 
                                         ON TipoTelefone.IdTipoTelefone = Telefones.IdTipoTelefone
                                    WHERE IdCliente = @IdCliente";

                cmd.Parameters.AddWithValue("IdCliente", IdCliente);

                SqlDataReader dr = null;
                cn.Open();
                dr = cmd.ExecuteReader();

                List<TipoTelefone> tipoTele = new List<TipoTelefone>();

                while (dr.Read())
                {
                    TipoTelefone tipoTelefone = new TipoTelefone();

                    tipoTelefone.IdTelefone = Convert.ToInt32(dr["IdTelefone"]);
                    tipoTelefone.DDD = Convert.ToString(dr["DDD"]);
                    tipoTelefone.Telefone = Convert.ToString(dr["Telefone"]);
                    tipoTelefone.Descricao = Convert.ToString(dr["Descricao"]);
                    tipoTele.Add(tipoTelefone);

                }
                cn.Close();

                return tipoTele;
            }

            return new List<TipoTelefone>();
        }

        public void GravarTelefone(TipoTelefone telefone)
        {
            using (var cn = new SqlConnection(conexao))
            {
                var cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;

                if(telefone.IdTelefone == 0)
                {
                    cmd.CommandText = @"INSERT INTO dbo.Telefones(DDD, Telefone, IdCliente, IdTipoTelefone)
                                        VALUES(@DDD, @Telefone, @IdCliente, @IdTipoTelefone)";
                }
                else
                {
                    cmd.CommandText = @"UPDATE Telefones 
                                        SET DDD = @DDD, Telefone = @Telefone, IdCliente = @IdCliente, IdTipoTelefone = @IdTipoTelefone 
                                        WHERE IdTelefone = @IdTelefone";
                    
                    cmd.Parameters.AddWithValue("IdTelefone", telefone.IdTelefone);
                }

                cmd.Parameters.AddWithValue("DDD", telefone.DDD);
                cmd.Parameters.AddWithValue("Telefone", telefone.Telefone);
                cmd.Parameters.AddWithValue("IdCliente", telefone.IdCliente);
                cmd.Parameters.AddWithValue("IdTipoTelefone", telefone.IdTipoTelefone);

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

        public TipoTelefone EditarTelefone(int IdTelefone)
        {
            using (var cn = new SqlConnection(conexao))
            {
                var cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"SELECT IdTelefone, DDD, Telefone, IdTipoTelefone 
                                    FROM dbo.Telefones WITH(NOLOCK)
                                    WHERE IdTelefone = @IdTelefone";

                cmd.Parameters.AddWithValue("IdTelefone", IdTelefone);

                SqlDataReader dr = null;
                cn.Open();
                dr = cmd.ExecuteReader();

                TipoTelefone telefone = new TipoTelefone();
                while (dr.Read())
                {
                    telefone.IdTelefone = Convert.ToInt32(dr["IdTelefone"]);
                    telefone.DDD = dr["DDD"].ToString();
                    telefone.Telefone = dr["Telefone"].ToString();
                    telefone.IdTipoTelefone = Convert.ToInt32(dr["IdTipoTelefone"]);                    
                }
                cn.Close();

                return telefone;
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
                                    FROM dbo.Telefones 
                                    WHERE IdTelefone = @IdTelefone";

                cmd.Parameters.AddWithValue("IdTelefone", IdCodigo);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

    }
}

