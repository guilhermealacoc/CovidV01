using CovidV01.AppCode.mod;
using CovidV01.AppCode.per;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CovidV01.AppCode.DAO
{
    public class testeDAO
    {
        public testeDAO() { }

        private static List<teste> ListT = new List<teste>();


        #region SqlServer - DB

        SqlConnection conn;
        SqlCommand cmd;
        public List<teste> GetListTesteDB(out string message)
        {
            try
            {
                conn = new ConnectionFactory().GetConnectionDb(out message);
                SqlDataReader dr;

                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT idTeste,nome FROM Teste ";

                List<teste> listTeste = new List<teste>();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    listTeste.Add(new teste()
                    {
                        idTeste = Convert.ToInt32(dr[0].ToString()),
                        nomeTeste = dr[1].ToString(),
                    });
                }
                conn.Close();
                return listTeste;
            }
            catch (Exception e)
            {
                message = e.ToString();
                return null;
            }
        }
        #endregion


        #region Cadastro de Teste
        public bool Send(teste t, out string message)
        {
            conn = new ConnectionFactory().GetConnectionDb(out message);
            try
            {
                cmd = new SqlCommand("SP_TESTE_IN", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@NOMETESTE", SqlDbType.VarChar).Value = t.nomeTeste; //Convert.ToInt32(p.AID.ToString());
                
                cmd.Parameters.Add("@RETURN", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                message = cmd.Parameters["@RETURN"].Value.ToString();
                return true;
            }
            catch (SqlException erro)
            {
                message = "Erro ao enviar. " + erro.Message;
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        public bool Delete(teste t, out string message)
        {
            conn = new ConnectionFactory().GetConnectionDb(out message);
            try
            {
                cmd = new SqlCommand("SP_TESTE_DEL", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@IDTESTE", SqlDbType.Int).Value = t.idTeste; //Convert.ToInt32(p.AID.ToString());

                cmd.Parameters.Add("@RETURN", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                message = cmd.Parameters["@RETURN"].Value.ToString();
                return true;
            }
            catch (Exception ex)
            {
                message = ex.ToString();
                return false;
            }
        }
        public bool Put(teste t, out string message)
        {
            conn = new ConnectionFactory().GetConnectionDb(out message);
            try
            {
                cmd = new SqlCommand("SP_TESTE_UP", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@IDTESTE", SqlDbType.Int).Value = t.idTeste; //Convert.ToInt32(p.AID.ToString());
                cmd.Parameters.Add("@NOMETESTE", SqlDbType.VarChar).Value = t.nomeTeste;

                cmd.Parameters.Add("@RETURN", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                message = cmd.Parameters["@RETURN"].Value.ToString();
                return true;
            }
            catch (Exception ex)
            {
                message = ex.ToString();
                return false;
            }
        }

    }
}
