using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Impl
{
    public class ClienteRepository
    {
        String conexao = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Teste_D1;Data Source=DESKTOP-IILIOLP\SQLEXPRESS";

        public void GravarPessoa(Cliente cliente)
        {
            using (var cn = new SqlConnection(conexao))
            {
                var cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;

                if (cliente.IdCliente == 0)
                {
                    cmd.CommandText = @"INSERT INTO CLIENTE(Nome, DataNascimento, CPF, RG, facebook, twitter, linkedin, instagram)
                                        VALUES(@Nome, @DataNascimento, @CPF, @RG, @facebook, @twitter, @linkedin, @instagram)";
                }
                else
                {
                    cmd.CommandText = @"UPDATE dbo.CLIENTE 
                                        SET Nome = @Nome, DataNascimento = @DataNascimento,
                                            CPF = @CPF, RG = @RG, facebook = @facebook, twitter = @twitter, linkedin = @linkedin, instagram = @instagram
                                        WHERE IdCliente = @IdCliente";

                    cmd.Parameters.AddWithValue("IdCliente", cliente.IdCliente);
                }

                cmd.Parameters.AddWithValue("Nome", cliente.Nome);
                cmd.Parameters.AddWithValue("DataNascimento", cliente.DataNascimento);
                cmd.Parameters.AddWithValue("CPF", cliente.Cpf);
                cmd.Parameters.AddWithValue("RG", cliente.RG);
                cmd.Parameters.AddWithValue("facebook", cliente.Facebook);
                cmd.Parameters.AddWithValue("twitter", cliente.Twitter);
                cmd.Parameters.AddWithValue("linkedin", cliente.Linkedin);
                cmd.Parameters.AddWithValue("instagram", cliente.Instagram);

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

        public Cliente CarregarPessoa(int codigo)
        {
            using (var cn = new SqlConnection(conexao))
            {
                var cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"SELECT IdCliente, Nome, DataNascimento, CPF, RG, facebook, linkedin, twitter, instagram
                                    FROM dbo.CLIENTE WITH(NOLOCK)
                                    WHERE IdCliente = @IdCliente";

                cmd.Parameters.AddWithValue("IdCliente", codigo);

                SqlDataReader dr = null;
                cn.Open();
                dr = cmd.ExecuteReader();

                Cliente cli = new Cliente();
                while (dr.Read())
                {
                    cli.IdCliente = Convert.ToInt32(dr["IdCliente"]);
                    cli.Nome = dr["Nome"].ToString();
                    cli.Cpf = dr["CPF"].ToString();
                    cli.DataNascimento = Convert.ToDateTime(dr["DataNascimento"]).ToString("dd/MM/yyyy");
                    cli.RG = dr["RG"].ToString();
                    cli.Facebook = dr["facebook"].ToString();
                    cli.Twitter = dr["twitter"].ToString();
                    cli.Linkedin = dr["linkedin"].ToString();
                    cli.Instagram = dr["instagram"].ToString();
                }
                cn.Close();

                return cli;
            }
        }

        public List<Cliente> ListarPessoa(string nome)
        {
            using (var cn = new SqlConnection(conexao))
            {
                var cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"SELECT IdCliente, Nome, DataNascimento, CPF, RG 
                                    FROM dbo.CLIENTE WITH(NOLOCK) 
                                    WHERE Nome Like '%'+ @Nome + '%'";

                cmd.Parameters.AddWithValue("Nome", nome);

                SqlDataReader dr = null;
                cn.Open();
                dr = cmd.ExecuteReader();

                List<Cliente> lista = new List<Cliente>();

                while (dr.Read())
                {
                    Cliente cli = new Cliente();

                    cli.IdCliente = Convert.ToInt32(dr["IdCliente"]);
                    cli.Nome = dr["Nome"].ToString();
                    cli.Cpf = dr["CPF"].ToString();
                    cli.DataNascimento = Convert.ToDateTime(dr["DataNascimento"]).ToString("dd/MM/yyyy");
                    cli.RG = dr["RG"].ToString();
                    lista.Add(cli);
                }
                cn.Close();

                return lista;
            }

            return new List<Cliente>();
        }

        public void Delete(int codigo)
        {
            using (var cn = new SqlConnection(conexao))
            {
                var cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"DELETE 
                                    FROM dbo.CLIENTE 
                                    WHERE IdCliente = @IdCliente";

                cmd.Parameters.AddWithValue("IdCliente", codigo);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }       
    }    
}




