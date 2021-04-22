using CovidV01.AppCode.DAO;
using CovidV01.AppCode.mod;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace CovidV01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CovidController : ControllerBase
    {

        #region GetPessoaDao
        covidDAO pDAO = new covidDAO();

        /*https://localhost:44337/covid/getallnamedb */
        [HttpGet("getAllNameDB")]
        public List<covid> Pessoa()
        {
            covidDAO pDAO = new covidDAO();
            List<covid> listPessoa = pDAO.GetListCovidDB(out string messsage);
            return listPessoa;
        }
        #endregion

        #region CadastroUsuário
        /// <summary>
        /// Cadastro de Usuário
        /// </summary>
        /// <param name="nome">Nome de Usuário</param>

        /*https://localhost:44337/covid/cadusuario*/
        [HttpPost("cadusuario")]
        public string covidDAO([FromBody] covid p)
        {
            covidDAO pDAO = new covidDAO();
            
            if (pDAO.Send(p, out string message))
            {
                return message;
            }
            else
            {
                return "Erro na solicitação";
            }
        }
        #endregion
    }


}
