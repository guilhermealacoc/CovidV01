using System.Collections.Generic;
using CovidV01.AppCode.DAO;
using CovidV01.AppCode.mod;
using Microsoft.AspNetCore.Mvc;

namespace CovidV01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TesteController
    {
        #region GetTestes
        testeDAO tDAO = new testeDAO();
        /// <summary>
        /// NAO TA 
        /// </summary>
        /// <returns></returns>
        /*https://localhost:44337/covid/getAllNameTeste */
        [HttpGet("getAllNameTeste")]
        public List<teste> Teste()
        {
            testeDAO tDAO = new testeDAO();
            List<teste> listTeste = tDAO.GetListTesteDB(out string messsage);
            return listTeste;
        }
        #endregion

        #region CadastroUsuário
        /// <summary>
        /// Cadastro de Usuário
        /// </summary>
        /// <param name="nome">Nome de Usuário</param>

        /*https://localhost:44337/teste/cadteste*/
        [HttpPost("cadteste")]
        public string testeDAO([FromBody] teste t)
        {
            testeDAO tDAO = new testeDAO();

            if (tDAO.Send(t, out string message))
            {
                return message;
            }
            else
            {
                return "Erro na solicitação";
            }
        }
        #endregion

        #region DELETE
        [HttpDelete("DelTeste")]
        public string DelTesteDB([FromBody] teste t)
        {
            testeDAO tDAO = new testeDAO();

            if (tDAO.Delete(t, out string message))
            {
                return "registro excluido com sucesso";
            }
            else
            {
                return "nao foi possivel excluir o registro";
            }
        }
        #endregion

        #region Update
        [HttpPut("updateTeste")]
        public string UpTesteDB([FromBody] teste t)
        {
            testeDAO tDAO = new testeDAO();

            if (tDAO.Put(t, out string message))
            {
                return "registro Atualizado com sucesso";
            }
            else
            {
                return "Nao foi possivel Atualizado o registro";
            }
        }
        #endregion


    }
}
