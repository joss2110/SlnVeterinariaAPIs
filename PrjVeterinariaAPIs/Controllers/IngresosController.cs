using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrjVeterinariaAPIs.DAO;
using PrjVeterinariaAPIs.Models;

namespace PrjVeterinariaAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngresosController : ControllerBase
    {
        private readonly IngresosDAO daoingreso;

        public IngresosController(IngresosDAO ingreso)
        {
            daoingreso = ingreso;
        }

        [HttpGet("GetIngresos")]
        public async Task<ActionResult<List<PA_LISTAR_INGRESOS>>> GetIngresos()
        {
            var listado = await Task.Run(() => daoingreso.GetIngresos());
            return Ok(listado);
        }

        [HttpPost("GrabarIngresos")]
        public async Task<ActionResult<int>> GrabarIngresos([FromBody] Ingresos obj)
        {
            int idingre = await Task.Run(() => daoingreso.GrabarIngresos(obj));
            return Ok(idingre);
        }

        [HttpDelete("EliminarIngresos/{id}")]
        public async Task<ActionResult<string>> EliminarIngresos(int id)
        {
            string mensaje = await Task.Run(() => daoingreso.EliminarIngresos(id));
            return Ok(mensaje);
        }

        [HttpPut("RestaurarIngresos")]
        public async Task<ActionResult<string>> RestaurarIngresos([FromBody] Ingresos obj)
        {
            string mensaje = await Task.Run(() => daoingreso.RestaurarIngresos(obj));
            return Ok(mensaje);
        }

    }
}
