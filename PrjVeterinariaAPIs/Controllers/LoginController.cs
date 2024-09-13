using FlowersshoesCoreMVC.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using PrjVeterinariaAPIs.DAO;
using PrjVeterinariaAPIs.Models;

namespace PrjVeterinariaAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UsersDAO daousers;
        private readonly TipoDocDAO daotipodoc;

        public LoginController(UsersDAO daoUsers, TipoDocDAO daoTipodoc)
        {
            daousers = daoUsers;
            daotipodoc = daoTipodoc;
        }


        [HttpGet("Login/{nroDocumento}/{password}/{tipoDocumento}")]
        public async Task<ActionResult<string>> LoginGet(string nroDocumento, string password, int tipoDocumento)
        {
            bool isAuthenticated = await Task.Run(() => daousers.AuthenticateUser(nroDocumento, password, tipoDocumento));

            if (isAuthenticated)
            {
                return Ok(true);
            }
            else
            {
                return Unauthorized(false);
            }
        }

        [HttpGet("GetTipoDoc")]
        public async Task<ActionResult<List<TipoDoc>>> GetTipoDoc()
        {
            var listado = await Task.Run(() => daotipodoc.getTipoDoc());
            return Ok(listado);
        }

        


    }
}
