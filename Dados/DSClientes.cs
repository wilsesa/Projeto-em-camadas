using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Modelo;



namespace Dados
{
    public class DSClientes
    {
        private string strConexao = ConfigurationManager.ConnectionStrings["StringConexao"].ConnectionString;

        public void InserirClientes(MLClientes modelo)
        {
            using (SqlConnection objConexao = new SqlConnection(strConexao))
            {
                string instrucaoSQL = "INSERT INTO Clientes (Cliente, Email, Ativo, DataCadastro) VALUES (@Cliente, @Email, @Ativo, @DataCadastro)";
                using (SqlCommand objCommand = new SqlCommand(instrucaoSQL, objConexao))
                {
                    try
                    {
                        objConexao.Open();
                        objCommand.Parameters.AddWithValue("@Cliente", modelo.Cliente);
                        objCommand.Parameters.AddWithValue("@Email", modelo.Email);
                        objCommand.Parameters.AddWithValue("@Ativo", modelo.Ativo);
                        objCommand.Parameters.AddWithValue("@DataCadastro", modelo.DataCadastro);
                        objCommand.ExecuteNonQuery();
                    }
                    catch (Exception ex )
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        objConexao.Close();
                    }
                }
            }
        }

        public void AtualizarClientes(MLClientes modelo)
        {
            using (SqlConnection objConexao = new SqlConnection(strConexao))
            {
                string instrucaoSQL = "UPDATE Clientes SET Cliente = @Cliente, Email = @Email, Ativo = @Ativo, DataCadastro = @DataCadastro WHERE IdCliente = @IdCliente) ";
                using (SqlCommand objCommand = new SqlCommand(instrucaoSQL, objConexao))
                {
                    try
                    {
                        objConexao.Open();
                        objCommand.Parameters.AddWithValue("@IdCliente", modelo.IdCliente);
                        objCommand.Parameters.AddWithValue("@Cliente", modelo.Cliente);
                        objCommand.Parameters.AddWithValue("@Email", modelo.Email);
                        objCommand.Parameters.AddWithValue("@Ativo", modelo.Ativo);
                        objCommand.Parameters.AddWithValue("@DataCadastro", modelo.DataCadastro);
                        objCommand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        objConexao.Close();
                    }
                }
            }
        }

        public void ExcluirClientes(int IdCliente)
        {
            using (SqlConnection objConexao = new SqlConnection(strConexao))
            {
                string instrucaoSQL = "DELETE FROM Clientes WHERE IdCliente = @IdCliente";
                using (SqlCommand objCommand = new SqlCommand(instrucaoSQL, objConexao))
                {
                    try
                    {
                        objConexao.Open();
                        objCommand.Parameters.AddWithValue("@IdCliente", IdCliente);
                        objCommand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        objConexao.Close();
                    }
                }
            }
        }

        public List<MLClientes> listarClientes()
        {
            List<MLClientes> listaRetorno = new List<MLClientes>();

            using (SqlConnection objConexao = new SqlConnection(strConexao)) 
            {
                string instrucaoSQL = "SELECT IdCliente, Cliente, Email, Ativo, DataCadastro FROM Clientes";
                
                using (SqlCommand objCommand = new SqlCommand(instrucaoSQL, objConexao))
                {
                    try
                    {
                        objConexao.Open();
                        SqlDataReader objDataReader = objCommand.ExecuteReader();

                        if (objDataReader.HasRows)
                        {
                            while (objDataReader.Read())
                            {
                                MLClientes objAuxiliar = new MLClientes();

                                objAuxiliar.IdCliente = Convert.ToInt32(objDataReader["IdCliente"].ToString());
                                objAuxiliar.Cliente = objDataReader["Cliente"].ToString();
                                objAuxiliar.Email = objDataReader["Email"].ToString();
                                objAuxiliar.Ativo = Convert.ToBoolean(objDataReader["Ativo"].ToString().Equals("True"));
                                objAuxiliar.DataCadastro = Convert.ToDateTime(objDataReader["DataCadastro"].ToString());

                                listaRetorno.Add(objAuxiliar);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        objConexao.Dispose();
                        objConexao.Close();
                    }
                }
            }
            return listaRetorno;
        }
    }
}
