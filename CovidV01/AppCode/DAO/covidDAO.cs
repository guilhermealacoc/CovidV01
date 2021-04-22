using CovidV01.AppCode.mod;
using CovidV01.AppCode.per;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CovidV01.AppCode.DAO
{
    public class covidDAO
    {
        public covidDAO() { }

        private static List<covid> ListC = new List<covid>();

        public void Insert(covid p)
        {
            ListC.Add(p);
        }

        public List<covid> ListaPessoa()
        {
            return ListC;
        }

        #region SqlServer - DB

        SqlConnection conn;
        SqlCommand cmd;

        public List<covid> GetListCovidDB(out string message)
        {
            try
            {
                conn = new ConnectionFactory().GetConnectionDb(out message);
                SqlDataReader dr;

                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Usuario ";

                List<covid> listPessoa = new List<covid>();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    listPessoa.Add(new covid()
                    {
                        idUsuario = Convert.ToInt32(dr[0].ToString()),
                        nome = dr[1].ToString(),
                        telefone = dr[2].ToString(),
                        rua = dr[3].ToString(),
                        numero = dr[4].ToString(),
                        complemento = dr[5].ToString(),
                        bairro = dr[6].ToString(),
                        celular = dr[7].ToString(),
                        moradoresResidencia = Convert.ToInt32(dr[8].ToString()),
                        profissao = dr[9].ToString(),
                        idade = Convert.ToInt32(dr[10].ToString()),
                    });
                }
                conn.Close();
                return listPessoa;
            }
            catch (Exception e)
            {
                message = e.ToString();
                return null;
            }
        }


        
        public bool Send(covid p, out string message)
        {
            conn = new ConnectionFactory().GetConnectionDb(out message);
            try
            {
                cmd = new SqlCommand("SP_USUARIO_IN", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@NOME", SqlDbType.VarChar).Value = p.nome; //Convert.ToInt32(p.AID.ToString());
                cmd.Parameters.Add("@TELEFONE", SqlDbType.VarChar).Value = p.telefone.ToString();
                cmd.Parameters.Add("@RUA", SqlDbType.VarChar).Value = p.rua.ToString();
                cmd.Parameters.Add("@NUMERO", SqlDbType.VarChar).Value = p.numero.ToString();
                cmd.Parameters.Add("@COMPLEMENTO", SqlDbType.VarChar).Value = p.complemento.ToString();
                cmd.Parameters.Add("@BAIRRO", SqlDbType.VarChar).Value = p.bairro.ToString();
                cmd.Parameters.Add("@CELULAR", SqlDbType.VarChar).Value = p.celular.ToString();
                cmd.Parameters.Add("@MORADORESRESIDENCIA", SqlDbType.Int).Value = p.moradoresResidencia.ToString();
                cmd.Parameters.Add("@PROFISSAO", SqlDbType.VarChar).Value = p.profissao.ToString();
                cmd.Parameters.Add("@IDADE", SqlDbType.Int).Value = p.idade.ToString();

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

    }
}
