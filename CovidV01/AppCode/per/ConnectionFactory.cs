using System;
using System.Data.SqlClient;

namespace CovidV01.AppCode.per
{
    public class ConnectionFactory
    {
        SqlConnection conn;

        public SqlConnection GetConnectionDb(out string message)
        {
            /*VIA - NTTECNO01\MSSQLSERVER02*/
            message = string.Empty;
            //conn = new SqlConnection("Server=DESKTOP-99G610B\\GUILHERME;Initial Catalog=SOA_20203;Integrated Security=true");
            conn = new SqlConnection("Server=DESKTOP-99G610B\\GUILHERME;Database=covid;User Id=teste;Password=123456;");

            try
            {
                if (conn == null || conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                    message = string.Empty;
                    return conn;
                }
                else
                {
                    return conn;
                }
            }
            catch (Exception ex)
            {
                message = "ERRO!!NÂO FOI POSSIVEL CONECTAR" + ex.ToString();
                return null;
            }
        }

    }
}
