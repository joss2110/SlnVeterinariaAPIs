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

        //http://localhost:5050/api/Login/Login/12345678/password123/1

        [HttpGet("Login/{nroDocumento}/{password}/{tipoDocumento}")]
        public async Task<ActionResult<Users>> LoginGet(string nroDocumento, string password, int tipoDocumento)
        {
            Users usuario = await Task.Run(() => daousers.AuthenticateUser(nroDocumento, password, tipoDocumento));

            if (usuario != null)
            {
                return Ok(usuario);
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
