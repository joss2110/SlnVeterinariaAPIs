using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrjVeterinariaAPIs.DAO;
using PrjVeterinariaAPIs.Models;

namespace PrjVeterinariaAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly RolesDAO daorol;

        public RolesController(RolesDAO daoRol)
        {
            daorol = daoRol;
        }

        //GET:Roles
        [HttpGet("GetRoles")]
        public async Task<ActionResult<List<Roles>>> GetRoles()
        {
            var listado = await Task.Run(() => daorol.GetRoles());
            //
            return Ok(listado);
        }
    }
}
