using CovidV01.AppCode.mod;
using CovidV01.AppCode.per;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CovidV01.AppCode.DAO
{
    public class controleDAO
    {
        public controleDAO() { }

        SqlConnection conn;
        SqlCommand cmd;

        private static List<controle> ListC = new List<controle>();

        public List<controle> GetListControleDB(out string message)
        {
            try
            {
                conn = new ConnectionFactory().GetConnectionDb(out message);
                SqlDataReader dr;

                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT idControle,idUsuario,idTeste,status,resultado FROM Controle";

                List<controle> listControle = new List<controle>();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    listControle.Add(new controle()
                    {
                        idControle = Convert.ToInt32(dr[0].ToString()),
                        idUsuario = Convert.ToInt32(dr[1].ToString()),
                        idTeste = Convert.ToInt32(dr[2].ToString()),
                        status = dr[3].ToString(),
                        resultado = dr[4].ToString(),
                    });
                }
                conn.Close();
                return listControle;
            }
            catch (Exception e)
            {
                message = e.ToString();
                return null;
            }
        }


        public bool Send(controle c, out string message)
        {
            conn = new ConnectionFactory().GetConnectionDb(out message);
            try
            {
                cmd = new SqlCommand("SP_CONTROLE_IN", conn);
                cmd.CommandType = CommandType.StoredProcedure;

              
                cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = c.idUsuario.ToString();
                cmd.Parameters.Add("@IDTESTE", SqlDbType.Int).Value = c.idTeste.ToString();
                cmd.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = c.status.ToString();
                cmd.Parameters.Add("@RESULTADO", SqlDbType.VarChar).Value = c.resultado.ToString();

                cmd.Parameters.Add("@RETURN", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                message = cmd.Parameters["@RETURN"].Value.ToString();
                return true;
            }
            catch(SqlException erro)
            {
                message = "Erro ao enviar. " + erro.Message;
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool Put(controle c, out string message)
        {
            conn = new ConnectionFactory().GetConnectionDb(out message);
            try
            {
                cmd = new SqlCommand("SP_CONTROLE_UP", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@IDCONTROLE", SqlDbType.Int).Value = c.idControle;
                cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = c.idUsuario;
                cmd.Parameters.Add("@IDTESTE", SqlDbType.Int).Value = c.idTeste;
                cmd.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = c.status;
                cmd.Parameters.Add("@RESULTADO", SqlDbType.VarChar).Value = c.resultado;

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
