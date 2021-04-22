using CovidV01.AppCode.DAO;
using CovidV01.AppCode.mod;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CovidV01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ControleController
    {
        //covidDAO pDAO = new covidDAO();
        controleDAO cDAO = new controleDAO();
        /*https://localhost:44337/controle/getcontrole */
        [HttpGet("getcontrole")]
         public List<controle> Controle()
        {
            controleDAO cDAO = new controleDAO();
            List<controle> listControle = cDAO.GetListControleDB(out string messsage);
            return listControle;
        }

        #region CadastroControle
        /*https://localhost:44337/controle/cadcontrole*/
        [HttpPost("cadcontrole")]
        public string controleDAO([FromBody] controle c)
        {
            controleDAO cDAO = new controleDAO();

            if (cDAO.Send(c, out string message))
            {
                return message;
            }
            else
            {
                return "Erro na solicitação";
            }
        }
        #endregion

        #region Update
        [HttpPut("updatecontrole")]
        public string UpControleDB([FromBody] controle c)
        {
            controleDAO cDAO = new controleDAO();

            if (cDAO.Put(c, out string message))
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
